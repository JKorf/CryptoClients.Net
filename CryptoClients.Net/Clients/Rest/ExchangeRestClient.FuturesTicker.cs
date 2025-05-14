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
        public IEnumerable<IFuturesTickerRestClient> GetFuturesTickerClients() => _sharedClients.OfType<IFuturesTickerRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesTickerRestClient> GetFuturesTickerClients(TradingMode api) => _sharedClients.OfType<IFuturesTickerRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesTickerRestClient? GetFuturesTickerClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesTickerRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Futures Tickers

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesTicker[]>> GetFuturesTickersAsync(string exchange, GetTickersRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesTickersInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesTicker[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesTicker[]>[]> GetFuturesTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesTickersInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesTicker[]>> GetFuturesTickersAsyncEnumerable(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesTickersInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesTicker[]>>> GetFuturesTickersInt(GetTickersRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesTickerClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFuturesTickersOptions.Supported).Select(x => x.GetFuturesTickersAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Get Futures Ticker

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesTicker>> GetFuturesTickerAsync(string exchange, GetTickerRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesTickerInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesTicker>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesTicker>[]> GetFuturesTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesTickerInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesTicker>> GetFuturesTickerAsyncEnumerable(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesTickerInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesTicker>>> GetFuturesTickerInt(GetTickerRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesTickerClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFuturesTickerOptions.Supported).Select(x => x.GetFuturesTickerAsync(request, ct));
            return tasks;
        }

        #endregion
    }
}
