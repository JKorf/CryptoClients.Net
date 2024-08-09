using CryptoClients.Net.Enums;
using CryptoExchange.Net.Objects;

namespace CryptoClients.Net.Models
{
    /// <summary>
    /// A WebCallResult from an exchange
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExchangeResult<T> : WebCallResult<T>
    {
        /// <summary>
        /// The exchange
        /// </summary>
        public Exchange Exchange { get; }

        /// <summary>
        /// ctor
        /// </summary>
        public ExchangeResult(
            Exchange exchange,
            WebCallResult<T> result) : 
            base(result.ResponseStatusCode,
                result.ResponseHeaders,
                result.ResponseTime,
                result.ResponseLength,
                result.OriginalData,
                result.RequestId,
                result.RequestUrl,
                result.RequestBody,
                result.RequestMethod,
                result.RequestHeaders,
                result.DataSource,
                result.Data,
                result.Error)
        {
            Exchange = exchange;
        }
    }
}
