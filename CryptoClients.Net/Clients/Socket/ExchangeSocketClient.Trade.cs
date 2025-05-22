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
        public async Task<ExchangeResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(
            string exchange,
            SubscribeTradeRequest request,
            Action<ExchangeEvent<SharedTrade[]>> handler,
            CancellationToken ct = default)
        {
            var result = await SubscribeToTradeUpdatesAsync(request, handler, new[] { exchange }, ct).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeResult<UpdateSubscription>(exchange, new InvalidOperationError($"Subscription not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeResult<UpdateSubscription>[]> SubscribeToTradeUpdatesAsync(SubscribeTradeRequest request, Action<ExchangeEvent<SharedTrade[]>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetTradeClients(request.Symbol.TradingMode);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeTradeOptions.Supported).Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToTradeUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

    }
}
