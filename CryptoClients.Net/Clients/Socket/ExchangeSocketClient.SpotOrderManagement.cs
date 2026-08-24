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
        public IEnumerable<ISpotOrderManagementSocketClient> GetSpotOrderManagementClients() => _sharedClients.OfType<ISpotOrderManagementSocketClient>();
        /// <inheritdoc />
        public ISpotOrderManagementSocketClient? GetSpotOrderManagementClient(string exchange) => GetSharedClients(exchange).OfType<ISpotOrderManagementSocketClient>().SingleOrDefault();

        #region Place Spot Order

        /// <inheritdoc />
        public async Task<QueryResult<SharedId>> PlaceSpotOrderAsync(string exchange, PlaceSpotOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderManagementClient(exchange);
            if (client == null)
                return QueryResult.Fail<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.PlaceSpotOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Spot Order

        /// <inheritdoc />
        public async Task<QueryResult<SharedId>> CancelSpotOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderManagementClient(exchange);
            if (client == null)
                return QueryResult.Fail<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelSpotOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

    }
}
