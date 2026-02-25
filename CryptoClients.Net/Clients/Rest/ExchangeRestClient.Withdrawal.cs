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
        public IEnumerable<IWithdrawalRestClient> GetWithdrawalsClients() => _sharedClients.OfType<IWithdrawalRestClient>();
        /// <inheritdoc />
        public IWithdrawalRestClient? GetWithdrawalsClient(string exchange) => _sharedClients.OfType<IWithdrawalRestClient>().SingleOrDefault(s => s.Exchange == exchange);

        #region Get Withdrawals

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedWithdrawal[]>> GetWithdrawalsAsync(string exchange, GetWithdrawalsRequest request, PageRequest? pageRequest = null, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetWithdrawalsInt(request, new[] { exchange }, pageRequest, ct)).ConfigureAwait(false);
            if (result.Length > 1)
                return new ExchangeWebResult<SharedWithdrawal[]>(exchange, new InvalidOperationError($"Multiple API's available for {exchange}, specify the `TradingMode` parameter on the request to choose one"));

            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedWithdrawal[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedWithdrawal[]>[]> GetWithdrawalsAsync(GetWithdrawalsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetWithdrawalsInt(request, exchanges, null, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedWithdrawal[]>> GetWithdrawalsAsyncEnumerable(GetWithdrawalsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetWithdrawalsInt(request, exchanges, null, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedWithdrawal[]>>> GetWithdrawalsInt(GetWithdrawalsRequest request, IEnumerable<string>? exchanges, PageRequest? pageRequest, CancellationToken ct)
        {
            var clients = GetWithdrawalsClients();
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetWithdrawalsOptions.Supported).Select(x => x.GetWithdrawalsAsync(request, pageRequest, ct));
            return tasks;
        }

        #endregion

    }
}
