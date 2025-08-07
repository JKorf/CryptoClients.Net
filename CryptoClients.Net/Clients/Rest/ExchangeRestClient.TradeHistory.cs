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
        public IEnumerable<ITradeHistoryRestClient> GetTradeHistoryClients() => _sharedClients.OfType<ITradeHistoryRestClient>();
        /// <inheritdoc />
        public IEnumerable<ITradeHistoryRestClient> GetTradeHistoryClients(TradingMode api) => _sharedClients.OfType<ITradeHistoryRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public ITradeHistoryRestClient? GetTradeHistoryClient(TradingMode api, string exchange) => _sharedClients.OfType<ITradeHistoryRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Trade History

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedTrade[]>> GetTradeHistoryAsync(string exchange, GetTradeHistoryRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetTradeHistoryInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedTrade[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedTrade[]>[]> GetTradeHistoryAsync(GetTradeHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetTradeHistoryInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedTrade[]>> GetTradeHistoryAsyncEnumerable(GetTradeHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetTradeHistoryInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedTrade[]>>> GetTradeHistoryInt(GetTradeHistoryRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetTradeHistoryClients().Where(x => x.SupportedTradingModes.Contains(request.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetTradeHistoryOptions.Supported).Select(x => x.GetTradeHistoryAsync(request, null, ct));
            return tasks;
        }

        #endregion

    }
}
