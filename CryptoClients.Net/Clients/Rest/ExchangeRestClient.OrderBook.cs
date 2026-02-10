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
        public IEnumerable<IOrderBookRestClient> GetOrderBookClients() => _sharedClients.OfType<IOrderBookRestClient>();
        /// <inheritdoc />
        public IEnumerable<IOrderBookRestClient> GetOrderBookClients(TradingMode api) => _sharedClients.OfType<IOrderBookRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IOrderBookRestClient? GetOrderBookClient(TradingMode api, string exchange) => _sharedClients.OfType<IOrderBookRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Order Book

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedOrderBook>> GetOrderBookAsync(string exchange, GetOrderBookRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetOrderBookInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return new ExchangeWebResult<SharedOrderBook>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedOrderBook>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedOrderBook>[]> GetOrderBookAsync(GetOrderBookRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetOrderBookInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedOrderBook>> GetOrderBookAsyncEnumerable(GetOrderBookRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetOrderBookInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedOrderBook>>> GetOrderBookInt(GetOrderBookRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetOrderBookClients().Where(x => x.SupportedTradingModes.Contains(request.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetOrderBookOptions.Supported).Select(x => x.GetOrderBookAsync(request, ct));
            return tasks;
        }

        #endregion

    }
}
