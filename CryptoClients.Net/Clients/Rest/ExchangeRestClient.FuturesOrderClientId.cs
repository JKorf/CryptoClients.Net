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
        public IEnumerable<IFuturesOrderClientIdRestClient> GetFuturesOrderClientIdClients() => _sharedClients.OfType<IFuturesOrderClientIdRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesOrderClientIdRestClient> GetFuturesOrderClientIdClients(TradingMode api) => _sharedClients.OfType<IFuturesOrderClientIdRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesOrderClientIdRestClient? GetFuturesOrderClientIdClient(TradingMode tradingMode, string exchange) => GetFuturesOrderClientIdClients(tradingMode).SingleOrDefault(s => s.Exchange == exchange);

        #region Get Futures Order By Client Order Id

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedFuturesOrder>> GetFuturesOrderByClientOrderIdAsync(string exchange, GetOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClientIdClient(request.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedFuturesOrder>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetFuturesOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Futures Order By Client Order Id

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> CancelFuturesOrderByClientOrderIdAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesOrderClientIdClient(request.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelFuturesOrderByClientOrderIdAsync(request, ct).ConfigureAwait(false);
        }

        #endregion


    }
}
