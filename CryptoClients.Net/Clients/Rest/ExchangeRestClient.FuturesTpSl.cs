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
        public IEnumerable<IFuturesTpSlRestClient> GetFuturesTpSlClients() => _sharedClients.OfType<IFuturesTpSlRestClient>();
        /// <inheritdoc />
        public IEnumerable<IFuturesTpSlRestClient> GetFuturesTpSlClients(TradingMode api) => _sharedClients.OfType<IFuturesTpSlRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IFuturesTpSlRestClient? GetFuturesTpSlClient(TradingMode api, string exchange) => _sharedClients.OfType<IFuturesTpSlRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Set Futures TpSl

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> SetFuturesTpSlAsync(string exchange, SetTpSlRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesTpSlClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.SetFuturesTpSlAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel TpSl

        /// <inheritdoc />
        public async Task<ExchangeWebResult<bool>> CancelFuturesTpSlAsync(string exchange, CancelTpSlRequest request, CancellationToken ct = default)
        {
            var client = GetFuturesTpSlClient(request.Symbol.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<bool>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.CancelFuturesTpSlAsync(request, ct).ConfigureAwait(false);
        }

        #endregion
    }
}
