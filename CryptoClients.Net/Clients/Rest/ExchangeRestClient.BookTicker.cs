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
        public IEnumerable<IBookTickerRestClient> GetBookTickerClients() => _sharedClients.OfType<IBookTickerRestClient>();
        /// <inheritdoc />
        public IEnumerable<IBookTickerRestClient> GetBookTickerClients(TradingMode api) => _sharedClients.OfType<IBookTickerRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IBookTickerRestClient? GetBookTickerClient(TradingMode api, string exchange) => _sharedClients.OfType<IBookTickerRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);


        #region Get Book Tickers 

        /// <inheritdoc />
        public async Task<HttpResult<SharedBookTicker>> GetBookTickerAsync(string exchange, GetBookTickerRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetBookTickersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return HttpResult.Fail<SharedBookTicker>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

            return result.SingleOrDefault() ?? HttpResult.Fail<SharedBookTicker>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<HttpResult<SharedBookTicker>[]> GetBookTickersAsync(GetBookTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetBookTickersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<HttpResult<SharedBookTicker>> GetBookTickersAsyncEnumerable(GetBookTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetBookTickersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<HttpResult<SharedBookTicker>>> GetBookTickersInt(GetBookTickerRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetBookTickerClients().Where(x => x.SupportedTradingModes.Contains(request.TradingMode!.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetBookTickerOptions.Supported).Select(x => x.GetBookTickerAsync(request, ct)).ToList();
            return tasks;
        }

        #endregion

    }
}
