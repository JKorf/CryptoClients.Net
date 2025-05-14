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
        public IEnumerable<IFuturesSymbolRestClient> GetFuturesSymbolClients() => _sharedClients.OfType<IFuturesSymbolRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesSymbolRestClient> GetFuturesSymbolClients(TradingMode api) => _sharedClients.OfType<IFuturesSymbolRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesSymbolRestClient? GetFuturesSymbolClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesSymbolRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Futures Symbols

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesSymbol[]>> GetFuturesSymbolsAsync(string exchange, GetSymbolsRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesSymbolsInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFuturesSymbol[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesSymbol[]>[]> GetFuturesSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFuturesSymbolsInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFuturesSymbol[]>> GetFuturesSymbolsAsyncEnumerable(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFuturesSymbolsInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFuturesSymbol[]>>> GetFuturesSymbolsInt(GetSymbolsRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFuturesSymbolClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFuturesSymbolsOptions.Supported).Select(x => x.GetFuturesSymbolsAsync(request, ct));
            return tasks;
        }

        #endregion

    }
}
