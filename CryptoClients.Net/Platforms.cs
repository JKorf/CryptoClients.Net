using Aster.Net;
using Binance.Net;
using BingX.Net;
using Bitfinex.Net;
using Bitget.Net;
using BitMart.Net;
using BitMEX.Net;
using BloFin.Net;
using Bybit.Net;
using Coinbase.Net;
using CoinEx.Net;
using CoinGecko.Net;
using CoinW.Net;
using CryptoCom.Net;
using CryptoExchange.Net.Objects;
using DeepCoin.Net;
using GateIo.Net;
using HTX.Net;
using HyperLiquid.Net;
using Kraken.Net;
using Kucoin.Net;
using Mexc.Net;
using OKX.Net;
using Polymarket.Net;
using Toobit.Net;
using Upbit.Net;
using WhiteBit.Net;
using XT.Net;

namespace CryptoClients.Net
{
    /// <summary>
    /// Information on supported platforms and universal functionality
    /// </summary>
    public static class Platforms
    {
        /// <summary>
        /// Aster platform info
        /// </summary>
        public static PlatformInfo Aster { get; } = AsterExchange.Metadata;

        /// <summary>
        /// Binance platform info
        /// </summary>
        public static PlatformInfo Binance { get; } = BinanceExchange.Metadata;

        /// <summary>
        /// BingX platform info
        /// </summary>
        public static PlatformInfo BingX { get; } = BingXExchange.Metadata;

        /// <summary>
        /// Bitfinex platform info
        /// </summary>
        public static PlatformInfo Bitfinex { get; } = BitfinexExchange.Metadata;

        /// <summary>
        /// Bitget platform info
        /// </summary>
        public static PlatformInfo Bitget { get; } = BitgetExchange.Metadata;

        /// <summary>
        /// BitMart platform info
        /// </summary>
        public static PlatformInfo BitMart { get; } = BitMartExchange.Metadata;

        /// <summary>
        /// BitMEX platform info
        /// </summary>
        public static PlatformInfo BitMEX { get; } = BitMEXExchange.Metadata;


        /// <summary>
        /// BloFin platform info
        /// </summary>
        public static PlatformInfo BloFin { get; } = BloFinExchange.Metadata;

        /// <summary>
        /// Bybit platform info
        /// </summary>
        public static PlatformInfo Bybit { get; } = BybitExchange.Metadata;

        /// <summary>
        /// Coinbase platform info
        /// </summary>
        public static PlatformInfo Coinbase { get; } = CoinbaseExchange.Metadata;

        /// <summary>
        /// CoinEx platform info
        /// </summary>
        public static PlatformInfo CoinEx { get; } = CoinExExchange.Metadata;

        /// <summary>
        /// CoinGecko info
        /// </summary>
        public static PlatformInfo CoinGecko { get; } = CoinGeckoApi.Metadata;

        /// <summary>
        /// CoinW platform info
        /// </summary>
        public static PlatformInfo CoinW { get; } = CoinWExchange.Metadata;

        /// <summary>
        /// Crypto.com platform info
        /// </summary>
        public static PlatformInfo CryptoCom { get; } = CryptoComExchange.Metadata;

        /// <summary>
        /// DeepCoin platform info
        /// </summary>
        public static PlatformInfo DeepCoin { get; } = DeepCoinExchange.Metadata;

        /// <summary>
        /// Gate platform info
        /// </summary>
        public static PlatformInfo GateIo { get; } = GateIoExchange.Metadata;

        /// <summary>
        /// HTX platform info
        /// </summary>
        public static PlatformInfo HTX { get; } = HTXExchange.Metadata;

        /// <summary>
        /// HyperLiquid platform info
        /// </summary>
        public static PlatformInfo HyperLiquid { get; } = HyperLiquidExchange.Metadata;

        /// <summary>
        /// Kraken platform info
        /// </summary>
        public static PlatformInfo Kraken { get; } = KrakenExchange.Metadata;

        /// <summary>
        /// Kucoin platform info
        /// </summary>
        public static PlatformInfo Kucoin { get; } = KucoinExchange.Metadata;

        /// <summary>
        /// Mexc platform info
        /// </summary>
        public static PlatformInfo Mexc { get; } = MexcExchange.Metadata;

        /// <summary>
        /// OKX platform info
        /// </summary>
        public static PlatformInfo OKX { get; } = OKXExchange.Metadata;

        /// <summary>
        /// Polymarket info
        /// </summary>
        public static PlatformInfo Polymarket { get; } = PolymarketPlatform.Metadata;

        /// <summary>
        /// Toobit platform info
        /// </summary>
        public static PlatformInfo Toobit { get; } = ToobitExchange.Metadata;

        /// <summary>
        /// Upbit platform info
        /// </summary>
        public static PlatformInfo Upbit { get; } = UpbitExchange.Metadata;

        /// <summary>
        /// WhiteBit platform info
        /// </summary>
        public static PlatformInfo WhiteBit { get; } = WhiteBitExchange.Metadata;

        /// <summary>
        /// XT platform info
        /// </summary>
        public static PlatformInfo XT { get; } = XTExchange.Metadata;

        /// <summary>
        /// Information on all supported platforms
        /// </summary>
        public static PlatformInfo[] All { get; } = new[]
        {
            Aster,
            Binance,
            BingX,
            Bitfinex,
            Bitget,
            BitMart,
            BitMEX,
            BloFin,
            Bybit,
            Coinbase,
            CoinEx,
            CoinGecko,
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
            Polymarket,
            Toobit,
            Upbit,
            WhiteBit,
            XT
        };
    }
}
