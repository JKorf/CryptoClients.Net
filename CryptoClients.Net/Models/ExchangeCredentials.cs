using Bitget.Net.Objects;
using BitMart.Net.Objects;
using CryptoExchange.Net.Authentication;
using DeepCoin.Net.Objects;
using Kucoin.Net.Objects;
using OKX.Net.Objects;
using System.Collections.Generic;

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

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="exchangeCredentials">Api credentials, key should be the exchange name</param>
        public ExchangeCredentials(Dictionary<string, ApiCredentials> exchangeCredentials)
        {
            foreach(var item in exchangeCredentials)
            {
                switch (item.Key)
                {
                    case "Binance": Binance = item.Value; break;
                    case "BingX": BingX = item.Value; break;
                    case "Bitfinex": Bitfinex = item.Value; break;
                    case "Bitget": Bitget = item.Value; break;
                    case "BitMart": BitMart = item.Value; break;
                    case "BitMEX": BitMEX = item.Value; break;
                    case "Bybit": Bybit = item.Value; break;
                    case "Coinbase": Coinbase = item.Value; break;
                    case "CoinEx": CoinEx = item.Value; break;
                    case "CryptoCom": CryptoCom = item.Value; break;
                    case "DeepCoin": DeepCoin = item.Value; break;
                    case "GateIo": GateIo = item.Value; break;
                    case "HTX": HTX = item.Value; break;
                    case "HyperLiquid": HyperLiquid = item.Value; break;
                    case "Kraken": Kraken = item.Value; break;
                    case "Kucoin": Kucoin = item.Value; break;
                    case "Mexc": Mexc = item.Value; break;
                    case "OKX": OKX = item.Value; break;
                    case "Toobit": Toobit = item.Value; break;
                    case "WhiteBit": WhiteBit = item.Value; break;
                    case "XT": XT = item.Value; break;
                    default:
                        throw new System.ArgumentException("Unknown exchange name: " + item.Key);
                }
            }
        }

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
        public ApiCredentials? Bitget { get; set; }

        /// <summary>
        /// BitMart API credentials
        /// </summary>
        public ApiCredentials? BitMart { get; set; }

        /// <summary>
        /// BitMEX API credentials
        /// </summary>
        public ApiCredentials? BitMEX { get; set; }

        /// <summary>
        /// Bybit API credentials
        /// </summary>
        public ApiCredentials? Bybit { get; set; }

        /// <summary>
        /// Coinbase API credentials
        /// </summary>
        public ApiCredentials? Coinbase { get; set; }

        /// <summary>
        /// CoinEx API credentials
        /// </summary>
        public ApiCredentials? CoinEx { get; set; }

        /// <summary>
        /// Crypto.com API credentials
        /// </summary>
        public ApiCredentials? CryptoCom { get; set; }

        /// <summary>
        /// DeepCoin API credentials
        /// </summary>
        public ApiCredentials? DeepCoin { get; set; }

        /// <summary>
        /// Gate.io API credentials
        /// </summary>
        public ApiCredentials? GateIo { get; set; }

        /// <summary>
        /// HTX API credentials
        /// </summary>
        public ApiCredentials? HTX { get; set; }

        /// <summary>
        /// HyperLiquid API credentials
        /// </summary>
        public ApiCredentials? HyperLiquid { get; set; }

        /// <summary>
        /// Kraken API credentials
        /// </summary>
        public ApiCredentials? Kraken { get; set; }

        /// <summary>
        /// Kucoin API credentials
        /// </summary>
        public ApiCredentials? Kucoin { get; set; }

        /// <summary>
        /// Mexc API credentials
        /// </summary>
        public ApiCredentials? Mexc { get; set; }

        /// <summary>
        /// OKX API credentials
        /// </summary>
        public ApiCredentials? OKX { get; set; }


        /// <summary>
        /// Toobit API credentials
        /// </summary>
        public ApiCredentials? Toobit { get; set; }

        /// <summary>
        /// WhiteBit API credentials
        /// </summary>
        public ApiCredentials? WhiteBit { get; set; }

        /// <summary>
        /// XT API credentials
        /// </summary>
        public ApiCredentials? XT { get; set; }
    }
}
