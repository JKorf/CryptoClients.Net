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
        public IEnumerable<IPositionHistoryRestClient> GetPositionHistoryClients() => _sharedClients.OfType<IPositionHistoryRestClient>();
        /// <inheritdoc />
        public IEnumerable<IPositionHistoryRestClient> GetPositionHistoryClients(TradingMode api) => _sharedClients.OfType<IPositionHistoryRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IPositionHistoryRestClient? GetPositionHistoryClient(TradingMode api, string exchange) => _sharedClients.OfType<IPositionHistoryRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Position History

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedPositionHistory[]>> GetPositionHistoryAsync(string exchange, GetPositionHistoryRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetPositionHistoryInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return new ExchangeWebResult<SharedPositionHistory[]>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedPositionHistory[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedPositionHistory[]>[]> GetPositionHistoryAsync(GetPositionHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetPositionHistoryInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedPositionHistory[]>> GetPositionHistoryAsyncEnumerable(GetPositionHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetPositionHistoryInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedPositionHistory[]>>> GetPositionHistoryInt(GetPositionHistoryRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetPositionHistoryClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetPositionHistoryOptions.Supported).Select(x => x.GetPositionHistoryAsync(request, null, ct));
            return tasks;
        }

        #endregion


    }
}
