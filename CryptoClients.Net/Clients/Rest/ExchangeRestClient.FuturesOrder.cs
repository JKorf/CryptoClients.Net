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
    {/// <inheritdoc />
        public IEnumerable<IFuturesOrderRestClient> GetFuturesOrderClients() => _sharedClients.OfType<IFuturesOrderRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesOrderRestClient> GetFuturesOrderClients(TradingMode api) => _sharedClients.OfType<IFuturesOrderRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesOrderRestClient? GetFuturesOrderClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesOrderRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Place Futures Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> PlaceFuturesOrderAsync(string exchange, PlaceFuturesOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClient(request.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.PlaceFuturesOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Futures Open Orders

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesOpenOrdersAsync(string exchange, GetOpenOrdersRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesOpenOrdersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return new ExchangeWebResult<SharedFuturesOrder[]>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesOrder[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder[]>[]> GetFuturesOpenOrdersAsync(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesOpenOrdersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesOpenOrdersAsyncEnumerable(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesOpenOrdersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesOrder[]>>> GetFuturesOpenOrdersInt(GetOpenOrdersRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetOpenFuturesOrdersOptions.Supported).Select(x => x.GetOpenFuturesOrdersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Closed Orders

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesClosedOrdersAsync(string exchange, GetClosedOrdersRequest request, PageRequest? pageRequest = null, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesClosedOrdersInt(request, new[] { exchange }, pageRequest, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return new ExchangeWebResult<SharedFuturesOrder[]>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesOrder[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder[]>[]> GetFuturesClosedOrdersAsync(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesClosedOrdersInt(request, exchanges, null, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesClosedOrdersAsyncEnumerable(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesClosedOrdersInt(request, exchanges, null, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesOrder[]>>> GetFuturesClosedOrdersInt(GetClosedOrdersRequest request, IEnumerable<string>? exchanges, PageRequest? pageRequest, CancellationToken ct)
        {
            var clients = GetFuturesOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetClosedFuturesOrdersOptions.Supported).Select(x => x.GetClosedFuturesOrdersAsync(request, pageRequest, ct));
            return tasks;
        }

        #endregion

        #region Get Futures User Trades

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>> GetFuturesUserTradesAsync(string exchange, GetUserTradesRequest request, PageRequest? pageRequest = null, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesUserTradesInt(request, new[] { exchange }, pageRequest, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return new ExchangeWebResult<SharedUserTrade[]>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedUserTrade[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>[]> GetFuturesUserTradesAsync(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesUserTradesInt(request, exchanges, null, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedUserTrade[]>> GetFuturesUserTradesAsyncEnumerable(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesUserTradesInt(request, exchanges, null, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedUserTrade[]>>> GetFuturesUserTradesInt(GetUserTradesRequest request, IEnumerable<string>? exchanges, PageRequest? pageRequest, CancellationToken ct)
        {
            var clients = GetFuturesOrderClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFuturesUserTradesOptions.Supported).Select(x => x.GetFuturesUserTradesAsync(request, pageRequest, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder>> GetFuturesOrderAsync(string exchange, GetOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClient(request.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedFuturesOrder>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetFuturesOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Futures Order Trades

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedUserTrade[]>> GetFuturesOrderTradesAsync(string exchange, GetOrderTradesRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClient(request.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedUserTrade[]>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetFuturesOrderTradesAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Futures Order

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelFuturesOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClient(request.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelFuturesOrderAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Close Position

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> ClosePositionAsync(string exchange, ClosePositionRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClient(request.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.ClosePositionAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Futures Positions

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedPosition[]>> GetPositionsAsync(string exchange, GetPositionsRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetPositionsInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return new ExchangeWebResult<SharedPosition[]>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedPosition[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedPosition[]>[]> GetPositionsAsync(GetPositionsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetPositionsInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedPosition[]>> GetPositionsAsyncEnumerable(GetPositionsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetPositionsInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedPosition[]>>> GetPositionsInt(GetPositionsRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var tradingMode = request.TradingMode ?? request.Symbol?.TradingMode;
            var clients = tradingMode == null ? GetFuturesOrderClients() : GetFuturesOrderClients(tradingMode.Value);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetPositionsOptions.Supported).Select(x => x.GetPositionsAsync(request, ct));
            return tasks;
        }

        #endregion
    }
}
