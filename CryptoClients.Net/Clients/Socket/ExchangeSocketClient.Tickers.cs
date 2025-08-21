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
        public IEnumerable<ITickersSocketClient> GetTickersClients() => _sharedClients.OfType<ITickersSocketClient>();
        /// <inheritdoc />
        public IEnumerable<ITickersSocketClient> GetTickersClients(TradingMode api) => _sharedClients.OfType<ITickersSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public ITickersSocketClient? GetTickersClient(TradingMode api, string exchange) => _sharedClients.OfType<ITickersSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Subscribe All Ticker

        /// <inheritdoc />
        public async Task<ExchangeResult<UpdateSubscription>> SubscribeToAllTickerUpdatesAsync(
            string exchange,
            SubscribeAllTickersRequest request,
            Action<ExchangeEvent<SharedSpotTicker[]>> handler,
            CancellationToken ct = default)
        {
            var result = await SubscribeToAllTickerUpdatesAsync(request, handler, new[] { exchange }, ct).ConfigureAwait(false);
            if (result.Length == 0)
                return new ExchangeResult<UpdateSubscription>(exchange, new InvalidOperationError($"Subscription not supported for {exchange}"));

            if (result.Length > 1)
            {

                foreach (var resultItem in result)
                    _ = resultItem.Data?.CloseAsync();

                return new ExchangeResult<UpdateSubscription>(exchange, new InvalidOperationError($"Multiple subscription available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));
            }

            return result.Single();
        }

        /// <inheritdoc />
        public async Task<ExchangeResult<UpdateSubscription>[]> SubscribeToAllTickerUpdatesAsync(SubscribeAllTickersRequest request, Action<ExchangeEvent<SharedSpotTicker[]>> handler, IEnumerable<string>? exchanges, CancellationToken ct = default)
        {
            var clients = GetTickersClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeAllTickersOptions.Supported).Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToAllTickersUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion
    }
}
