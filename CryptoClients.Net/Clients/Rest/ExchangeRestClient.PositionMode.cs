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
        public IEnumerable<IPositionModeRestClient> GetPositionModeClients() => _sharedClients.OfType<IPositionModeRestClient>();
        /// <inheritdoc />
        public IEnumerable<IPositionModeRestClient> GetPositionModeClients(TradingMode api) => _sharedClients.OfType<IPositionModeRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IPositionModeRestClient? GetPositionModeClient(TradingMode api, string exchange) => _sharedClients.OfType<IPositionModeRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Get Position Mode

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedPositionModeResult>> GetPositionModeAsync(string exchange, GetPositionModeRequest request, CancellationToken ct = default)
        {
            var client = GetPositionModeClient(request.Symbol?.TradingMode ?? request.TradingMode ?? TradingMode.PerpetualLinear, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedPositionModeResult>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.GetPositionModeAsync(request, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Position Mode

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedPositionModeResult>> SetPositionModeAsync(string exchange, SetPositionModeRequest request, CancellationToken ct = default)
        {
            var client = GetPositionModeClient(request.Symbol?.TradingMode ?? request.TradingMode ?? TradingMode.PerpetualLinear, exchange);
            if (client == null)
                return new ExchangeWebResult<SharedPositionModeResult>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.SetPositionModeAsync(request, ct).ConfigureAwait(false);
        }

        #endregion
    }
}
