﻿using Binance.Net;
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
            Type = BinanceExchange.Type
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
            Type = BingXExchange.Type
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
            Type = BitfinexExchange.Type
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
            Type = BitgetExchange.Type
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
            Type = BitMartExchange.Type
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
            Type = BitMEXExchange.Type
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
            Type = BybitExchange.Type
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
            Type = CoinbaseExchange.Type
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
            Type = CoinExExchange.Type
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
            Type = CryptoComExchange.Type
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
            Type = DeepCoinExchange.Type
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
            Type = GateIoExchange.Type
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
            Type = HTXExchange.Type
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
            Type = HyperLiquidExchange.Type
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
            Type = KrakenExchange.Type
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
            Type = KucoinExchange.Type
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
            Type = MexcExchange.Type
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
            Type = OKXExchange.Type
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
            Type = WhiteBitExchange.Type
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
            Type = XTExchange.Type
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
    }
}
