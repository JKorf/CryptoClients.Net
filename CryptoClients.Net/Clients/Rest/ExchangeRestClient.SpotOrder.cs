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
        public IEnumerable<ISpotOrderRestClient> GetSpotOrderClients() => _sharedClients.OfType<ISpotOrderRestClient>();
        /// <inheritdoc />
        public ISpotOrderRestClient? GetSpotOrderClient(string exchange) => GetSpotOrderClients().SingleOrDefault(s => s.Exchange == exchange);

        #region Place Spot Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> PlaceSpotOrderAsync(string exchange, PlaceSpotOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.PlaceSpotOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder>> GetSpotOrderAsync(string exchange, GetOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedSpotOrder>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetSpotOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Order Trades

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>> GetSpotOrderTradesAsync(string exchange, GetOrderTradesRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedUserTrade[]>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetSpotOrderTradesAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Spot Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelSpotOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetSpotOrderClient(exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelSpotOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Open Orders

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder[]>> GetSpotOpenOrdersAsync(string exchange, GetOpenOrdersRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotOpenOrdersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedSpotOrder[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder[]>[]> GetSpotOpenOrdersAsync(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotOpenOrdersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedSpotOrder[]>> GetSpotOpenOrdersAsyncEnumerable(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotOpenOrdersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedSpotOrder[]>>> GetSpotOpenOrdersInt(GetOpenOrdersRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetOpenSpotOrdersOptions.Supported).Select(x => x.GetOpenSpotOrdersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Closed Orders

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder[]>> GetSpotClosedOrdersAsync(string exchange, GetClosedOrdersRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotClosedOrdersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedSpotOrder[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotOrder[]>[]> GetSpotClosedOrdersAsync(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotClosedOrdersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedSpotOrder[]>> GetSpotClosedOrdersAsyncEnumerable(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotClosedOrdersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedSpotOrder[]>>> GetSpotClosedOrdersInt(GetClosedOrdersRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetClosedSpotOrdersOptions.Supported).Select(x => x.GetClosedSpotOrdersAsync(request, null, ct));
            return tasks;
        }

        #endregion

        #region Get Spot User Trades

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>> GetSpotUserTradesAsync(string exchange, GetUserTradesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotUserTradesInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedUserTrade[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>[]> GetSpotUserTradesAsync(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotUserTradesInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedUserTrade[]>> GetSpotUserTradesAsyncEnumerable(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotUserTradesInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedUserTrade[]>>> GetSpotUserTradesInt(GetUserTradesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetSpotUserTradesOptions.Supported).Select(x => x.GetSpotUserTradesAsync(request, null, ct));
            return tasks;
        }

        #endregion

    }
}
