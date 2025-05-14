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
        public IEnumerable<IBalanceRestClient> GetBalancesClients() => _sharedClients.OfType<IBalanceRestClient>();
        /// <inheritdoc />
        public IEnumerable<IBalanceRestClient> GetBalancesClients(TradingMode api) => _sharedClients.OfType<IBalanceRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IBalanceRestClient? GetBalancesClient(TradingMode api, string exchange) => _sharedClients.OfType<IBalanceRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);


        #region Get Balances

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedBalance[]>> GetBalancesAsync(string exchange, GetBalancesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetBalancesIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedBalance[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedBalance[]>[]> GetBalancesAsync(GetBalancesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetBalancesIntAsync(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedBalance[]>> GetBalancesAsyncEnumerable(GetBalancesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetBalancesIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedBalance[]>>> GetBalancesIntAsync(GetBalancesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetBalancesClients().Where(x => request.TradingMode == null ? true : x.SupportedTradingModes.Contains(request.TradingMode.Value));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetBalancesOptions.Supported).Select(x => x.GetBalancesAsync(request, ct));
            return tasks;
        }

        #endregion
    }
}
