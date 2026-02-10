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

        /// <inheritdoc />
        public async Task<ExchangeResult<SharedSymbol[]>> GetFuturesSymbolsForBaseAssetAsync(string exchange, string baseAsset)
        {
            var clients = GetFuturesSymbolClients().Where(x => x.Exchange == exchange).ToArray();
            if (clients.Length == 0)
                return new ExchangeResult<SharedSymbol[]>(exchange, ArgumentError.Invalid(nameof(exchange), "Exchange client not found"));

            var supportsTask = clients.Select(x => x.GetFuturesSymbolsForBaseAssetAsync(baseAsset)).ToArray();
            await Task.WhenAll(supportsTask).ConfigureAwait(false);
            var failedResult = supportsTask.FirstOrDefault(x => !x.Result.Success);
            if (failedResult != null)
                return new ExchangeResult<SharedSymbol[]>(exchange, failedResult.Result.Error!);

            return new ExchangeResult<SharedSymbol[]>(exchange, supportsTask.SelectMany(x => x.Result.Data).ToArray());
        }

        /// <inheritdoc />
        public async Task<Dictionary<string, SharedSymbol[]>> GetFuturesSymbolsForBaseAssetAsync(string baseAsset)
        {
            var clients = GetFuturesSymbolClients();
            var supportsTask = clients.Select(x => x.GetFuturesSymbolsForBaseAssetAsync(baseAsset)).ToArray();
            await Task.WhenAll(supportsTask).ConfigureAwait(false);

            return supportsTask
                .Where(x => x.Result.Success)
                .GroupBy(x => x.Result.Exchange)
                .ToDictionary(x => x.Key, x => x.SelectMany(x => x.Result.Data)
                .ToArray());
        }

        /// <inheritdoc />
        public async Task<string[]> GetExchangesSupportingFuturesSymbolAsync(SharedSymbol symbol)
        {
            var clients = GetFuturesSymbolClients();
            var supportsTask = clients.Select(x => x.SupportsFuturesSymbolAsync(symbol)).ToArray();
            await Task.WhenAll(supportsTask).ConfigureAwait(false);

            return supportsTask.Where(x => x.Result.Data).Select(x => x.Result.Exchange).Distinct().ToArray();
        }

        /// <inheritdoc />
        public async Task<string[]> GetExchangesSupportingFuturesSymbolAsync(string symbolName)
        {
            var clients = GetFuturesSymbolClients();
            var supportsTask = clients.Select(x => x.SupportsFuturesSymbolAsync(symbolName)).ToArray();
            await Task.WhenAll(supportsTask).ConfigureAwait(false);

            return supportsTask.Where(x => x.Result.Data).Select(x => x.Result.Exchange).Distinct().ToArray();
        }

        /// <inheritdoc />
        public async Task<ExchangeResult<bool>> SupportsFuturesSymbolAsync(string exchange, SharedSymbol symbol)
        {
            var client = GetFuturesSymbolClients().SingleOrDefault(x => x.Exchange == exchange);
            if (client == null)
                return new ExchangeResult<bool>(exchange, ArgumentError.Invalid(nameof(exchange), "Exchange client not found"));

            return await client.SupportsFuturesSymbolAsync(symbol).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<ExchangeResult<bool>> SupportsFuturesSymbolAsync(string exchange, string symbolName)
        {
            var client = GetFuturesSymbolClients().SingleOrDefault(x => x.Exchange == exchange);
            if (client == null)
                return new ExchangeResult<bool>(exchange, ArgumentError.Invalid(nameof(exchange), "Exchange client not found"));

            return await client.SupportsFuturesSymbolAsync(symbolName).ConfigureAwait(false);

        }

        #region Get Futures Symbols

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesSymbol[]>> GetFuturesSymbolsAsync(string exchange, GetSymbolsRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFuturesSymbolsInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return new ExchangeWebResult<SharedFuturesSymbol[]>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

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
