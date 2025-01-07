using CryptoExchange.Net.Objects;
using System;

namespace CryptoClients.Net
{
    /// <summary>
    /// Exchange information
    /// </summary>
    public class ExchangeInfo
    {
        /// <summary>
        /// Exchange name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Display name for the exchange
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;
        /// <summary>
        /// Image url
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
        /// <summary>
        /// Website URL
        /// </summary>
        public string Url { get; set; } = string.Empty;
        /// <summary>
        /// Urls for the API documentation
        /// </summary>
        public string[] ApiDocsUrl { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Exchange type
        /// </summary>
        public ExchangeType Type { get; set; }
    }
}
