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
        public IEnumerable<IFuturesOrderManagementSocketClient> GetFuturesOrderManagementClients() => _sharedClients.OfType<IFuturesOrderManagementSocketClient>();
        /// <inheritdoc />
        public IFuturesOrderManagementSocketClient? GetFuturesOrderManagementClient(TradingMode tradingMode, string exchange) => GetSharedClients(exchange).OfType<IFuturesOrderManagementSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(tradingMode));

        #region Place Futures Order

        /// <inheritdoc />
        public async Task<QueryResult<SharedId>> PlaceFuturesOrderAsync(string exchange, PlaceFuturesOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderManagementClient(request.Symbol!.TradingMode, exchange);
            if (client == null)
                return QueryResult.Fail<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.PlaceFuturesOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Futures Order

        /// <inheritdoc />
        public async Task<QueryResult<SharedId>> CancelFuturesOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderManagementClient(request.Symbol!.TradingMode, exchange);
            if (client == null)
                return QueryResult.Fail<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelFuturesOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

    }
}
