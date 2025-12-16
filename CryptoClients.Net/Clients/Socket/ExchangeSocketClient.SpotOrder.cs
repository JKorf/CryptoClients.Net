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
        public IEnumerable<ISpotOrderSocketClient> GetSpotOrderClients() => _sharedClients.OfType<ISpotOrderSocketClient>();
        /// <inheritdoc />
        public ISpotOrderSocketClient? GetSpotOrderClient(string exchange) => _sharedClients.OfType<ISpotOrderSocketClient>().SingleOrDefault(s => s.Exchange == exchange);

        #region Subscribe Spot Order

        /// <inheritdoc />
        public async Task<ExchangeResult<UpdateSubscription>> SubscribeToSpotOrderUpdatesAsync(
            string exchange,
            SubscribeSpotOrderRequest request,
            Action<DataEvent<SharedSpotOrder[]>> handler,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default)
        {
            var result = await SubscribeToSpotOrderUpdatesAsync(request, handler, new[] { exchange }, listenKeyResults, ct).ConfigureAwait(false);
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
        public async Task<ExchangeResult<UpdateSubscription>[]> SubscribeToSpotOrderUpdatesAsync(
            SubscribeSpotOrderRequest request,
            Action<DataEvent<SharedSpotOrder[]>> handler,
            IEnumerable<string>? exchanges = null,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeSpotOrderOptions.Supported).Select(x => Task.Run(async () =>
            {
                var listenKey = request.ListenKey;
                if (listenKey == null && listenKeyResults != null)
                    listenKey = listenKeyResults.Where(x => x.Success).FirstOrDefault(lk => lk.Exchange == x.Exchange && lk.DataTradeMode!.Contains(TradingMode.Spot))?.Data;
                if (listenKey == null)
                    listenKey = ExchangeParameters.GetValue<string>(request.ExchangeParameters, x.Exchange, nameof(SubscribeBalancesRequest.ListenKey));

                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToSpotOrderUpdatesAsync(request with { ListenKey = listenKey }, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

    }
}
