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
        public IEnumerable<ISpotSymbolRestClient> GetSpotSymbolClients() => _sharedClients.OfType<ISpotSymbolRestClient>();
        /// <inheritdoc />
        public ISpotSymbolRestClient? GetSpotSymbolClient(string exchange) => GetSpotSymbolClients().SingleOrDefault(s => s.Exchange == exchange);

        #region Get Spot Symbols
        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotSymbol[]>> GetSpotSymbolsAsync(string exchange, GetSymbolsRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetSpotSymbolsInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedSpotSymbol[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedSpotSymbol[]>[]> GetSpotSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetSpotSymbolsInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedSpotSymbol[]>> GetSpotSymbolsAsyncEnumerable(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetSpotSymbolsInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedSpotSymbol[]>>> GetSpotSymbolsInt(GetSymbolsRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetSpotSymbolClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetSpotSymbolsOptions.Supported).Select(x => x.GetSpotSymbolsAsync(request, ct));
            return tasks;
        }

        #endregion

    }
}
