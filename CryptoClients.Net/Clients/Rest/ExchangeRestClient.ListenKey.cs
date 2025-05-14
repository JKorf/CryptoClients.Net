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
        public IEnumerable<IListenKeyRestClient> GetListenKeyClients() => _sharedClients.OfType<IListenKeyRestClient>();
        /// <inheritdoc />
        public IEnumerable<IListenKeyRestClient> GetListenKeyClients(TradingMode api) => _sharedClients.OfType<IListenKeyRestClient>().Where(s => s.SupportedTradingModes.Contains(api));
        /// <inheritdoc />
        public IListenKeyRestClient? GetListenKeyClient(TradingMode api, string exchange) => _sharedClients.OfType<IListenKeyRestClient>().SingleOrDefault(s => s.SupportedTradingModes.Contains(api) && s.Exchange == exchange);

        #region Start Listen Key

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>> StartListenKeyAsync(string exchange, StartListenKeyRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(StartListenKeysInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<string>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>[]> StartListenKeysAsync(StartListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(StartListenKeysInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<string>> StartListenKeysAsyncEnumerable(StartListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return StartListenKeysInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<string>>> StartListenKeysInt(StartListenKeyRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetListenKeyClients().Where(x => request.TradingMode.HasValue ? x.SupportedTradingModes.Contains(request.TradingMode.Value) : true);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.StartOptions.Supported).Select(x => x.StartListenKeyAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Keep Alive Listen Key

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>> KeepAliveListenKeyAsync(string exchange, KeepAliveListenKeyRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(KeepAliveListenKeysInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<string>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>[]> KeepAliveListenKeysAsync(KeepAliveListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(KeepAliveListenKeysInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<string>> KeepAliveListenKeysAsyncEnumerable(KeepAliveListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return KeepAliveListenKeysInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<string>>> KeepAliveListenKeysInt(KeepAliveListenKeyRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetListenKeyClients().Where(x => request.TradingMode.HasValue ? x.SupportedTradingModes.Contains(request.TradingMode.Value) : true);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.KeepAliveOptions.Supported).Select(x => x.KeepAliveListenKeyAsync(request, ct));
            return tasks;
        }

        #endregion

        #region Stop Listen Key

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>> StopListenKeyAsync(string exchange, StopListenKeyRequest request, CancellationToken ct = default)
        {
            var result = await Task.WhenAll(StopListenKeysAsyncInt(request, new[] { exchange }, ct)).ConfigureAwait(false);
            return result.SingleOrDefault() ?? new ExchangeWebResult<string>(exchange, new InvalidOperationError($"Request not supported for {exchange}"));
        }

        /// <inheritdoc />
        public async Task<ExchangeWebResult<string>[]> StopListenKeysAsync(StopListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return await Task.WhenAll(StopListenKeysAsyncInt(request, exchanges, ct)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<ExchangeWebResult<string>> StopListenKeysAsyncEnumerable(StopListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default)
        {
            return StopListenKeysAsyncInt(request, exchanges, ct).ParallelEnumerateAsync();
        }

        private IEnumerable<Task<ExchangeWebResult<string>>> StopListenKeysAsyncInt(StopListenKeyRequest request, IEnumerable<string>? exchanges, CancellationToken ct)
        {
            var clients = GetListenKeyClients().Where(x => request.TradingMode.HasValue ? x.SupportedTradingModes.Contains(request.TradingMode.Value) : true);
            if (exchanges != null)
                clients = clients.Where(c => exchanges.Contains(c.Exchange, StringComparer.InvariantCultureIgnoreCase));

            var tasks = clients.Where(x => x.StopOptions.Supported).Select(x => x.StopListenKeyAsync(request, ct));
            return tasks;
        }

        #endregion

    }
}
