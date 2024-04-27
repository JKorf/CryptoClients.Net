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
        /// Website URL
        /// </summary>
        public string Url { get; set; } = string.Empty;
        /// <summary>
        /// Urls for the API documentation
        /// </summary>
        public string[] ApiDocsUrl { get; set; } = Array.Empty<string>();
    }
}
