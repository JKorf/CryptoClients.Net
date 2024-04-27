using Binance.Net;
using BingX.Net;
using Bitfinex.Net;
using Bitget.Net;
using Bybit.Net;
using CoinEx.Net;
using CryptoExchange.Net.RateLimiting;
using Huobi.Net;
using Kraken.Net;
using Kucoin.Net;
using Mexc.Net;
using OKX.Net;
using System;

namespace CryptoClients.Net
{
    /// <summary>
    /// Information on supported exchanges and universal functionality
    /// </summary>
    public static class Exchanges
    {
        /// <summary>
        /// Binance exchange info
        /// </summary>
        public static ExchangeInfo Binance { get; } = new ExchangeInfo
        {
            Name = BinanceExchange.ExchangeName,
            Url = BinanceExchange.Url,
            ApiDocsUrl = BinanceExchange.ApiDocsUrl
        };

        /// <summary>
        /// BingX exchange info
        /// </summary>
        public static ExchangeInfo BingX { get; } = new ExchangeInfo
        {
            Name = BingXExchange.ExchangeName,
            Url = BingXExchange.Url,
            ApiDocsUrl = BingXExchange.ApiDocsUrl
        };

        /// <summary>
        /// Bitfinex exchange info
        /// </summary>
        public static ExchangeInfo Bitfinex { get; } = new ExchangeInfo
        {
            Name = BitfinexExchange.ExchangeName,
            Url = BitfinexExchange.Url,
            ApiDocsUrl = BitfinexExchange.ApiDocsUrl
        };

        /// <summary>
        /// Bitget exchange info
        /// </summary>
        public static ExchangeInfo Bitget { get; } = new ExchangeInfo
        {
            Name = BitgetExchange.ExchangeName,
            Url = BitgetExchange.Url,
            ApiDocsUrl = BitgetExchange.ApiDocsUrl
        };

        /// <summary>
        /// Bybit exchange info
        /// </summary>
        public static ExchangeInfo Bybit { get; } = new ExchangeInfo
        {
            Name = BybitExchange.ExchangeName,
            Url = BybitExchange.Url,
            ApiDocsUrl = BybitExchange.ApiDocsUrl
        };

        /// <summary>
        /// CoinEx exchange info
        /// </summary>
        public static ExchangeInfo CoinEx { get; } = new ExchangeInfo
        {
            Name = CoinExExchange.ExchangeName,
            Url = CoinExExchange.Url,
            ApiDocsUrl = CoinExExchange.ApiDocsUrl
        };

        /// <summary>
        /// Huobi exchange info
        /// </summary>
        public static ExchangeInfo Huobi { get; } = new ExchangeInfo
        {
            Name = HuobiExchange.ExchangeName,
            Url = HuobiExchange.Url,
            ApiDocsUrl = HuobiExchange.ApiDocsUrl
        };

        /// <summary>
        /// Kraken exchange info
        /// </summary>
        public static ExchangeInfo Kraken { get; } = new ExchangeInfo
        {
            Name = KrakenExchange.ExchangeName,
            Url = KrakenExchange.Url,
            ApiDocsUrl = KrakenExchange.ApiDocsUrl
        };

        /// <summary>
        /// Kucoin exchange info
        /// </summary>
        public static ExchangeInfo Kucoin { get; } = new ExchangeInfo
        {
            Name = KucoinExchange.ExchangeName,
            Url = KucoinExchange.Url,
            ApiDocsUrl = KucoinExchange.ApiDocsUrl
        };

        /// <summary>
        /// Mexc exchange info
        /// </summary>
        public static ExchangeInfo Mexc { get; } = new ExchangeInfo
        {
            Name = MexcExchange.ExchangeName,
            Url = MexcExchange.Url,
            ApiDocsUrl = MexcExchange.ApiDocsUrl
        };

        /// <summary>
        /// OKX exchange info
        /// </summary>
        public static ExchangeInfo OKX { get; } = new ExchangeInfo
        {
            Name = OKXExchange.ExchangeName,
            Url = OKXExchange.Url,
            ApiDocsUrl = OKXExchange.ApiDocsUrl
        };

        /// <summary>
        /// Information on all supported exchanges
        /// </summary>
        public static ExchangeInfo[] All { get; } = new[]
        {
            Binance,
            BingX,
            Bitfinex,
            Bitget,
            Bybit,
            CoinEx,
            Huobi,
            Kucoin,
            Kraken,
            Mexc,
            OKX
        };

        /// <summary>
        /// Event for when a rate limit is triggered in any of the exchange clients
        /// </summary>
        public static event Action<RateLimitEvent> RateLimitTriggered
        {
            add
            {
                BinanceExchange.RateLimiter.RateLimitTriggered += value;
                KrakenExchange.RateLimiter.RateLimitTriggered += value;
                KucoinExchange.RateLimiter.RateLimitTriggered += value;
            }
            remove
            {
                BinanceExchange.RateLimiter.RateLimitTriggered -= value;
                KrakenExchange.RateLimiter.RateLimitTriggered -= value;
                KucoinExchange.RateLimiter.RateLimitTriggered -= value;
            }
        }
    }
}
