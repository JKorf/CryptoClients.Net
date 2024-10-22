using Binance.Net;
using BingX.Net;
using Bitfinex.Net;
using Bitget.Net;
using BitMart.Net;
using Bybit.Net;
using Coinbase.Net;
using CoinEx.Net;
using CryptoCom.Net;
using CryptoExchange.Net.RateLimiting;
using GateIo.Net;
using HTX.Net;
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
        /// BitMart exchange info
        /// </summary>
        public static ExchangeInfo BitMart { get; } = new ExchangeInfo
        {
            Name = BitMartExchange.ExchangeName,
            Url = BitMartExchange.Url,
            ApiDocsUrl = BitMartExchange.ApiDocsUrl
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
        /// Coinbase exchange info
        /// </summary>
        public static ExchangeInfo Coinbase { get; } = new ExchangeInfo
        {
            Name = CoinbaseExchange.ExchangeName,
            Url = CoinbaseExchange.Url,
            ApiDocsUrl = CoinbaseExchange.ApiDocsUrl
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
        /// Crypto.com exchange info
        /// </summary>
        public static ExchangeInfo CryptoCom { get; } = new ExchangeInfo
        {
            Name = CryptoComExchange.ExchangeName,
            Url = CryptoComExchange.Url,
            ApiDocsUrl = CryptoComExchange.ApiDocsUrl
        };

        /// <summary>
        /// GateIo exchange info
        /// </summary>
        public static ExchangeInfo GateIo { get; } = new ExchangeInfo
        {
            Name = GateIoExchange.ExchangeName,
            Url = GateIoExchange.Url,
            ApiDocsUrl = GateIoExchange.ApiDocsUrl
        };

        /// <summary>
        /// HTX exchange info
        /// </summary>
        public static ExchangeInfo HTX { get; } = new ExchangeInfo
        {
            Name = HTXExchange.ExchangeName,
            Url = HTXExchange.Url,
            ApiDocsUrl = HTXExchange.ApiDocsUrl
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
            BitMart,
            Bybit,
            Coinbase,
            CoinEx,
            CryptoCom,
            GateIo,
            HTX,
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
                BingXExchange.RateLimiter.RateLimitTriggered += value;
                BitgetExchange.RateLimiter.RateLimitTriggered += value;
                BitMartExchange.RateLimiter.RateLimitTriggered += value;
                CoinbaseExchange.RateLimiter.RateLimitTriggered += value;
                CryptoComExchange.RateLimiter.RateLimitTriggered += value;
                GateIoExchange.RateLimiter.RateLimitTriggered += value;
                HTXExchange.RateLimiter.RateLimitTriggered += value;
                KrakenExchange.RateLimiter.RateLimitTriggered += value;
                KucoinExchange.RateLimiter.RateLimitTriggered += value;
                MexcExchange.RateLimiter.RateLimitTriggered += value;
                OKXExchange.RateLimiter.RateLimitTriggered += value;
            }
            remove
            {
                BinanceExchange.RateLimiter.RateLimitTriggered -= value;
                BingXExchange.RateLimiter.RateLimitTriggered -= value;
                BitgetExchange.RateLimiter.RateLimitTriggered -= value;
                BitMartExchange.RateLimiter.RateLimitTriggered -= value;
                CoinbaseExchange.RateLimiter.RateLimitTriggered -= value;
                CryptoComExchange.RateLimiter.RateLimitTriggered -= value;
                GateIoExchange.RateLimiter.RateLimitTriggered -= value;
                HTXExchange.RateLimiter.RateLimitTriggered -= value;
                KrakenExchange.RateLimiter.RateLimitTriggered -= value;
                KucoinExchange.RateLimiter.RateLimitTriggered -= value;
                MexcExchange.RateLimiter.RateLimitTriggered -= value;
                OKXExchange.RateLimiter.RateLimitTriggered -= value;
            }
        }
    }
}
