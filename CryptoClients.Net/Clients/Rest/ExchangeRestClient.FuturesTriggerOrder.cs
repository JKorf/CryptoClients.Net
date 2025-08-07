using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public partial class ExchangeRestClient
    {
        /// <inheritdoc />
        public IEnumerable<IFuturesTriggerOrderRestClient> GetFuturesTriggerOrderClients() => _sharedClients.OfType<IFuturesTriggerOrderRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesTriggerOrderRestClient> GetFuturesTriggerOrderClients(TradingMode api) => _sharedClients.OfType<IFuturesTriggerOrderRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesTriggerOrderRestClient? GetFuturesTriggerOrderClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesTriggerOrderRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Place Futures Trigger Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> PlaceFuturesTriggerOrderAsync(string exchange, PlaceFuturesTriggerOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesTriggerOrderClient(request.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.PlaceFuturesTriggerOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Futures Trigger Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelFuturesTriggerOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesTriggerOrderClient(request.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelFuturesTriggerOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

    }
}
