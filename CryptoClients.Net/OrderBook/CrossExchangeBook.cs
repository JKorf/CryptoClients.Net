using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClients.Net.OrderBook
{
    /// <summary>
    /// Order book implementation for multiple exchanges combined into a single book
    /// </summary>
    public class CrossExchangeBook : ICrossExchangeBook
    {
        private readonly IExchangeOrderBookFactory _factory;
        private readonly ExchangeParameters? _exchangeParameters;
        private ISymbolOrderBook[] _books = [];
        private ConcurrentDictionary<string, ISymbolOrderBookEntry> _bestBids = new ConcurrentDictionary<string, ISymbolOrderBookEntry>();
        private ConcurrentDictionary<string, ISymbolOrderBookEntry> _bestAsks = new ConcurrentDictionary<string, ISymbolOrderBookEntry>();
        private CrossOrderBookSnapshotEntry? _lastBestAsk;
        private CrossOrderBookSnapshotEntry? _lastBestBid;
        private CrossExchangeBookStatus _lastStatus;

#if NET9_0_OR_GREATER
        private readonly Lock _lock = new Lock();    
#else
        private readonly object _lock = new object();
#endif


        /// <inheritdoc />
        public Dictionary<string, OrderBookStatus> ExchangeStatus => _books.ToDictionary(x => x.Exchange, x => x.Status);
        /// <inheritdoc />
        public CrossExchangeBookStatus Status
        {
            get
            {
                if (_books.Length == 0)
                    return CrossExchangeBookStatus.Initial;

                if (_books.All(x => x.Status == OrderBookStatus.Synced))
                    return CrossExchangeBookStatus.Synced;
                if (_books.Any(x => x.Status == OrderBookStatus.Synced || x.Status == OrderBookStatus.Syncing || x.Status == OrderBookStatus.Reconnecting))
                    return CrossExchangeBookStatus.PartiallySynced;
                return CrossExchangeBookStatus.Initial;
            }
        }
        /// <inheritdoc />
        public SharedSymbol Symbol { get; }
        /// <inheritdoc />
        public string[] Exchanges { get; }
        /// <inheritdoc />
        public int? MinimalDepth { get; }
        /// <inheritdoc />
        public ISymbolOrderBook[] ExchangeBooks => _books.ToArray();
        /// <inheritdoc />
        public DateTime UpdateTime => _books.Length > 0 ? _books.Max(x => x.UpdateTime) : default;
        /// <inheritdoc />
        public DateTime? UpdateServerTime => _books.Where(x => x.UpdateServerTime != null).Max(x => x.UpdateServerTime);
        /// <inheritdoc />
        public DateTime? UpdateLocalTime => _books.Where(x => x.UpdateLocalTime != null).Max(x => x.UpdateLocalTime);
        /// <inheritdoc />
        public TimeSpan? DataAge => UpdateLocalTime == null ? null : DateTime.UtcNow - UpdateLocalTime;
        /// <inheritdoc />
        public CrossOrderBookSnapshotEntry? BestBid => _lastBestBid;
        /// <inheritdoc />
        public CrossOrderBookSnapshotEntry? BestAsk => _lastBestAsk;
        /// <inheritdoc />
        public (CrossOrderBookSnapshotEntry? Bid, CrossOrderBookSnapshotEntry? Ask) BestOffers
        {
            get
            {
                lock (_lock)
                    return (_lastBestBid, _lastBestAsk);
            }
        }
        /// <inheritdoc />
        public decimal Spread
        {
            get
            {
                lock (_lock)
                    return _lastBestAsk != null && _lastBestBid != null ? _lastBestAsk.Entry.Price - _lastBestBid.Entry.Price : 0;
            }
        }
        /// <inheritdoc />
        public decimal SpreadPercentage
        {
            get
            {
                lock (_lock)
                    return _lastBestAsk != null && _lastBestBid != null ? (_lastBestAsk.Entry.Price - _lastBestBid.Entry.Price) / _lastBestBid.Entry.Price * 100 : 0;
            }
        }

        /// <inheritdoc />
        public event Action<(CrossOrderBookSnapshotEntry? BestBid, CrossOrderBookSnapshotEntry? BestAsk)>? OnBestOffersChanged;
        /// <inheritdoc />
        public event Action<string, OrderBookStatus, OrderBookStatus>? OnExchangeStatusChange;
        /// <inheritdoc />
        public event Action<CrossExchangeBookStatus>? OnStatusChange;

        /// <summary>
        /// ctor
        /// </summary>
        public CrossExchangeBook(IExchangeOrderBookFactory factory, SharedSymbol symbol, int? minDepth = null, IEnumerable<string>? exchanges = null, ExchangeParameters? exchangeParameters = null)
        {
            _factory = factory;
            _exchangeParameters = exchangeParameters;

            Symbol = symbol;
            MinimalDepth = minDepth;
            Exchanges = exchanges?.ToArray() ?? Exchange.All;
        }

        /// <inheritdoc />
        public async Task<CallResult> StartAsync()
        {
            _books = Exchanges.Select(x => _factory.Create(x, Symbol, MinimalDepth, _exchangeParameters)).Where(x => x != null).ToArray()!;
            if (_books.Length == 0)
                return CallResult.Fail(ArgumentError.Invalid("Symbol", "No orderbooks could be created for the provided parameters"));

            foreach (var book in _books)
            {
                book.OnBestOffersChanged += (offers) => BookBestOfferChange(book, offers);
                book.OnStatusChange += (oldStatus, newStatus) => BookStatusChange(book, oldStatus, newStatus);
            }

            var results = await Task.WhenAll(_books.Select(x => x.StartAsync())).ConfigureAwait(false);
            if (!results.All(x => x.Success))
            {
                var stopTasks = _books.Select(x => x.StopAsync());
                await Task.WhenAll(stopTasks).ConfigureAwait(false);
                return results.First(x => !x.Success);
            }

            return CallResult.Ok();
        }

        /// <inheritdoc />
        public async Task StopAsync()
        {
            await Task.WhenAll(_books.Select(x => x.StopAsync())).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public CrossOrderBookSnapshot Snapshot(int? snapshotDepth = null, int? exchangeDepth = null)
        {
            // Get snapshot of all synced books so we're they're all at the same point in time
            var bookSnapshots = _books.Where(x => x.Status == OrderBookStatus.Synced).Select(x => (x.Exchange, x.Book));

            var result = new CrossOrderBookSnapshot();
            foreach (var item in bookSnapshots)
            {
                foreach (var bid in item.Book.bids.Take(exchangeDepth ?? int.MaxValue))
                {
                    if (!result.Bids.TryGetValue(bid.Price, out var level))
                    {
                        if (snapshotDepth != null && result.Bids.Count >= snapshotDepth)
                        {
                            var minBidPrice = result.Bids.Values.Min(x => x.Price);
                            if (minBidPrice > bid.Price)
                                // We only want to include the best X bids, so if this bid is worse than the worst bid we already have, we can skip it
                                continue;

                            // If this bid is better than the worst bid we already have, we need to remove the worst bid to make room for this one
                            result.Bids.Remove(minBidPrice);
                        }

                        level = new CrossOrderbookSnapshotLevel { Price = bid.Price };
                        result.Bids.Add(bid.Price, level);
                    }

                    level.TotalQuantity += bid.Quantity;
                    level.Entries.Add(new CrossOrderBookSnapshotEntry { Exchange = item.Exchange, Entry = bid });
                }
                foreach (var ask in item.Book.asks.Take(exchangeDepth ?? int.MaxValue))
                {
                    if (!result.Asks.TryGetValue(ask.Price, out var level))
                    {
                        if (snapshotDepth != null && result.Asks.Count >= snapshotDepth)
                        {
                            var maxAskPrice = result.Asks.Values.Max(x => x.Price);
                            if (maxAskPrice < ask.Price)
                                // We only want to include the best X asks, so if this ask is worse than the worst ask we already have, we can skip it
                                continue;

                            // If this ask is better than the worst ask we already have, we need to remove the worst ask to make room for this one
                            result.Asks.Remove(maxAskPrice);
                        }

                        level = new CrossOrderbookSnapshotLevel { Price = ask.Price };
                        result.Asks.Add(ask.Price, level);
                    }

                    level.TotalQuantity += ask.Quantity;
                    level.Entries.Add(new CrossOrderBookSnapshotEntry { Exchange = item.Exchange, Entry = ask });
                }
            }

            return result;
        }

        private void BookStatusChange(ISymbolOrderBook book, OrderBookStatus oldStatus, OrderBookStatus newStatus)
        {
            if (newStatus != OrderBookStatus.Synced)
            {
                var bestOffersChange = RemoveBestOffers(book.Exchange);
                if (bestOffersChange.HasValue)
                    OnBestOffersChanged?.Invoke(bestOffersChange.Value);
            }

            OnExchangeStatusChange?.Invoke(book.Exchange, oldStatus, newStatus);

            var newOverallStatus = Status;
            if (newOverallStatus != _lastStatus)
            {
                _lastStatus = newOverallStatus;
                OnStatusChange?.Invoke(newOverallStatus);
            }
        }

        private void BookBestOfferChange(ISymbolOrderBook book, (ISymbolOrderBookEntry BestBid, ISymbolOrderBookEntry BestAsk) bestOffers)
        {
            var bestOffersChange = bestOffers.BestBid.Price == 0 || bestOffers.BestAsk.Price == 0
                ? RemoveBestOffers(book.Exchange)
                : UpdateBestOffers(book.Exchange, bestOffers);

            if (bestOffersChange.HasValue)
                OnBestOffersChanged?.Invoke(bestOffersChange.Value);
        }

        private (CrossOrderBookSnapshotEntry? BestBid, CrossOrderBookSnapshotEntry? BestAsk)? RemoveBestOffers(string exchange)
        {
            lock (_lock)
            {
                _bestAsks.TryRemove(exchange, out _);
                _bestBids.TryRemove(exchange, out _);
                return CheckBestOffers();
            }
        }

        private (CrossOrderBookSnapshotEntry? BestBid, CrossOrderBookSnapshotEntry? BestAsk)? UpdateBestOffers(string exchange, (ISymbolOrderBookEntry BestBid, ISymbolOrderBookEntry BestAsk) bestOffers)
        {
            lock (_lock)
            {
                _bestAsks[exchange] = bestOffers.BestAsk;
                _bestBids[exchange] = bestOffers.BestBid;
                return CheckBestOffers();
            }
        }

        private (CrossOrderBookSnapshotEntry? BestBid, CrossOrderBookSnapshotEntry? BestAsk)? CheckBestOffers()
        {            
            if (_bestAsks.Count == 0 || _bestBids.Count == 0)
            {
                var clearChanged = false;
                if (_lastBestAsk != null && _bestAsks.Count == 0)
                {
                    _lastBestAsk = null;
                    clearChanged = true;
                }
                if (_lastBestBid != null && _bestBids.Count == 0)
                {
                    _lastBestBid = null;
                    clearChanged = true;
                }

                return clearChanged ? (_lastBestBid, _lastBestAsk) : null;
            }

            var changed = false;
            var bestAsk = _bestAsks.OrderBy(x => x.Value.Price).ThenByDescending(x => x.Value.Quantity).First();
            var bestBid = _bestBids.OrderByDescending(x => x.Value.Price).ThenByDescending(x => x.Value.Quantity).First();

            if (_lastBestAsk?.Entry.Price != bestAsk.Value?.Price
                || _lastBestAsk?.Entry.Quantity != bestAsk.Value?.Quantity
                || _lastBestAsk?.Exchange != bestAsk.Key)
            {
                _lastBestAsk = new CrossOrderBookSnapshotEntry { Entry = bestAsk.Value!, Exchange = bestAsk.Key };
                changed = true;
            }

            if (_lastBestBid?.Entry.Price != bestBid.Value?.Price
                || _lastBestBid?.Entry.Quantity != bestBid.Value?.Quantity
                || _lastBestBid?.Exchange != bestBid.Key)
            {
                _lastBestBid = new CrossOrderBookSnapshotEntry { Entry = bestBid.Value!, Exchange = bestBid.Key };
                changed = true;
            }

            return changed ? (_lastBestBid, _lastBestAsk) : null;
        }
    }
}
