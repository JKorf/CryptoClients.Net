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
        public IEnumerable<IBalanceSocketClient> GetBalanceClients() => _sharedClients.OfType<IBalanceSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IBalanceSocketClient> GetBalanceClients(TradingMode api) => _sharedClients.OfType<IBalanceSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IBalanceSocketClient? GetBalanceClient(TradingMode api, string exchange) => _sharedClients.OfType<IBalanceSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);


        #region Subscribe Balance

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(
            string exchange,
            SubscribeBalancesRequest request,
            Action<DataEvent<SharedBalance[]>> handler,
            CancellationToken ct = default)
        {
            var result = await SubscribeToBalanceUpdatesAsync(request, handler, new[] { exchange }, ct).ConfigureAwait(false);
            if (result.Length == 0)
                return WebSocketResult.Fail<UpdateSubscription>(exchange, new InvalidOperationError($"Subscription not supported for {exchange}"));

            if (result.Length > 1) {

                foreach (var resultItem in result)
                    _ = resultItem.Data?.CloseAsync();

                return WebSocketResult.Fail<UpdateSubscription>(exchange, new InvalidOperationError($"Multiple subscription available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));
            }

            return result.Single();
        }

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>[]> SubscribeToBalanceUpdatesAsync(
            SubscribeBalancesRequest request,
            Action<DataEvent<SharedBalance[]>> handler,
            IEnumerable<string>? exchanges = null,
            CancellationToken ct = default)
        {
            var clients = GetBalanceClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeBalanceOptions.Supported).Select(x =>
                x.SubscribeToBalanceUpdatesAsync(request, handler, ct));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

    }
}
