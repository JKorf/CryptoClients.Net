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
        public IEnumerable<IRecentTradeRestClient> GetRecentTradesClients() => _sharedClients.OfType<IRecentTradeRestClient>();
        /// <inheritdoc />
        public IEnumerable<IRecentTradeRestClient> GetRecentTradesClients(TradingMode api) => _sharedClients.OfType<IRecentTradeRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IRecentTradeRestClient? GetRecentTradesClient(TradingMode api, string exchange) => _sharedClients.OfType<IRecentTradeRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Recent Trades

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedTrade[]>> GetRecentTradesAsync(string exchange, GetRecentTradesRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(GetRecentTradesIntAsync(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<SharedTrade[]>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedTrade[]>[]> GetRecentTradesAsync(GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(GetRecentTradesIntAsync(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<SharedTrade[]>> GetRecentTradesAsyncEnumerable(GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return GetRecentTradesIntAsync(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<SharedTrade[]>>> GetRecentTradesIntAsync(GetRecentTradesRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetRecentTradesClients().Where(x => x.SupportedTradingModes.Contains(request.Symbol.TradingMode));
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.GetRecentTradesOptions.Supported).Select(x => x.GetRecentTradesAsync(request, ct));
            return tasks;
        }

        #endregion

    }
}
