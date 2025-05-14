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
        public IEnumerable<ISpotOrderClientIdRestClient> GetSpotOrderClientIdClients() => _sharedClients.OfType<ISpotOrderClientIdRestClient>();
        /// <inheritdoc />
        public ISpotOrderClientIdRestClient? GetSpotOrderClientIdClient(string exchange) => GetSpotOrderClientIdClients().SingleOrDefault(s => s.Exchange == exchange);


        #region Cancel Spot Order By Client Order Id

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelSpotOrderByClientOrderIdAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClientIdClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelSpotOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Order By Client Order Id

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder>> GetSpotOrderByClientOrderIdAsync(string exchange, GetOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClientIdClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedSpotOrder>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetSpotOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);
        }

        #endregion
    }
}
