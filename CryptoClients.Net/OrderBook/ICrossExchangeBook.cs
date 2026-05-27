using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoClients.Net.OrderBook
{
    /// <summary>
    /// Order book for a symbol across multiple exchanges. This will aggregate the data from multiple order books for the same symbol across different exchanges and provide a single order book
    /// </summary>
    public interface ICrossExchangeBook
    {
        /// <summary>
        /// The exchanges for this book
        /// </summary>
        string[] Exchanges { get; }
        /// <summary>
        /// The current sync status per exchange
        /// </summary>
        Dictionary<string, OrderBookStatus> ExchangeStatus { get; }
        /// <summary>
        /// The exchange order books this cross exchange book is using
        /// </summary>
        ISymbolOrderBook[] ExchangeBooks { get; }
        /// <summary>
        /// Timestamp of when the last update was applied to any of the order books, local time
        /// </summary>
        DateTime UpdateTime { get; }
        /// <summary>
        /// Timestamp of the last event that was applied to any of the order books, server time
        /// </summary>
        DateTime? UpdateServerTime { get; }
        /// <summary>
        /// Timestamp of the last event that was applied to any of the order books, in local time, estimated based on timestamp difference between client and server
        /// </summary>
        DateTime? UpdateLocalTime { get; }
        /// <summary>
        /// Age of the data, in local time, estimated based on timestamp difference between client and server + the period since last update
        /// </summary>
        TimeSpan? DataAge { get; }
        /// <summary>
        /// The configured minimal depth of each exchange book
        /// </summary>
        int? MinimalDepth { get; }
        /// <summary>
        /// The current spread between the best bid and ask
        /// </summary>
        decimal Spread { get; }
        /// <summary>
        /// The current spread between the best bid and ask, in percentage
        /// </summary>
        decimal SpreadPercentage { get; }
        /// <summary>
        /// The best bid currently available across all exchange books
        /// </summary>
        CrossOrderBookSnapshotEntry? BestBid { get; }
        /// <summary>
        /// The best ask currently available across all exchange books
        /// </summary>
        CrossOrderBookSnapshotEntry? BestAsk { get; }
        /// <summary>
        /// The best bid and ask currently available across all exchange books
        /// </summary>
        (CrossOrderBookSnapshotEntry? Bid, CrossOrderBookSnapshotEntry? Ask) BestOffers { get; }
        /// <summary>
        /// The current order book status
        /// </summary>
        CrossExchangeBookStatus Status { get; }
        /// <summary>
        /// The symbol the book is for
        /// </summary>
        SharedSymbol Symbol { get; }

        /// <summary>
        /// On best offer change. Provides the new best bid and ask, along with the exchange they are from.
        /// </summary>
        event Action<(CrossOrderBookSnapshotEntry? BestBid, CrossOrderBookSnapshotEntry? BestAsk)>? OnBestOffersChanged;
        /// <summary>
        /// On exchange status change. Provides the exchange, the old status and the new status.
        /// </summary>
        event Action<string, OrderBookStatus, OrderBookStatus>? OnExchangeStatusChange;
        /// <summary>
        /// On book status change. Provides the new status.
        /// </summary>
        event Action<CrossExchangeBookStatus>? OnStatusChange;

        /// <summary>
        /// Get a snapshot of the current book data
        /// </summary>
        /// <param name="snapshotDepth">The number of levels to include in the snapshot</param>
        /// <param name="exchangeDepth">The number of levels to consider for each exchange book</param>
        /// <returns></returns>
        CrossOrderBookSnapshot Snapshot(int? snapshotDepth = null, int? exchangeDepth = null);
        /// <summary>
        /// Start the book. Note that this will fail if any of the underlying books fail to start.
        /// </summary>
        /// <returns></returns>
        Task<CallResult> StartAsync();
        /// <summary>
        /// Stop the book syncing
        /// </summary>
        /// <returns></returns>
        Task StopAsync();
    }
}
