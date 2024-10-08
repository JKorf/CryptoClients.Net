using Binance.Net;
using BingX.Net;
using Bitfinex.Net;
using Bitget.Net;
using BitMart.Net;
using Bybit.Net;
using Coinbase.Net;
using CoinEx.Net;
using GateIo.Net;
using HTX.Net;
using Kraken.Net;
using Kucoin.Net;
using Mexc.Net;
using OKX.Net;
using System.Collections;
using System.Collections.Generic;

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
        /// Gate.io
        /// </summary>
        public static string GateIo => "GateIo";
        /// <summary>
        /// HTX
        /// </summary>
        public static string HTX => HTXExchange.ExchangeName;
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
        /// All exchange names
        /// </summary>
        public static string[] All { get; } = new[]
        {
            Binance,
            BingX,
            Bitfinex,
            Bitget,
            BitMart,
            Bybit,
            Coinbase,
            CoinEx,
            GateIo,
            HTX,
            Kraken,
            Kucoin,
            Mexc,
            OKX
        };
    }
}
