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
        public IEnumerable<ITickerSocketClient> GetTickerClients() => _sharedClients.OfType<ITickerSocketClient>();
        /// <inheritdoc />
        public IEnumerable<ITickerSocketClient> GetTickerClients(TradingMode api) => _sharedClients.OfType<ITickerSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public ITickerSocketClient? GetTickerClient(TradingMode api, string exchange) => _sharedClients.OfType<ITickerSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Subscribe Ticker

        /// <inheritdoc />
        public async Task<ExchangeResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(
            string exchange,
            SubscribeTickerRequest request,
            Action<ExchangeEvent<SharedSpotTicker>> handler,
            CancellationToken ct = default)
        {
            var result = await SubscribeToTickerUpdatesAsync(request, handler, new[] { exchange }, ct).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeResult<UpdateSubscription>(exchange, new InvalidOperationError($"Subscription not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeResult<UpdateSubscription>[]> SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetTickerClients(request.Symbol.TradingMode);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeTickerOptions.Supported).Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToTickerUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

    }
}
