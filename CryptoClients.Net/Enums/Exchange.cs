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
using CoinW.Net;
using CryptoCom.Net;
using DeepCoin.Net;
using GateIo.Net;
using HTX.Net;
using HyperLiquid.Net;
using Kraken.Net;
using Kucoin.Net;
using Mexc.Net;
using OKX.Net;
using System.Collections;
using System.Collections.Generic;
using Toobit.Net;
using WhiteBit.Net;
using XT.Net;

namespace CryptoClients.Net.Enums
{
    /// <summary>
    /// Exchange
    /// </summary>
    public static class Exchange
    {
        /// <summary>
        /// Binance
        /// </summary>
        public static string Binance => BinanceExchange.ExchangeName;
        /// <summary>
        /// BingX
        /// </summary>
        public static string BingX => BingXExchange.ExchangeName;
        /// <summary>
        /// Bitfinex
        /// </summary>
        public static string Bitfinex => BitfinexExchange.ExchangeName;
        /// <summary>
        /// Bitget
        /// </summary>
        public static string Bitget => BitgetExchange.ExchangeName;
        /// <summary>
        /// BitMart
        /// </summary>
        public static string BitMart => BitMartExchange.ExchangeName;
        /// <summary>
        /// BitMEX
        /// </summary>
        public static string BitMEX => BitMEXExchange.ExchangeName;
        /// <summary>
        /// BloFin
        /// </summary>
        public static string BloFin => BloFinExchange.ExchangeName;
        /// <summary>
        /// Bybit
        /// </summary>
        public static string Bybit => BybitExchange.ExchangeName;
        /// <summary>
        /// Coinbase
        /// </summary>
        public static string Coinbase => CoinbaseExchange.ExchangeName;
        /// <summary>
        /// CoinEx
        /// </summary>
        public static string CoinEx => CoinExExchange.ExchangeName;
        /// <summary>
        /// CoinW
        /// </summary>
        public static string CoinW => CoinWExchange.ExchangeName;
        /// <summary>
        /// Crypto.com
        /// </summary>
        public static string CryptoCom => CryptoComExchange.ExchangeName;
        /// <summary>
        /// DeepCoin
        /// </summary>
        public static string DeepCoin => DeepCoinExchange.ExchangeName;
        /// <summary>
        /// Gate.io
        /// </summary>
        public static string GateIo => GateIoExchange.ExchangeName;
        /// <summary>
        /// HTX
        /// </summary>
        public static string HTX => HTXExchange.ExchangeName;
        /// <summary>
        /// HyperLiquid
        /// </summary>
        public static string HyperLiquid => HyperLiquidExchange.ExchangeName;
        /// <summary>
        /// Kraken
        /// </summary>
        public static string Kraken => KrakenExchange.ExchangeName;
        /// <summary>
        /// Kucoin
        /// </summary>
        public static string Kucoin => KucoinExchange.ExchangeName;
        /// <summary>
        /// Mexc
        /// </summary>
        public static string Mexc => MexcExchange.ExchangeName;
        /// <summary>
        /// OKX
        /// </summary>
        public static string OKX => OKXExchange.ExchangeName;
        /// <summary>
        /// Toobit
        /// </summary>
        public static string Toobit => ToobitExchange.ExchangeName;
        /// <summary>
        /// WhiteBit
        /// </summary>
        public static string WhiteBit => WhiteBitExchange.ExchangeName;
        /// <summary>
        /// XT
        /// </summary>
        public static string XT => XTExchange.ExchangeName;

        /// <summary>
        /// All exchange names
        /// </summary>
        public static string[] All { get; } = new[]
        {
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
            CoinW,
            CryptoCom,
            DeepCoin,
            GateIo,
            HTX,
            HyperLiquid,
            Kraken,
            Kucoin,
            Mexc,
            OKX,
            Toobit,
            WhiteBit,
            XT
        };
    }
}
