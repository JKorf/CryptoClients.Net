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
        public IEnumerable<IPositionSocketClient> GetPositionClients() => _sharedClients.OfType<IPositionSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IPositionSocketClient> GetPositionClients(TradingMode api) => _sharedClients.OfType<IPositionSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IPositionSocketClient? GetPositionClient(TradingMode api, string exchange) => _sharedClients.OfType<IPositionSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Subscribe Position

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(
            string exchange,
            SubscribePositionRequest request,
            Action<DataEvent<SharedPosition[]>> handler,
            CancellationToken ct = default)
        {
            var result = await SubscribeToPositionUpdatesAsync(request, handler, new[] { exchange }, ct).ConfigureAwait(false);
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
        public async Task<WebSocketResult<UpdateSubscription>[]> SubscribeToPositionUpdatesAsync(
            SubscribePositionRequest request,
            Action<DataEvent<SharedPosition[]>> handler,
            IEnumerable<string>? exchanges = null,
            CancellationToken ct = default)
        {
            var clients = GetPositionClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribePositionOptions.Supported).Select(x =>
                x.SubscribeToPositionUpdatesAsync(request, handler, ct));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion
    }
}
