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
        public IEnumerable<IFundingRateRestClient> GetFundingRateClients() => _sharedClients.OfType<IFundingRateRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFundingRateRestClient> GetFundingRateClients(TradingMode api) => _sharedClients.OfType<IFundingRateRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFundingRateRestClient? GetFundingRateClient(TradingMode api, string exchange) => _sharedClients.OfType<IFundingRateRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Funding Rate History

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFundingRate[]>> GetFundingRateHistoryAsync(string exchange, GetFundingRateHistoryRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFundingRateHistoryInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return new ExchangeWebResult<SharedFundingRate[]>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFundingRate[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFundingRate[]>[]> GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFundingRateHistoryInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFundingRate[]>> GetFundingRateHistoryAsyncEnumerable(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFundingRateHistoryInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFundingRate[]>>> GetFundingRateHistoryInt(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFundingRateClients().Where(x => x.SupportedTradingModes.Contains(request.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFundingRateHistoryOptions.Supported).Select(x => x.GetFundingRateHistoryAsync(request, null, ct));
            return tasks;
        }

        #endregion

    }
}
