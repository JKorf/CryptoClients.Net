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
        public IEnumerable<IFuturesOrderSocketClient> GetFuturesOrderClients() => _sharedClients.OfType<IFuturesOrderSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesOrderSocketClient> GetFuturesOrderClients(TradingMode api) => _sharedClients.OfType<IFuturesOrderSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesOrderSocketClient? GetFuturesOrderClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesOrderSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Subscribe Futures Order

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToFuturesOrderUpdatesAsync(
            string exchange,
            SubscribeFuturesOrderRequest request,
            Action<DataEvent<SharedFuturesOrder[]>> handler,
            CancellationToken ct = default)
        {
            var result = await SubscribeToFuturesOrderUpdatesAsync(request, handler, new[] { exchange }, ct).ConfigureAwait(false);
            if (result.Length == 0)
                return WebSocketResult.Fail<UpdateSubscription>(exchange, new InvalidOperationError($"Subscription not supported for {exchange}"));

            if (result.Length > 1)
            {

                foreach (var resultItem in result)
                    _ = resultItem.Data?.CloseAsync();

                return WebSocketResult.Fail<UpdateSubscription>(exchange, new InvalidOperationError($"Multiple subscription available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));
            }

            return result.Single();
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>[]> SubscribeToFuturesOrderUpdatesAsync(
            SubscribeFuturesOrderRequest request,
            Action<DataEvent<SharedFuturesOrder[]>> handler,
            IEnumerable<string>? exchanges = null,
            CancellationToken ct = default)
        {
            var clients = GetFuturesOrderClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeFuturesOrderOptions.Supported).Select(x =>
                x.SubscribeToFuturesOrderUpdatesAsync(request, handler, ct));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

    }
}
