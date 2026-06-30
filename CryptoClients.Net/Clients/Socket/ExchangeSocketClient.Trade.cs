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
        public IEnumerable<ITradeSocketClient> GetTradeClients() => _sharedClients.OfType<ITradeSocketClient>();
        /// <inheritdoc />
        public IEnumerable<ITradeSocketClient> GetTradeClients(TradingMode api) => _sharedClients.OfType<ITradeSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public ITradeSocketClient? GetTradeClient(TradingMode api, string exchange) => _sharedClients.OfType<ITradeSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Subscribe Trade

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(
            string exchange,
            SubscribeTradeRequest request,
            Action<DataEvent<SharedTrade[]>> handler,
            CancellationToken ct = default)
        {
            var result = await SubscribeToTradeUpdatesAsync(request, handler, new[] { exchange }, ct).ConfigureAwait(false);
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
        public async Task<WebSocketResult<UpdateSubscription>[]> SubscribeToTradeUpdatesAsync(SubscribeTradeRequest request, Action<DataEvent<SharedTrade[]>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetTradeClients(request.TradingMode!.Value);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeTradeOptions.Supported).Select(x =>
                x.SubscribeToTradeUpdatesAsync(request, handler, ct));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

    }
}
