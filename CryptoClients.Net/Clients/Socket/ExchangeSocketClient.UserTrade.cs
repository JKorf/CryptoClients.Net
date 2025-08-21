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
        public IEnumerable<IUserTradeSocketClient> GetUserTradeClients() => _sharedClients.OfType<IUserTradeSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IUserTradeSocketClient> GetUserTradeClients(TradingMode api) => _sharedClients.OfType<IUserTradeSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IUserTradeSocketClient? GetUserTradeClient(TradingMode api, string exchange) => _sharedClients.OfType<IUserTradeSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Subscribe User Trade

        /// <inheritdoc />
        public async Task<ExchangeResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(
            string exchange,
            SubscribeUserTradeRequest request,
            Action<ExchangeEvent<SharedUserTrade[]>> handler,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default)
        {
            var result = await SubscribeToUserTradeUpdatesAsync(request, handler, new[] { exchange }, listenKeyResults, ct).ConfigureAwait(false);
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
        public async Task<ExchangeResult<UpdateSubscription>[]> SubscribeToUserTradeUpdatesAsync(
            SubscribeUserTradeRequest request,
            Action<ExchangeEvent<SharedUserTrade[]>> handler,
            IEnumerable<string>? exchanges = null,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default)
        {
            var clients = GetUserTradeClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeUserTradeOptions.Supported).Select(x => Task.Run(async () =>
            {
                var listenKey = request.ListenKey;
                if (listenKey == null && listenKeyResults != null)
                    listenKey = listenKeyResults.Where(x => x.Success).FirstOrDefault(lk => lk.Exchange == x.Exchange && (request.TradingMode.HasValue ? lk.DataTradeMode!.Contains(request.TradingMode.Value) : lk.DataTradeMode!.Any(tm => x.SupportedTradingModes.Contains(tm))))?.Data;
                if (listenKey == null)
                    listenKey = ExchangeParameters.GetValue<string>(request.ExchangeParameters, x.Exchange, nameof(SubscribeBalancesRequest.ListenKey));

                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToUserTradeUpdatesAsync(request with { ListenKey = listenKey }, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion
    }
}
