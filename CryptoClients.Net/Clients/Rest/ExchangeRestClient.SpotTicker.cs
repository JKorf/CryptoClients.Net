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
        public IEnumerable<ISpotTickerRestClient> GetSpotTickerClients() => _sharedClients.OfType<ISpotTickerRestClient>();
        /// <inheritdoc />
        public ISpotTickerRestClient? GetSpotTickerClient(string exchange) => _sharedClients.OfType<ISpotTickerRestClient>().SingleOrDefault(s => s.Exchange == exchange);


        #region Get Spot Tickers
        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotTicker[]>> GetSpotTickerAsync(string exchange, GetTickersRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotTickersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedSpotTicker[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotTicker[]>[]> GetSpotTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotTickersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedSpotTicker[]>> GetSpotTickersAsyncEnumerable(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotTickersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedSpotTicker[]>>> GetSpotTickersInt(GetTickersRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotTickerClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetSpotTickersOptions.Supported).Select(x => x.GetSpotTickersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Spot Ticker
        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotTicker>> GetSpotTickerAsync(string exchange, GetTickerRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotTickerInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedSpotTicker>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotTicker>[]> GetSpotTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotTickerInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedSpotTicker>> GetSpotTickerAsyncEnumerable(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotTickerInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedSpotTicker>>> GetSpotTickerInt(GetTickerRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotTickerClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetSpotTickerOptions.Supported).Select(x => x.GetSpotTickerAsync(request, ct));
            return tasks;
        }

        #endregion

    }
}
