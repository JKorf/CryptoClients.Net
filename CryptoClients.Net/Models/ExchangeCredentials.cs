using Aster.Net;
using Binance.Net;
using BingX.Net;
using Bitfinex.Net;
using Bitget.Net;
using Bitget.Net.Objects;
using BitMart.Net;
using BitMart.Net.Objects;
using BitMEX.Net;
using Bitstamp.Net;
using BloFin.Net;
using Bybit.Net;
using Coinbase.Net;
using CoinEx.Net;
using CoinGecko.Net;
using CoinW.Net;
using CryptoCom.Net;
using CryptoExchange.Net.Authentication;
using DeepCoin.Net;
using DeepCoin.Net.Objects;
using GateIo.Net;
using HTX.Net;
using HyperLiquid.Net;
using Kraken.Net;
using Kucoin.Net;
using Kucoin.Net.Objects;
using Mexc.Net;
using OKX.Net;
using OKX.Net.Objects;
using Polymarket.Net;
using Polymarket.Net.Objects;
using System.Collections.Generic;
using Toobit.Net;
using WhiteBit.Net;
using XT.Net;

namespace CryptoClients.Net.Models
{
    /// <summary>
    /// Credentials for each exchange
    /// </summary>
    public class ExchangeCredentials
    {
        /// <summary>
        /// ctor
        /// </summary>
        public ExchangeCredentials() { }

        ///// <summary>
        ///// ctor
        ///// </summary>
        ///// <param name="exchangeCredentials">Api credentials, key should be the exchange name</param>
        //public ExchangeCredentials(Dictionary<string, ApiCredentials> exchangeCredentials)
        //{
        //    foreach(var item in exchangeCredentials)
        //    {
        //        switch (item.Key)
        //        {
        //            case "Aster": Aster = item.Value; break;
        //            case "Binance": Binance = item.Value; break;
        //            case "BingX": BingX = item.Value; break;
        //            case "Bitfinex": Bitfinex = item.Value; break;
        //            case "Bitget": Bitget = item.Value; break;
        //            case "BitMart": BitMart = item.Value; break;
        //            case "BitMEX": BitMEX = item.Value; break;
        //            case "Bitstamp": Bitstamp = item.Value; break;
        //            case "BloFin": BloFin = item.Value; break;
        //            case "Bybit": Bybit = item.Value; break;
        //            case "Coinbase": Coinbase = item.Value; break;
        //            case "CoinEx": CoinEx = item.Value; break;
        //            case "CoinW": CoinW = item.Value; break;
        //            case "CryptoCom": CryptoCom = item.Value; break;
        //            case "DeepCoin": DeepCoin = item.Value; break;
        //            case "GateIo": GateIo = item.Value; break;
        //            case "HTX": HTX = item.Value; break;
        //            case "HyperLiquid": HyperLiquid = item.Value; break;
        //            case "Kraken": Kraken = item.Value; break;
        //            case "Kucoin": Kucoin = item.Value; break;
        //            case "Mexc": Mexc = item.Value; break;
        //            case "OKX": OKX = item.Value; break;
        //            case "Polymarket": Polymarket = (PolymarketCredentials)item.Value; break;
        //            case "Toobit": Toobit = item.Value; break;
        //            case "Upbit": Upbit = item.Value; break;
        //            case "WhiteBit": WhiteBit = item.Value; break;
        //            case "XT": XT = item.Value; break;
        //            default:
        //                throw new System.ArgumentException("Unknown exchange name: " + item.Key);
        //        }
        //    }
        //}

        /// <summary>
        /// Aster API credentials
        /// </summary>
        public AsterCredentials? Aster { get; set; }

        /// <summary>
        /// Binance API credentials
        /// </summary>
        public BinanceCredentials? Binance { get; set; }

        /// <summary>
        /// BingX API credentials
        /// </summary>
        public BingXCredentials? BingX { get; set; }

        /// <summary>
        /// Bitfinex API credentials
        /// </summary>
        public BitfinexCredentials? Bitfinex { get; set; }

        /// <summary>
        /// Bitget API credentials
        /// </summary>
        public BitgetCredentials? Bitget { get; set; }

        /// <summary>
        /// BitMart API credentials
        /// </summary>
        public BitMartCredentials? BitMart { get; set; }

        /// <summary>
        /// BitMEX API credentials
        /// </summary>
        public BitMEXCredentials? BitMEX { get; set; }

        /// <summary>
        /// Bitstamp API credentials
        /// </summary>
        public BitstampCredentials? Bitstamp { get; set; }

        /// <summary>
        /// BloFin API credentials
        /// </summary>
        public BloFinCredentials? BloFin { get; set; }

        /// <summary>
        /// Bybit API credentials
        /// </summary>
        public BybitCredentials? Bybit { get; set; }

        /// <summary>
        /// Coinbase API credentials
        /// </summary>
        public CoinbaseCredentials? Coinbase { get; set; }

        /// <summary>
        /// CoinEx API credentials
        /// </summary>
        public CoinExCredentials? CoinEx { get; set; }

        /// <summary>
        /// CoinGecko API credentials
        /// </summary>
        public CoinGeckoCredentials? CoinGecko { get; set; }

        /// <summary>
        /// CoinW API credentials
        /// </summary>
        public CoinWCredentials? CoinW { get; set; }

        /// <summary>
        /// Crypto.com API credentials
        /// </summary>
        public CryptoComCredentials? CryptoCom { get; set; }

        /// <summary>
        /// DeepCoin API credentials
        /// </summary>
        public DeepCoinCredentials? DeepCoin { get; set; }

        /// <summary>
        /// Gate.io API credentials
        /// </summary>
        public GateIoCredentials? GateIo { get; set; }

        /// <summary>
        /// HTX API credentials
        /// </summary>
        public HTXCredentials? HTX { get; set; }

        /// <summary>
        /// HyperLiquid API credentials
        /// </summary>
        public HyperLiquidCredentials? HyperLiquid { get; set; }

        /// <summary>
        /// Kraken API credentials
        /// </summary>
        public KrakenCredentials? Kraken { get; set; }

        /// <summary>
        /// Kucoin API credentials
        /// </summary>
        public KucoinCredentials? Kucoin { get; set; }

        /// <summary>
        /// Mexc API credentials
        /// </summary>
        public MexcCredentials? Mexc { get; set; }

        /// <summary>
        /// OKX API credentials
        /// </summary>
        public OKXCredentials? OKX { get; set; }

        /// <summary>
        /// Polymarket API credentials
        /// </summary>
        public PolymarketCredentials? Polymarket { get; set; }

        /// <summary>
        /// Toobit API credentials
        /// </summary>
        public ToobitCredentials? Toobit { get; set; }

        /// <summary>
        /// WhiteBit API credentials
        /// </summary>
        public WhiteBitCredentials? WhiteBit { get; set; }

        /// <summary>
        /// XT API credentials
        /// </summary>
        public XTCredentials? XT { get; set; }

        /// <summary>
        /// Get credentials for an exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        public ApiCredentials? GetCredentials(string exchange)
        {
            switch (exchange)
            {
                case "Aster": return Aster;
                case "Binance": return Binance;
                case "BingX": return BingX;
                case "Bitfinex": return Bitfinex;
                case "Bitget": return Bitget;
                case "BitMart": return BitMart;
                case "BitMEX": return BitMEX;
                case "Bitstamp": return Bitstamp;
                case "BloFin": return BloFin;
                case "Bybit": return Bybit;
                case "Coinbase": return Coinbase;
                case "CoinEx": return CoinEx;
                case "CoinGecko": return CoinGecko;
                case "CoinW": return CoinW;
                case "CryptoCom": return CryptoCom;
                case "DeepCoin": return DeepCoin;
                case "GateIo": return GateIo;
                case "HTX": return HTX;
                case "HyperLiquid": return HyperLiquid;
                case "Kraken": return Kraken;
                case "Kucoin": return Kucoin;
                case "Mexc": return Mexc;
                case "OKX": return OKX;
                case "Polymarket": return Polymarket;
                case "Toobit": return Toobit;
                case "Upbit": return null;
                case "WhiteBit": return WhiteBit;
                case "XT": return XT;
                default:
                    throw new System.ArgumentException("Unknown exchange name: " + exchange);
            }
        }
    }
}
