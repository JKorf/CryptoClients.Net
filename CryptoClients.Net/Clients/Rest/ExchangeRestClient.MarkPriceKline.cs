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
        public IEnumerable<IMarkPriceKlineRestClient> GetMarkPriceKlineClients() => _sharedClients.OfType<IMarkPriceKlineRestClient>();
        /// <inheritdoc />
        public IEnumerable<IMarkPriceKlineRestClient> GetMarkPriceKlineClients(TradingMode api) => _sharedClients.OfType<IMarkPriceKlineRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IMarkPriceKlineRestClient? GetMarkPriceKlineClient(TradingMode api, string exchange) => _sharedClients.OfType<IMarkPriceKlineRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);


        #region Get Mark Price Klines

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesKline[]>> GetMarkPriceKlinesAsync(string exchange, GetKlinesRequest request, PageRequest? pageRequest = null, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetMarkPriceKlinesIntAsync(request, new[] { exchange }, pageRequest, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return new ExchangeWebResult<SharedFuturesKline[]>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesKline[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesKline[]>[]> GetMarkPriceKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetMarkPriceKlinesIntAsync(request, exchanges, null, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesKline[]>> GetMarkPriceKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetMarkPriceKlinesIntAsync(request, exchanges, null, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesKline[]>>> GetMarkPriceKlinesIntAsync(GetKlinesRequest request, IEnumerable<string>? exchanges, PageRequest? pageRequest, CancellationToken ct)
        {
            var clients = GetMarkPriceKlineClients().Where(x => x.SupportedTradingModes.Contains(request.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetMarkPriceKlinesOptions.Supported).Select(x => x.GetMarkPriceKlinesAsync(request, pageRequest, ct));
            return tasks;
        }

        #endregion

    }
}
