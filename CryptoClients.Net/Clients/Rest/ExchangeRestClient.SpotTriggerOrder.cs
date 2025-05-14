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
        public IEnumerable<ISpotTriggerOrderRestClient> GetSpotTriggerOrderClients() => _sharedClients.OfType<ISpotTriggerOrderRestClient>();
        /// <inheritdoc />
        public ISpotTriggerOrderRestClient? GetSpotTriggerOrderClient(string exchange) => GetSpotTriggerOrderClients().SingleOrDefault(s => s.Exchange == exchange);

        #region Place Spot Trigger Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> PlaceSpotTriggerOrderAsync(string exchange, PlaceSpotTriggerOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotTriggerOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.PlaceSpotTriggerOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Spot Trigger Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelSpotTriggerOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotTriggerOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelSpotTriggerOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

    }
}
