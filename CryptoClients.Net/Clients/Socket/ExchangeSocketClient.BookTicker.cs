using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public partial class ExchangeSocketClient
    {
        /// <inheritdoc />
        public IEnumerable<IBookTickerSocketClient> GetBookTickerClients() => _sharedClients.OfType<IBookTickerSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IBookTickerSocketClient> GetBookTickerClients(TradingMode api) => _sharedClients.OfType<IBookTickerSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IBookTickerSocketClient? GetBookTickerClient(TradingMode api, string exchange) => _sharedClients.OfType<IBookTickerSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Subscribe Book Ticker

        /// <inheritdoc />
        public async Task<ExchangeResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(
            string exchange,
            SubscribeBookTickerRequest request,
            Action<ExchangeEvent<SharedBookTicker>> handler,
            CancellationToken ct = default)
        {
            var result = await SubscribeToBookTickerUpdatesAsync(request, handler, new[] { exchange }, ct).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeResult<UpdateSubscription>(exchange, new InvalidOperationError($"Subscription not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeResult<UpdateSubscription>[]> SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetBookTickerClients(request.TradingMode);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeBookTickerOptions.Supported).Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToBookTickerUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

    }
}
