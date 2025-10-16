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
        public IEnumerable<ITransferRestClient> GetTransferClients() => _sharedClients.OfType<ITransferRestClient>();
        /// <inheritdoc />
        public ITransferRestClient? GetTransferClient(string exchange, SharedAccountType from, SharedAccountType to) =>
            _sharedClients.OfType<ITransferRestClient>().SingleOrDefault(s => s.Exchange == exchange
            && s.TransferOptions.SupportedAccountTypes.Contains(from) 
            && s.TransferOptions.SupportedAccountTypes.Contains(to));

        #region Transfer

        /// <inheritdoc />
        public async Task<ExchangeWebResult<SharedId>> TransferAsync(string exchange, TransferRequest request, CancellationToken ct = default)
        {
            var client = GetTransferClient(exchange, request.FromAccountType, request.ToAccountType);
            if (client == null)
                return new ExchangeWebResult<SharedId>(exchange, new InvalidOperationError($"Client not found for exchange " + exchange));

            return await client.TransferAsync(request, ct).ConfigureAwait(false);
        }

        #endregion
    }
}
