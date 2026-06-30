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
        public IEnumerable<IKlineSocketClient> GetKlineClients() => _sharedClients.OfType<IKlineSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IKlineSocketClient> GetKlineClients(TradingMode api) => _sharedClients.OfType<IKlineSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IKlineSocketClient? GetKlineClient(TradingMode api, string exchange) => _sharedClients.OfType<IKlineSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);


        #region Subscribe Kline

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(
            string exchange,
            SubscribeKlineRequest request,
            Action<DataEvent<SharedKline>> handler,
            CancellationToken ct = default)
        {
            var result = await SubscribeToKlineUpdatesAsync(request, handler, new[] { exchange }, ct).ConfigureAwait(false);
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
        public async Task<WebSocketResult<UpdateSubscription>[]> SubscribeToKlineUpdatesAsync(SubscribeKlineRequest request, Action<DataEvent<SharedKline>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetKlineClients(request.TradingMode!.Value);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeKlineOptions.Supported).Select(x =>
                x.SubscribeToKlineUpdatesAsync(request, handler, ct));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

    }
}
