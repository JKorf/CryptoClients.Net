using Aster.Net;
using Aster.Net.Objects;
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
using CryptoExchange.Net.SharedApis;
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
using System;
using System.Collections.Generic;
using Toobit.Net;
using WhiteBit.Net;
using XT.Net;

namespace CryptoClients.Net.Models
{
    public class DynamicCredentialInfo
    {
        public string Exchange { get; set; }

        public bool Param1Required { get; set; }
        public string? Param1Description { get; set; }
        public bool Param2Required { get; set; }
        public string? Param2Description { get; set; }
        public bool Param3Required { get; set; }
        public string? Param3Description { get; set; }
    }

    public class DynamicCredentials
    {
        /// <summary>
        /// Trading mode
        /// </summary>
        public TradingMode TradingMode { get; set; }
        /// <summary>
        /// The key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// First param, generally the API secret or private key
        /// </summary>
        public string? Param1 { get; set; }
        /// <summary>
        /// Second param, generally the passphrase
        /// </summary>
        public string? Param2 { get; set; }
        /// <summary>
        /// Third param
        /// </summary>
        public string? Param3 { get; set; }
    }

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
        /// Get dynamic credential info for an exchange, which specifies what parameters are required to create credentials for that exchange. 
        /// This is used to dynamically create credentials for an exchange without having to know the specific type of credentials required for that exchange. 
        /// For example, Binance requires the API key and API secret as parameters to create credentials, so Param1Required would be true and Param1Description would be "API secret".
        /// </summary>
        /// <param name="mode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        /// <returns></returns>
        public static DynamicCredentialInfo? GetDynamicCredentialInfo(TradingMode mode, string exchange)
        {
            return Exchanges.GetByName(exchange)?.DynamicCredentialInfo(mode);
        }

        /// <summary>
        /// Create credentials for an exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        /// <param name="credential">Credential</param>
        public static ApiCredentials CreateCredentialsForExchange(string exchange, DynamicCredentials credential)
        {
            if (exchange == "Aster")
            {
                if (credential.TradingMode == TradingMode.Spot)
                {
                    return new AsterCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
                }
                else
                {
                    return new AsterCredentials(
                        new AsterV3Credential(
                            credential.Key,
                            credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
                }
            }
            else if (exchange == "Binance")
            {
                return new BinanceCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "BingX")
            {
                return new BingXCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "Bitfinex")
            {
                return new BitfinexCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "Bitget")
            {
                return new BitgetCredentials(
                    credential.Key,
                    credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)),
                    credential.Param2 ?? throw new ArgumentNullException(nameof(credential.Param2)));
            }
            else if (exchange == "BitMart")
            {
                return new BitMartCredentials(
                    credential.Key,
                    credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)),
                    credential.Param2 ?? throw new ArgumentNullException(nameof(credential.Param2)));
            }
            else if (exchange == "BitMEX")
            {
                return new BitMEXCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "Bitstamp")
            {
                return new BitstampCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "BloFin")
            {
                return new BloFinCredentials(
                    credential.Key,
                    credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)),
                    credential.Param2 ?? throw new ArgumentNullException(nameof(credential.Param2)));
            }
            else if (exchange == "Bybit")
            {
                return new BybitCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "Coinbase")
            {
                return new CoinbaseCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "CoinEx")
            {
                return new CoinExCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "CoinGecko")
            {
                return new CoinGeckoCredentials(credential.Key);
            }
            else if (exchange == "CoinW")
            {
                return new CoinWCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "CryptoCom")
            {
                return new CryptoComCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "DeepCoin")
            {
                return new DeepCoinCredentials(
                    credential.Key,
                    credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)),
                    credential.Param2 ?? throw new ArgumentNullException(nameof(credential.Param2)));
            }
            else if (exchange == "GateIo")
            {
                return new GateIoCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "HTX")
            {
                return new HTXCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "HyperLiquid")
            {
                return new HyperLiquidCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "Kraken")
            {
                if (credential.TradingMode == TradingMode.Spot)
                    return new KrakenCredentials(new HMACCredential(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1))), null);

                return new KrakenCredentials(null, new HMACCredential(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1))));
            }
            else if (exchange == "Kucoin")
            {
                return new KucoinCredentials(
                    credential.Key,
                    credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)),
                    credential.Param2 ?? throw new ArgumentNullException(nameof(credential.Param2)));
            }
            else if (exchange == "Mexc")
            {
                return new MexcCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "OKX")
            {
                return new OKXCredentials(
                    credential.Key,
                    credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)),
                    credential.Param2 ?? throw new ArgumentNullException(nameof(credential.Param2)));
            }
            else if (exchange == "Polymarket")
            {
                throw new ArgumentException("Polymarket not supported");
            }
            else if (exchange == "Toobit")
            {
                return new ToobitCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "WhiteBit")
            {
                return new WhiteBitCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            else if (exchange == "XT")
            {
                return new XTCredentials(credential.Key, credential.Param1 ?? throw new ArgumentNullException(nameof(credential.Param1)));
            }
            
            throw new ArgumentException("Unknown exchange name: " + exchange);
        }

        /// <summary>
        /// Create credentials from a dictionary of exchange name to credentials. Dictionary key should be the exchange name, value should be credentials of the correct type for that exchange. For example, for Binance, the value should be of type BinanceCredentials.
        /// </summary>
        /// <param name="exchangeCredentials">Credentials, dictionary key should be the exchange name, value should be credentials of the correct type for that exchange. For example, for Binance, the value should be of type BinanceCredentials.</param>
        public static ExchangeCredentials From(Dictionary<string, ApiCredentials> exchangeCredentials)
        {
            var creds = new ExchangeCredentials();
            foreach (var item in exchangeCredentials)
            {
                if (item.Key == "Aster") creds.Aster = item.Value as AsterCredentials;
                else if (item.Key == "Binance") creds.Binance = item.Value as BinanceCredentials;
                else if (item.Key == "BingX") creds.BingX = item.Value as BingXCredentials;
                else if (item.Key == "Bitfinex") creds.Bitfinex = item.Value as BitfinexCredentials;
                else if (item.Key == "Bitget") creds.Bitget = item.Value as BitgetCredentials;
                else if (item.Key == "BitMart") creds.BitMart = item.Value as BitMartCredentials;
                else if (item.Key == "BitMEX") creds.BitMEX = item.Value as BitMEXCredentials;
                else if (item.Key == "Bitstamp") creds.Bitstamp = item.Value as BitstampCredentials;
                else if (item.Key == "BloFin") creds.BloFin = item.Value as BloFinCredentials;
                else if (item.Key == "Bybit") creds.Bybit = item.Value as BybitCredentials;
                else if (item.Key == "Coinbase") creds.Coinbase = item.Value as CoinbaseCredentials;
                else if (item.Key == "CoinEx") creds.CoinEx = item.Value as CoinExCredentials;
                else if (item.Key == "CoinGecko") creds.CoinGecko = item.Value as CoinGeckoCredentials;
                else if (item.Key == "CoinW") creds.CoinW = item.Value as CoinWCredentials;
                else if (item.Key == "CryptoCom") creds.CryptoCom = item.Value as CryptoComCredentials;
                else if (item.Key == "DeepCoin") creds.DeepCoin = item.Value as DeepCoinCredentials;
                else if (item.Key == "GateIo") creds.GateIo = item.Value as GateIoCredentials;
                else if (item.Key == "HTX") creds.HTX = item.Value as HTXCredentials;
                else if (item.Key == "HyperLiquid") creds.HyperLiquid = item.Value as HyperLiquidCredentials;
                else if (item.Key == "Kraken") creds.Kraken = item.Value as KrakenCredentials;
                else if (item.Key == "Kucoin") creds.Kucoin = item.Value as KucoinCredentials;
                else if (item.Key == "Mexc") creds.Mexc = item.Value as MexcCredentials;
                else if (item.Key == "OKX") creds.OKX = item.Value as OKXCredentials;
                else if (item.Key == "Polymarket") creds.Polymarket = item.Value as PolymarketCredentials;
                else if (item.Key == "Toobit") creds.Toobit = item.Value as ToobitCredentials;
                else if (item.Key == "WhiteBit") creds.WhiteBit = item.Value as WhiteBitCredentials;
                else if (item.Key == "XT") creds.XT = item.Value as XTCredentials;
                else
                    throw new ArgumentException("Unknown exchange name: " + item.Key);
            }

            return creds;
        }

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
