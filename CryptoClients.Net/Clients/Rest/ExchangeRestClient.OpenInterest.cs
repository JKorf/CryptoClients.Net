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
        public IEnumerable<IOpenInterestRestClient> GetOpenInterestClients() => _sharedClients.OfType<IOpenInterestRestClient>();
        /// <inheritdoc />
        public IEnumerable<IOpenInterestRestClient> GetOpenInterestClients(TradingMode api) => _sharedClients.OfType<IOpenInterestRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IOpenInterestRestClient? GetOpenInterestClient(TradingMode api, string exchange) => _sharedClients.OfType<IOpenInterestRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Open Interest

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedOpenInterest>> GetOpenInterestAsync(string exchange, GetOpenInterestRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetOpenInterestInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return new ExchangeWebResult<SharedOpenInterest>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedOpenInterest>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedOpenInterest>[]> GetOpenInterestAsync(GetOpenInterestRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetOpenInterestInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedOpenInterest>> GetOpenInterestAsyncEnumerable(GetOpenInterestRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetOpenInterestInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedOpenInterest>>> GetOpenInterestInt(GetOpenInterestRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetOpenInterestClients().Where(x => x.SupportedTradingModes.Contains(request.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetOpenInterestOptions.Supported).Select(x => x.GetOpenInterestAsync(request, ct));
            return tasks;
        }

        #endregion

    }
}
