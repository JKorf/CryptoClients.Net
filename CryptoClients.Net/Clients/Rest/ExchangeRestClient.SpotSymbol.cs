using CryptoExchange.Net;
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

        /// <inheritdoc />
        public async Task<ExchangeResult<SharedSymbol[]>> GetSpotSymbolsForBaseAssetAsync(string exchange, string baseAsset)
        {
            var client = GetSpotSymbolClients().SingleOrDefault(x => x.Exchange == exchange);
            if (client == null)
                return new ExchangeResult<SharedSymbol[]>(exchange, ArgumentError.Invalid(nameof(exchange), "Exchange client not found"));

            return await client.GetSpotSymbolsForBaseAssetAsync(baseAsset).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Dictionary<string, SharedSymbol[]>> GetSpotSymbolsForBaseAssetAsync(string baseAsset)
        {
            var clients = GetSpotSymbolClients();
            var supportsTask = clients.Select(x => x.GetSpotSymbolsForBaseAssetAsync(baseAsset)).ToArray();
            await Task.WhenAll(supportsTask).ConfigureAwait(false);

            return supportsTask.Where(x => x.Result.Success).ToDictionary(x => x.Result.Exchange, x => x.Result.Data);
        }

        /// <inheritdoc />
        public async Task<string[]> GetExchangesSupportingSpotSymbolAsync(SharedSymbol symbol)
        {
            var clients = GetSpotSymbolClients();
            var supportsTask = clients.Select(x => x.SupportsSpotSymbolAsync(symbol)).ToArray();
            await Task.WhenAll(supportsTask).ConfigureAwait(false);

            return supportsTask.Where(x => x.Result.Data).Select(x => x.Result.Exchange).ToArray();
        }

        /// <inheritdoc />
        public async Task<string[]> GetExchangesSupportingSpotSymbolAsync(string symbolName)
        {
            var clients = GetSpotSymbolClients();
            var supportsTask = clients.Select(x => x.SupportsSpotSymbolAsync(symbolName)).ToArray();
            await Task.WhenAll(supportsTask).ConfigureAwait(false);

            return supportsTask.Where(x => x.Result.Data).Select(x => x.Result.Exchange).ToArray();
        }

        /// <inheritdoc />
        public async Task<ExchangeResult<bool>> SupportsSpotSymbolAsync(string exchange, SharedSymbol symbol)
        {
            var client = GetSpotSymbolClients().SingleOrDefault(x => x.Exchange == exchange);
            if (client == null)
                return new ExchangeResult<bool>(exchange, ArgumentError.Invalid(nameof(exchange), "Exchange client not found"));

            return await client.SupportsSpotSymbolAsync(symbol).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<ExchangeResult<bool>> SupportsSpotSymbolAsync(string exchange, string symbolName)
        {
            var client = GetSpotSymbolClients().SingleOrDefault(x => x.Exchange == exchange);
            if (client == null)
                return new ExchangeResult<bool>(exchange, ArgumentError.Invalid(nameof(exchange), "Exchange client not found"));

            return await client.SupportsSpotSymbolAsync(symbolName).ConfigureAwait(false);
        }

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
