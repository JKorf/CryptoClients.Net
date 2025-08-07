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
        public IEnumerable<ILeverageRestClient> GetLeverageClients() => _sharedClients.OfType<ILeverageRestClient>();
        /// <inheritdoc />
        public IEnumerable<ILeverageRestClient> GetLeverageClients(TradingMode api) => _sharedClients.OfType<ILeverageRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public ILeverageRestClient? GetLeverageClient(TradingMode api, string exchange) => _sharedClients.OfType<ILeverageRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Leverage

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedLeverage>> GetLeverageAsync(string exchange, GetLeverageRequest request, CancellationToken ct = default)
        {
            var client = GetLeverageClient(request.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedLeverage>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetLeverageAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Leverage

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedLeverage>> SetLeverageAsync(string exchange, SetLeverageRequest request, CancellationToken ct = default)
        {
            var client = GetLeverageClient(request.TradingMode, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedLeverage>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.SetLeverageAsync(request, ct).ConfigureAwait(false);
        }

        #endregion
    }
}
