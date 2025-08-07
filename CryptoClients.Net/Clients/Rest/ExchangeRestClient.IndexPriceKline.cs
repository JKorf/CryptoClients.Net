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
        public IEnumerable<IIndexPriceKlineRestClient> GetIndexPriceKlineClients() => _sharedClients.OfType<IIndexPriceKlineRestClient>();
        /// <inheritdoc />
        public IEnumerable<IIndexPriceKlineRestClient> GetIndexPriceKlineClients(TradingMode api) => _sharedClients.OfType<IIndexPriceKlineRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IIndexPriceKlineRestClient? GetIndexPriceKlineClient(TradingMode api, string exchange) => _sharedClients.OfType<IIndexPriceKlineRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Index Price Klines

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesKline[]>> GetIndexPriceKlinesAsync(string exchange, GetKlinesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetIndexPriceKlinesIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesKline[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesKline[]>[]> GetIndexPriceKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetIndexPriceKlinesIntAsync(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesKline[]>> GetIndexPriceKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetIndexPriceKlinesIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesKline[]>>> GetIndexPriceKlinesIntAsync(GetKlinesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetIndexPriceKlineClients().Where(x => x.SupportedTradingModes.Contains(request.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetIndexPriceKlinesOptions.Supported).Select(x => x.GetIndexPriceKlinesAsync(request, null, ct));
            return tasks;
        }

        #endregion

    }
}
