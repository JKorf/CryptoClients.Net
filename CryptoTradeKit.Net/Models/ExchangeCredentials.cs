using CryptoExchange.Net.Authentication;
using Kucoin.Net.Objects;

namespace CryptoTradeKit.Net.Models
{
    /// <summary>
    /// Credentials for each exchange
    /// </summary>
    public class ExchangeCredentials
    {
        /// <summary>
        /// Binance API credentials
        /// </summary>
        public ApiCredentials? Binance { get; set; }

        /// <summary>
        /// BingX API credentials
        /// </summary>
        public ApiCredentials? BingX { get; set; }

        /// <summary>
        /// Kucoin API credentials
        /// </summary>
        public KucoinApiCredentials? Kucoin { get; set; }
    }
}
