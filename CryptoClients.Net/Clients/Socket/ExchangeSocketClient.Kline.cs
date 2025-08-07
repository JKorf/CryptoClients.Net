using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public partial class ExchangeSocketClient
    {
        /// <inheritdoc />
        public IEnumerable<IKlineSocketClient> GetKlineClients() => _sharedClients.OfType<IKlineSocketClient>();
        /// <inheritdoc />
        public IEnumerable<IKlineSocketClient> GetKlineClients(TradingMode api) => _sharedClients.OfType<IKlineSocketClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IKlineSocketClient? GetKlineClient(TradingMode api, string exchange) => _sharedClients.OfType<IKlineSocketClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);


        #region Subscribe Kline

        /// <inheritdoc />
        public async Task<ExchangeResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(
            string exchange,
            SubscribeKlineRequest request,
            Action<ExchangeEvent<SharedKline>> handler,
            CancellationToken ct = default)
        {
            var result = await SubscribeToKlineUpdatesAsync(request, handler, new[] { exchange }, ct).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeResult<UpdateSubscription>(exchange, new InvalidOperationError($"Subscription not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeResult<UpdateSubscription>[]> SubscribeToKlineUpdatesAsync(SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            var clients = GetKlineClients(request.TradingMode);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.SubscribeKlineOptions.Supported).Select(x => Task.Run(async () =>
            {
                return new ExchangeResult<UpdateSubscription>(x.Exchange, await x.SubscribeToKlineUpdatesAsync(request, handler, ct).ConfigureAwait(false));
            }));
            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #endregion

    }
}
