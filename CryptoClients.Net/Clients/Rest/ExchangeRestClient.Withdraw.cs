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
        public IEnumerable<IWithdrawRestClient> GetWithdrawClients() => _sharedClients.OfType<IWithdrawRestClient>();
        /// <inheritdoc />
        public IWithdrawRestClient? GetWithdrawClient(string exchange) => _sharedClients.OfType<IWithdrawRestClient>().SingleOrDefault(s => s.Exchange == exchange);

    }
}
