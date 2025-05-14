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
        public IEnumerable<IFeeRestClient> GetFeeClients() => _sharedClients.OfType<IFeeRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFeeRestClient> GetFeeClients(TradingMode api) => _sharedClients.OfType<IFeeRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFeeRestClient? GetFeeClient(TradingMode api, string exchange) => _sharedClients.OfType<IFeeRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Fees 

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFee>> GetFeesAsync(string exchange, GetFeeRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetFeesInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedFee>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFee>[]> GetFeesAsync(GetFeeRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetFeesInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedFee>> GetFeesAsyncEnumerable(GetFeeRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetFeesInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedFee>>> GetFeesInt(GetFeeRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetFeeClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetFeeOptions.Supported).Select(x => x.GetFeesAsync(request, ct));
            return tasks;
        }

        #endregion
    }
}
