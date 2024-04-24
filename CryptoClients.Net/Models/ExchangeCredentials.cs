﻿using Bitget.Net.Objects;
using CryptoExchange.Net.Authentication;
using Kucoin.Net.Objects;
using OKX.Net.Objects;

namespace CryptoClients.Net.Models
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
        /// Bitfinex API credentials
        /// </summary>
        public ApiCredentials? Bitfinex { get; set; }

        /// <summary>
        /// Bitget API credentials
        /// </summary>
        public BitgetApiCredentials? Bitget { get; set; }

        /// <summary>
        /// Bybit API credentials
        /// </summary>
        public ApiCredentials? Bybit { get; set; }

        /// <summary>
        /// CoinEx API credentials
        /// </summary>
        public ApiCredentials? CoinEx { get; set; }

        /// <summary>
        /// Huobi API credentials
        /// </summary>
        public ApiCredentials? Huobi { get; set; }

        /// <summary>
        /// Kraken API credentials
        /// </summary>
        public ApiCredentials? Kraken { get; set; }

        /// <summary>
        /// Kucoin API credentials
        /// </summary>
        public KucoinApiCredentials? Kucoin { get; set; }

        /// <summary>
        /// Mexc API credentials
        /// </summary>
        public ApiCredentials? Mexc { get; set; }

        /// <summary>
        /// OKX API credentials
        /// </summary>
        public OKXApiCredentials? OKX { get; set; }
    }
}
