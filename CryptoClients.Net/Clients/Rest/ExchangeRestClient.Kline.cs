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
        public IEnumerable<IKlineRestClient> GetKlineClients() => _sharedClients.OfType<IKlineRestClient>();
        /// <inheritdoc />
        public IEnumerable<IKlineRestClient> GetKlineClients(TradingMode api) => _sharedClients.OfType<IKlineRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IKlineRestClient? GetKlineClient(TradingMode api, string exchange) => _sharedClients.OfType<IKlineRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Klines

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedKline[]>> GetKlinesAsync(string exchange, GetKlinesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetKlinesIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedKline[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedKline[]>[]> GetKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetKlinesIntAsync(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedKline[]>> GetKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetKlinesIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedKline[]>>> GetKlinesIntAsync(GetKlinesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetKlineClients().Where(x => x.SupportedTradingModes.Contains(request.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetKlinesOptions.Supported).Select(x => x.GetKlinesAsync(request, null, ct));
            return tasks;
        }


        #endregion
    }
}
