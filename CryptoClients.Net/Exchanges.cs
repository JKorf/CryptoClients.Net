using Aster.Net;
using Binance.Net;
using BingX.Net;
using Bitfinex.Net;
using Bitget.Net;
using BitMart.Net;
using BitMEX.Net;
using Bitstamp.Net;
using BloFin.Net;
using Bybit.Net;
using Coinbase.Net;
using CoinEx.Net;
using CoinGecko.Net;
using CoinW.Net;
using CryptoClients.Net.Models;
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
using Polymarket.Net;
using System;
using System.Linq;
using Toobit.Net;
using Upbit.Net;
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
        /// Aster exchange info
        /// </summary>
        public static ExchangeInfo Aster { get; } = new ExchangeInfo
        {
            Name = AsterExchange.ExchangeName,
            DisplayName = AsterExchange.DisplayName,
            ImageUrl = AsterExchange.ImageUrl,
            Url = AsterExchange.Url,
            ApiDocsUrl = AsterExchange.ApiDocsUrl,
            Type = AsterExchange.Type,
            ApiEnvironments = AsterEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = AsterExchange.ExchangeName,
                KeyDescription = "The user private key",
                Param1Required = true,
                Param1Description = "The private signing key"
            }
        };

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
            ApiEnvironments = BinanceEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = BinanceExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = BingXEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = BingXExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = BitfinexEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = BitfinexExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = BitgetEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = BitgetExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret",
                Param2Required = true,
                Param2Description = "Passphrase"
            }
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
            ApiEnvironments = BitMartEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = BitMartExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret",
                Param2Required = true,
                Param2Description = "Passphrase"
            }
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
            ApiEnvironments = BitMEXEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = BitMEXExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
        };

        /// <summary>
        /// Bitstamp exchange info
        /// </summary>
        public static ExchangeInfo Bitstamp { get; } = new ExchangeInfo
        {
            Name = BitstampExchange.ExchangeName,
            DisplayName = BitstampExchange.DisplayName,
            ImageUrl = BitstampExchange.ImageUrl,
            Url = BitstampExchange.Url,
            ApiDocsUrl = BitstampExchange.ApiDocsUrl,
            Type = BitstampExchange.Type,
            ApiEnvironments = BitstampEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = BitstampExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
        };

        /// <summary>
        /// BloFin exchange info
        /// </summary>
        public static ExchangeInfo BloFin { get; } = new ExchangeInfo
        {
            Name = BloFinExchange.ExchangeName,
            DisplayName = BloFinExchange.DisplayName,
            ImageUrl = BloFinExchange.ImageUrl,
            Url = BloFinExchange.Url,
            ApiDocsUrl = BloFinExchange.ApiDocsUrl,
            Type = BloFinExchange.Type,
            ApiEnvironments = BloFinEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = BloFinExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret",
                Param2Required = true,
                Param2Description = "Passphrase"
            }
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
            ApiEnvironments = BybitEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = BybitExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = CoinbaseEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = CoinbaseExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = CoinExEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = CoinExExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
        };

        /// <summary>
        /// CoinW exchange info
        /// </summary>
        public static ExchangeInfo CoinW { get; } = new ExchangeInfo
        {
            Name = CoinWExchange.ExchangeName,
            DisplayName = CoinWExchange.DisplayName,
            ImageUrl = CoinWExchange.ImageUrl,
            Url = CoinWExchange.Url,
            ApiDocsUrl = CoinWExchange.ApiDocsUrl,
            Type = CoinWExchange.Type,
            ApiEnvironments = CoinWEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = CoinWExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = CryptoComEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = CryptoComExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = DeepCoinEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = DeepCoinExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret",
                Param2Required = true,
                Param2Description = "Passphrase"
            }
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
            ApiEnvironments = GateIoEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = GateIoExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = HTXEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = HTXExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = HyperLiquidEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = HyperLiquidExchange.ExchangeName,
                KeyDescription = "The public key",
                Param1Required = true,
                Param1Description = "Private key"
            }
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
            ApiEnvironments = KrakenEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = KrakenExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = KucoinEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = KucoinExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret",
                Param2Required = true,
                Param2Description = "Passphrase"
            }
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
            ApiEnvironments = MexcEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = MexcExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = OKXEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = OKXExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret",
                Param2Required = true,
                Param2Description = "Passphrase"
            }
        };

        /// <summary>
        /// Toobit exchange info
        /// </summary>
        public static ExchangeInfo Toobit { get; } = new ExchangeInfo
        {
            Name = ToobitExchange.ExchangeName,
            DisplayName = ToobitExchange.DisplayName,
            ImageUrl = ToobitExchange.ImageUrl,
            Url = ToobitExchange.Url,
            ApiDocsUrl = ToobitExchange.ApiDocsUrl,
            Type = ToobitExchange.Type,
            ApiEnvironments = ToobitEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = ToobitExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
        };

        /// <summary>
        /// Upbit exchange info
        /// </summary>
        public static ExchangeInfo Upbit { get; } = new ExchangeInfo
        {
            Name = UpbitExchange.ExchangeName,
            DisplayName = UpbitExchange.DisplayName,
            ImageUrl = UpbitExchange.ImageUrl,
            Url = UpbitExchange.Url,
            ApiDocsUrl = UpbitExchange.ApiDocsUrl,
            Type = UpbitExchange.Type,
            ApiEnvironments = UpbitEnvironment.All,
            DynamicCredentialInfo = (mode) => null
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
            ApiEnvironments = WhiteBitEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = WhiteBitExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
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
            ApiEnvironments = XTEnvironment.All,
            DynamicCredentialInfo = (mode) => new DynamicCredentialInfo
            {
                Exchange = XTExchange.ExchangeName,
                KeyDescription = "The API key",
                Param1Required = true,
                Param1Description = "API secret"
            }
        };

        /// <summary>
        /// Get exchange info by exchange name
        /// </summary>
        public static ExchangeInfo? GetByName(string exchangeName)
            => All.SingleOrDefault(x => x.Name == exchangeName);

        /// <summary>
        /// Information on all supported exchanges
        /// </summary>
        public static ExchangeInfo[] All { get; } = new[]
        {
            Aster,
            Binance,
            BingX,
            Bitfinex,
            Bitget,
            BitMart,
            BitMEX,
            Bitstamp,
            BloFin,
            Bybit,
            Coinbase,
            CoinEx,
            CoinW,
            CryptoCom,
            DeepCoin,
            GateIo,
            HTX,
            HyperLiquid,
            Kucoin,
            Kraken,
            Mexc,
            OKX,
            Toobit,
            Upbit,
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
                AsterExchange.RateLimiter.RateLimitTriggered += value;
                BinanceExchange.RateLimiter.RateLimitTriggered += value;
                BingXExchange.RateLimiter.RateLimitTriggered += value;
                BitfinexExchange.RateLimiter.RateLimitTriggered += value;
                BitgetExchange.RateLimiter.RateLimitTriggered += value;
                BitMartExchange.RateLimiter.RateLimitTriggered += value;
                BitMEXExchange.RateLimiter.RateLimitTriggered += value;
                BitstampExchange.RateLimiter.RateLimitTriggered += value;
                BloFinExchange.RateLimiter.RateLimitTriggered += value;
                BybitExchange.RateLimiter.RateLimitTriggered += value;
                CoinbaseExchange.RateLimiter.RateLimitTriggered += value;
                CoinGeckoApi.RateLimiter.RateLimitTriggered += value;
                CoinWExchange.RateLimiter.RateLimitTriggered += value;
                CryptoComExchange.RateLimiter.RateLimitTriggered += value;
                DeepCoinExchange.RateLimiter.RateLimitTriggered += value;
                GateIoExchange.RateLimiter.RateLimitTriggered += value;
                HTXExchange.RateLimiter.RateLimitTriggered += value;
                HyperLiquidExchange.RateLimiter.RateLimitTriggered += value;
                KrakenExchange.RateLimiter.RateLimitTriggered += value;
                KucoinExchange.RateLimiter.RateLimitTriggered += value;
                MexcExchange.RateLimiter.RateLimitTriggered += value;
                OKXExchange.RateLimiter.RateLimitTriggered += value;
                PolymarketPlatform.RateLimiter.RateLimitTriggered += value;
                ToobitExchange.RateLimiter.RateLimitTriggered += value;
                UpbitExchange.RateLimiter.RateLimitTriggered += value;
                WhiteBitExchange.RateLimiter.RateLimitTriggered += value;
                XTExchange.RateLimiter.RateLimitTriggered += value;
            }
            remove
            {
                AsterExchange.RateLimiter.RateLimitTriggered -= value;
                BinanceExchange.RateLimiter.RateLimitTriggered -= value;
                BingXExchange.RateLimiter.RateLimitTriggered -= value;
                BitfinexExchange.RateLimiter.RateLimitTriggered -= value;
                BitgetExchange.RateLimiter.RateLimitTriggered -= value;
                BitMartExchange.RateLimiter.RateLimitTriggered -= value;
                BitMEXExchange.RateLimiter.RateLimitTriggered -= value;
                BitstampExchange.RateLimiter.RateLimitTriggered -= value;
                BloFinExchange.RateLimiter.RateLimitTriggered -= value;
                BybitExchange.RateLimiter.RateLimitTriggered -= value;
                CoinbaseExchange.RateLimiter.RateLimitTriggered -= value;
                CoinGeckoApi.RateLimiter.RateLimitTriggered -= value;
                CoinWExchange.RateLimiter.RateLimitTriggered -= value;
                CryptoComExchange.RateLimiter.RateLimitTriggered -= value;
                DeepCoinExchange.RateLimiter.RateLimitTriggered -= value;
                GateIoExchange.RateLimiter.RateLimitTriggered -= value;
                HTXExchange.RateLimiter.RateLimitTriggered -= value;
                HyperLiquidExchange.RateLimiter.RateLimitTriggered -= value;
                KrakenExchange.RateLimiter.RateLimitTriggered -= value;
                KucoinExchange.RateLimiter.RateLimitTriggered -= value;
                MexcExchange.RateLimiter.RateLimitTriggered -= value;
                OKXExchange.RateLimiter.RateLimitTriggered -= value;
                PolymarketPlatform.RateLimiter.RateLimitTriggered -= value;
                ToobitExchange.RateLimiter.RateLimitTriggered -= value;
                UpbitExchange.RateLimiter.RateLimitTriggered -= value;
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
                AsterExchange.RateLimiter.RateLimitUpdated += value;
                BinanceExchange.RateLimiter.RateLimitUpdated += value;
                BingXExchange.RateLimiter.RateLimitUpdated += value;
                BitfinexExchange.RateLimiter.RateLimitUpdated += value;
                BitgetExchange.RateLimiter.RateLimitUpdated += value;
                BitMartExchange.RateLimiter.RateLimitUpdated += value;
                BitMEXExchange.RateLimiter.RateLimitUpdated += value;
                BitstampExchange.RateLimiter.RateLimitUpdated += value;
                BloFinExchange.RateLimiter.RateLimitUpdated += value;
                BybitExchange.RateLimiter.RateLimitUpdated += value;
                CoinbaseExchange.RateLimiter.RateLimitUpdated += value;
                CoinWExchange.RateLimiter.RateLimitUpdated += value;
                CryptoComExchange.RateLimiter.RateLimitUpdated += value;
                DeepCoinExchange.RateLimiter.RateLimitUpdated += value;
                GateIoExchange.RateLimiter.RateLimitUpdated += value;
                HTXExchange.RateLimiter.RateLimitUpdated += value;
                HyperLiquidExchange.RateLimiter.RateLimitUpdated += value;
                KrakenExchange.RateLimiter.RateLimitUpdated += value;
                KucoinExchange.RateLimiter.RateLimitUpdated += value;
                MexcExchange.RateLimiter.RateLimitUpdated += value;
                OKXExchange.RateLimiter.RateLimitUpdated += value;
                PolymarketPlatform.RateLimiter.RateLimitUpdated += value;
                ToobitExchange.RateLimiter.RateLimitUpdated += value;
                UpbitExchange.RateLimiter.RateLimitUpdated += value;
                WhiteBitExchange.RateLimiter.RateLimitUpdated += value;
                XTExchange.RateLimiter.RateLimitUpdated += value;
            }
            remove
            {
                AsterExchange.RateLimiter.RateLimitUpdated -= value;
                BinanceExchange.RateLimiter.RateLimitUpdated -= value;
                BingXExchange.RateLimiter.RateLimitUpdated -= value;
                BitfinexExchange.RateLimiter.RateLimitUpdated -= value;
                BitgetExchange.RateLimiter.RateLimitUpdated -= value;
                BitMartExchange.RateLimiter.RateLimitUpdated -= value;
                BitMEXExchange.RateLimiter.RateLimitUpdated -= value;
                BitstampExchange.RateLimiter.RateLimitUpdated -= value;
                BloFinExchange.RateLimiter.RateLimitUpdated -= value;
                BybitExchange.RateLimiter.RateLimitUpdated -= value;
                CoinbaseExchange.RateLimiter.RateLimitUpdated -= value;
                CoinWExchange.RateLimiter.RateLimitUpdated -= value;
                CryptoComExchange.RateLimiter.RateLimitUpdated -= value;
                DeepCoinExchange.RateLimiter.RateLimitUpdated -= value;
                GateIoExchange.RateLimiter.RateLimitUpdated -= value;
                HTXExchange.RateLimiter.RateLimitUpdated -= value;
                HyperLiquidExchange.RateLimiter.RateLimitUpdated -= value;
                KrakenExchange.RateLimiter.RateLimitUpdated -= value;
                KucoinExchange.RateLimiter.RateLimitUpdated -= value;
                MexcExchange.RateLimiter.RateLimitUpdated -= value;
                OKXExchange.RateLimiter.RateLimitUpdated -= value;
                PolymarketPlatform.RateLimiter.RateLimitUpdated -= value;
                ToobitExchange.RateLimiter.RateLimitUpdated -= value;
                UpbitExchange.RateLimiter.RateLimitUpdated -= value;
                WhiteBitExchange.RateLimiter.RateLimitUpdated -= value;
                XTExchange.RateLimiter.RateLimitUpdated -= value;
            }
        }
    }
}
