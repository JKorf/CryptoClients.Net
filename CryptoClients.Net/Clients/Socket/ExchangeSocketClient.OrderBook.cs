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
        public IEnumerable<IOrderBookSocketClient> GetOrderBookClients() => _sharedClients.OfType<IOrderBookSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IOrderBookSocketClient> GetOrderBookClients(TradingMode api) => _sharedClients.OfType<IOrderBookSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IOrderBookSocketClient? GetOrderBookClient(TradingMode api, string exchange) => _sharedClients.OfType<IOrderBookSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Subscribe Order Book

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(
            string exchange,
            SubscribeOrderBookRequest request,
            Action<DataEvent<SharedOrderBook>> handler,
            CancellationToken ct = default)
        {
            var result = await SubscribeToOrderBookUpdatesAsync(request, handler, new[] { exchange }, ct).ConfigureAwait(false);
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
        public async Task<WebSocketResult<UpdateSubscription>[]> SubscribeToOrderBookUpdatesAsync(SubscribeOrderBookRequest request, Action<DataEvent<SharedOrderBook>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetOrderBookClients(request.TradingMode!.Value);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeOrderBookOptions.Supported).Select(x =>
                x.SubscribeToOrderBookUpdatesAsync(request, handler, ct));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

    }
}
