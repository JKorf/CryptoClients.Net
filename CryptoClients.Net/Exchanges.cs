using Binance.Net;
using BingX.Net;
using Bitfinex.Net;
using Bitget.Net;
using BitMart.Net;
using BitMEX.Net;
using Bybit.Net;
using Coinbase.Net;
using CoinEx.Net;
using CoinGecko.Net;
using CryptoCom.Net;
using CryptoExchange.Net.RateLimiting;
using DeepCoin.Net;
using GateIo.Net;
using HTX.Net;
using HyperLiquid.Net;
using Kraken.Net;
using Kucoin.Net;
using Mexc.Net;
using OKX.Net;
using System;
using WhiteBit.Net;
using XT.Net;

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
            DisplayName = BinanceExchange.DisplayName,
            ImageUrl = BinanceExchange.ImageUrl,
            Url = BinanceExchange.Url,
            ApiDocsUrl = BinanceExchange.ApiDocsUrl,
            Type = BinanceExchange.Type,
            ApiEnvironments = BinanceEnvironment.All
        };

        /// <summary>
        /// BingX exchange info
        /// </summary>
        public static ExchangeInfo BingX { get; } = new ExchangeInfo
        {
            Name = BingXExchange.ExchangeName,
            DisplayName = BingXExchange.DisplayName,
            ImageUrl = BingXExchange.ImageUrl,
            Url = BingXExchange.Url,
            ApiDocsUrl = BingXExchange.ApiDocsUrl,
            Type = BingXExchange.Type,
            ApiEnvironments = BingXEnvironment.All
        };

        /// <summary>
        /// Bitfinex exchange info
        /// </summary>
        public static ExchangeInfo Bitfinex { get; } = new ExchangeInfo
        {
            Name = BitfinexExchange.ExchangeName,
            DisplayName = BitfinexExchange.DisplayName,
            ImageUrl = BitfinexExchange.ImageUrl,
            Url = BitfinexExchange.Url,
            ApiDocsUrl = BitfinexExchange.ApiDocsUrl,
            Type = BitfinexExchange.Type,
            ApiEnvironments = BitfinexEnvironment.All
        };

        /// <summary>
        /// Bitget exchange info
        /// </summary>
        public static ExchangeInfo Bitget { get; } = new ExchangeInfo
        {
            Name = BitgetExchange.ExchangeName,
            DisplayName = BitgetExchange.DisplayName,
            ImageUrl = BitgetExchange.ImageUrl,
            Url = BitgetExchange.Url,
            ApiDocsUrl = BitgetExchange.ApiDocsUrl,
            Type = BitgetExchange.Type,
            ApiEnvironments = BitgetEnvironment.All
        };

        /// <summary>
        /// BitMart exchange info
        /// </summary>
        public static ExchangeInfo BitMart { get; } = new ExchangeInfo
        {
            Name = BitMartExchange.ExchangeName,
            DisplayName = BitMartExchange.DisplayName,
            ImageUrl = BitMartExchange.ImageUrl,
            Url = BitMartExchange.Url,
            ApiDocsUrl = BitMartExchange.ApiDocsUrl,
            Type = BitMartExchange.Type,
            ApiEnvironments = BitMartEnvironment.All
        };

        /// <summary>
        /// BitMEX exchange info
        /// </summary>
        public static ExchangeInfo BitMEX { get; } = new ExchangeInfo
        {
            Name = BitMEXExchange.ExchangeName,
            DisplayName = BitMEXExchange.DisplayName,
            ImageUrl = BitMEXExchange.ImageUrl,
            Url = BitMEXExchange.Url,
            ApiDocsUrl = BitMEXExchange.ApiDocsUrl,
            Type = BitMEXExchange.Type,
            ApiEnvironments = BitMEXEnvironment.All
        };

        /// <summary>
        /// Bybit exchange info
        /// </summary>
        public static ExchangeInfo Bybit { get; } = new ExchangeInfo
        {
            Name = BybitExchange.ExchangeName,
            DisplayName = BybitExchange.DisplayName,
            ImageUrl = BybitExchange.ImageUrl,
            Url = BybitExchange.Url,
            ApiDocsUrl = BybitExchange.ApiDocsUrl,
            Type = BybitExchange.Type,
            ApiEnvironments = BybitEnvironment.All
        };

        /// <summary>
        /// Coinbase exchange info
        /// </summary>
        public static ExchangeInfo Coinbase { get; } = new ExchangeInfo
        {
            Name = CoinbaseExchange.ExchangeName,
            DisplayName = CoinbaseExchange.DisplayName,
            ImageUrl = CoinbaseExchange.ImageUrl,
            Url = CoinbaseExchange.Url,
            ApiDocsUrl = CoinbaseExchange.ApiDocsUrl,
            Type = CoinbaseExchange.Type,
            ApiEnvironments = CoinbaseEnvironment.All
        };

        /// <summary>
        /// CoinEx exchange info
        /// </summary>
        public static ExchangeInfo CoinEx { get; } = new ExchangeInfo
        {
            Name = CoinExExchange.ExchangeName,
            DisplayName = CoinExExchange.DisplayName,
            ImageUrl = CoinExExchange.ImageUrl,
            Url = CoinExExchange.Url,
            ApiDocsUrl = CoinExExchange.ApiDocsUrl,
            Type = CoinExExchange.Type,
            ApiEnvironments = CoinExEnvironment.All
        };

        /// <summary>
        /// Crypto.com exchange info
        /// </summary>
        public static ExchangeInfo CryptoCom { get; } = new ExchangeInfo
        {
            Name = CryptoComExchange.ExchangeName,
            DisplayName = CryptoComExchange.DisplayName,
            ImageUrl = CryptoComExchange.ImageUrl,
            Url = CryptoComExchange.Url,
            ApiDocsUrl = CryptoComExchange.ApiDocsUrl,
            Type = CryptoComExchange.Type,
            ApiEnvironments = CryptoComEnvironment.All
        };

        /// <summary>
        /// DeepCoin exchange info
        /// </summary>
        public static ExchangeInfo DeepCoin { get; } = new ExchangeInfo
        {
            Name = DeepCoinExchange.ExchangeName,
            DisplayName = DeepCoinExchange.DisplayName,
            ImageUrl = DeepCoinExchange.ImageUrl,
            Url = DeepCoinExchange.Url,
            ApiDocsUrl = DeepCoinExchange.ApiDocsUrl,
            Type = DeepCoinExchange.Type,
            ApiEnvironments = DeepCoinEnvironment.All
        };

        /// <summary>
        /// GateIo exchange info
        /// </summary>
        public static ExchangeInfo GateIo { get; } = new ExchangeInfo
        {
            Name = GateIoExchange.ExchangeName,
            DisplayName = GateIoExchange.DisplayName,
            ImageUrl = GateIoExchange.ImageUrl,
            Url = GateIoExchange.Url,
            ApiDocsUrl = GateIoExchange.ApiDocsUrl,
            Type = GateIoExchange.Type,
            ApiEnvironments = GateIoEnvironment.All
        };

        /// <summary>
        /// HTX exchange info
        /// </summary>
        public static ExchangeInfo HTX { get; } = new ExchangeInfo
        {
            Name = HTXExchange.ExchangeName,
            DisplayName = HTXExchange.DisplayName,
            ImageUrl = HTXExchange.ImageUrl,
            Url = HTXExchange.Url,
            ApiDocsUrl = HTXExchange.ApiDocsUrl,
            Type = HTXExchange.Type,
            ApiEnvironments = HTXEnvironment.All
        };

        /// <summary>
        /// HyperLiquid exchange info
        /// </summary>
        public static ExchangeInfo HyperLiquid { get; } = new ExchangeInfo
        {
            Name = HyperLiquidExchange.ExchangeName,
            DisplayName = HyperLiquidExchange.DisplayName,
            ImageUrl = HyperLiquidExchange.ImageUrl,
            Url = HyperLiquidExchange.Url,
            ApiDocsUrl = HyperLiquidExchange.ApiDocsUrl,
            Type = HyperLiquidExchange.Type,
            ApiEnvironments = HyperLiquidEnvironment.All
        };

        /// <summary>
        /// Kraken exchange info
        /// </summary>
        public static ExchangeInfo Kraken { get; } = new ExchangeInfo
        {
            Name = KrakenExchange.ExchangeName,
            DisplayName = KrakenExchange.DisplayName,
            ImageUrl = KrakenExchange.ImageUrl,
            Url = KrakenExchange.Url,
            ApiDocsUrl = KrakenExchange.ApiDocsUrl,
            Type = KrakenExchange.Type,
            ApiEnvironments = KrakenEnvironment.All
        };

        /// <summary>
        /// Kucoin exchange info
        /// </summary>
        public static ExchangeInfo Kucoin { get; } = new ExchangeInfo
        {
            Name = KucoinExchange.ExchangeName,
            DisplayName = KucoinExchange.DisplayName,
            ImageUrl = KucoinExchange.ImageUrl,
            Url = KucoinExchange.Url,
            ApiDocsUrl = KucoinExchange.ApiDocsUrl,
            Type = KucoinExchange.Type,
            ApiEnvironments = KucoinEnvironment.All
        };

        /// <summary>
        /// Mexc exchange info
        /// </summary>
        public static ExchangeInfo Mexc { get; } = new ExchangeInfo
        {
            Name = MexcExchange.ExchangeName,
            DisplayName = MexcExchange.DisplayName,
            ImageUrl = MexcExchange.ImageUrl,
            Url = MexcExchange.Url,
            ApiDocsUrl = MexcExchange.ApiDocsUrl,
            Type = MexcExchange.Type,
            ApiEnvironments = MexcEnvironment.All
        };

        /// <summary>
        /// OKX exchange info
        /// </summary>
        public static ExchangeInfo OKX { get; } = new ExchangeInfo
        {
            Name = OKXExchange.ExchangeName,
            DisplayName = OKXExchange.DisplayName,
            ImageUrl = OKXExchange.ImageUrl,
            Url = OKXExchange.Url,
            ApiDocsUrl = OKXExchange.ApiDocsUrl,
            Type = OKXExchange.Type,
            ApiEnvironments = OKXEnvironment.All
        };

        /// <summary>
        /// WhiteBit exchange info
        /// </summary>
        public static ExchangeInfo WhiteBit { get; } = new ExchangeInfo
        {
            Name = WhiteBitExchange.ExchangeName,
            DisplayName = WhiteBitExchange.DisplayName,
            ImageUrl = WhiteBitExchange.ImageUrl,
            Url = WhiteBitExchange.Url,
            ApiDocsUrl = WhiteBitExchange.ApiDocsUrl,
            Type = WhiteBitExchange.Type,
            ApiEnvironments = WhiteBitEnvironment.All
        };

        /// <summary>
        /// XT exchange info
        /// </summary>
        public static ExchangeInfo XT { get; } = new ExchangeInfo
        {
            Name = XTExchange.ExchangeName,
            DisplayName = XTExchange.DisplayName,
            ImageUrl = XTExchange.ImageUrl,
            Url = XTExchange.Url,
            ApiDocsUrl = XTExchange.ApiDocsUrl,
            Type = XTExchange.Type,
            ApiEnvironments = XTEnvironment.All
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
            BitMEX,
            Bybit,
            Coinbase,
            CoinEx,
            CryptoCom,
            DeepCoin,
            GateIo,
            HTX,
            HyperLiquid,
            Kucoin,
            Kraken,
            Mexc,
            OKX,
            WhiteBit,
            XT
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
                BitfinexExchange.RateLimiter.RateLimitTriggered += value;
                BitgetExchange.RateLimiter.RateLimitTriggered += value;
                BitMartExchange.RateLimiter.RateLimitTriggered += value;
                BitMEXExchange.RateLimiter.RateLimitTriggered += value;
                BybitExchange.RateLimiter.RateLimitTriggered += value;
                CoinbaseExchange.RateLimiter.RateLimitTriggered += value;
                CoinGeckoApi.RateLimiter.RateLimitTriggered += value;
                CryptoComExchange.RateLimiter.RateLimitTriggered += value;
                DeepCoinExchange.RateLimiter.RateLimitTriggered += value;
                GateIoExchange.RateLimiter.RateLimitTriggered += value;
                HTXExchange.RateLimiter.RateLimitTriggered += value;
                HyperLiquidExchange.RateLimiter.RateLimitTriggered += value;
                KrakenExchange.RateLimiter.RateLimitTriggered += value;
                KucoinExchange.RateLimiter.RateLimitTriggered += value;
                MexcExchange.RateLimiter.RateLimitTriggered += value;
                OKXExchange.RateLimiter.RateLimitTriggered += value;
                WhiteBitExchange.RateLimiter.RateLimitTriggered += value;
                XTExchange.RateLimiter.RateLimitTriggered += value;
            }
            remove
            {
                BinanceExchange.RateLimiter.RateLimitTriggered -= value;
                BingXExchange.RateLimiter.RateLimitTriggered -= value;
                BitfinexExchange.RateLimiter.RateLimitTriggered -= value;
                BitgetExchange.RateLimiter.RateLimitTriggered -= value;
                BitMartExchange.RateLimiter.RateLimitTriggered -= value;
                BitMEXExchange.RateLimiter.RateLimitTriggered -= value;
                BybitExchange.RateLimiter.RateLimitTriggered -= value;
                CoinbaseExchange.RateLimiter.RateLimitTriggered -= value;
                CoinGeckoApi.RateLimiter.RateLimitTriggered -= value;
                CryptoComExchange.RateLimiter.RateLimitTriggered -= value;
                DeepCoinExchange.RateLimiter.RateLimitTriggered -= value;
                GateIoExchange.RateLimiter.RateLimitTriggered -= value;
                HTXExchange.RateLimiter.RateLimitTriggered -= value;
                HyperLiquidExchange.RateLimiter.RateLimitTriggered -= value;
                KrakenExchange.RateLimiter.RateLimitTriggered -= value;
                KucoinExchange.RateLimiter.RateLimitTriggered -= value;
                MexcExchange.RateLimiter.RateLimitTriggered -= value;
                OKXExchange.RateLimiter.RateLimitTriggered -= value;
                WhiteBitExchange.RateLimiter.RateLimitTriggered -= value;
                XTExchange.RateLimiter.RateLimitTriggered -= value;
            }
        }

        /// <summary>
        /// Event when the rate limit is updated. Note that it's only updated when a request is send, so there are no specific updates when the current usage is decaying.
        /// </summary>
        public static event Action<RateLimitUpdateEvent> RateLimitUpdated
        {
            add
            {
                BinanceExchange.RateLimiter.RateLimitUpdated += value;
                BingXExchange.RateLimiter.RateLimitUpdated += value;
                BitfinexExchange.RateLimiter.RateLimitUpdated += value;
                BitgetExchange.RateLimiter.RateLimitUpdated += value;
                BitMartExchange.RateLimiter.RateLimitUpdated += value;
                BitMEXExchange.RateLimiter.RateLimitUpdated += value;
                BybitExchange.RateLimiter.RateLimitUpdated += value;
                CoinbaseExchange.RateLimiter.RateLimitUpdated += value;
                CryptoComExchange.RateLimiter.RateLimitUpdated += value;
                DeepCoinExchange.RateLimiter.RateLimitUpdated += value;
                GateIoExchange.RateLimiter.RateLimitUpdated += value;
                HTXExchange.RateLimiter.RateLimitUpdated += value;
                HyperLiquidExchange.RateLimiter.RateLimitUpdated += value;
                KrakenExchange.RateLimiter.RateLimitUpdated += value;
                KucoinExchange.RateLimiter.RateLimitUpdated += value;
                MexcExchange.RateLimiter.RateLimitUpdated += value;
                OKXExchange.RateLimiter.RateLimitUpdated += value;
                WhiteBitExchange.RateLimiter.RateLimitUpdated += value;
                XTExchange.RateLimiter.RateLimitUpdated += value;
            }
            remove
            {
                BinanceExchange.RateLimiter.RateLimitUpdated -= value;
                BingXExchange.RateLimiter.RateLimitUpdated -= value;
                BitfinexExchange.RateLimiter.RateLimitUpdated -= value;
                BitgetExchange.RateLimiter.RateLimitUpdated -= value;
                BitMartExchange.RateLimiter.RateLimitUpdated -= value;
                BitMEXExchange.RateLimiter.RateLimitUpdated -= value;
                BybitExchange.RateLimiter.RateLimitUpdated -= value;
                CoinbaseExchange.RateLimiter.RateLimitUpdated -= value;
                CryptoComExchange.RateLimiter.RateLimitUpdated -= value;
                DeepCoinExchange.RateLimiter.RateLimitUpdated -= value;
                GateIoExchange.RateLimiter.RateLimitUpdated -= value;
                HTXExchange.RateLimiter.RateLimitUpdated -= value;
                HyperLiquidExchange.RateLimiter.RateLimitUpdated -= value;
                KrakenExchange.RateLimiter.RateLimitUpdated -= value;
                KucoinExchange.RateLimiter.RateLimitUpdated -= value;
                MexcExchange.RateLimiter.RateLimitUpdated -= value;
                OKXExchange.RateLimiter.RateLimitUpdated -= value;
                WhiteBitExchange.RateLimiter.RateLimitUpdated -= value;
                XTExchange.RateLimiter.RateLimitUpdated -= value;
            }
        }
    }
}
