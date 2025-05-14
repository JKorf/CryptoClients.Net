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
        public IEnumerable<IDepositRestClient> GetDepositsClients() => _sharedClients.OfType<IDepositRestClient>();
        /// <inheritdoc />
        public IDepositRestClient? GetDepositsClient(string exchange) => GetDepositsClients().SingleOrDefault(s => s.Exchange == exchange);

        #region Get Deposits

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedDeposit[]>> GetDepositsAsync(string exchange, GetDepositsRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetDepositsInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedDeposit[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedDeposit[]>[]> GetDepositsAsync(GetDepositsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetDepositsInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedDeposit[]>> GetDepositsAsyncEnumerable(GetDepositsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetDepositsInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedDeposit[]>>> GetDepositsInt(GetDepositsRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetDepositsClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetDepositsOptions.Supported).Select(x => x.GetDepositsAsync(request, null, ct));
            return tasks;
        }

        #endregion
    }
}
