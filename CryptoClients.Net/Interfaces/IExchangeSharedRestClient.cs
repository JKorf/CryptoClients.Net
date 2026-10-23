using Aster.Net.Interfaces.Clients;
using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients;
using Bitstamp.Net.Interfaces.Clients;
using Bitunix.Net.Interfaces.Clients;
using BloFin.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients;
using Coinbase.Net.Interfaces.Clients;
using CoinW.Net.Interfaces.Clients;
using CryptoClients.Net.Models;
using CryptoCom.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using DeepCoin.Net.Interfaces.Clients;
using GateIo.Net.Interfaces.Clients;
using HTX.Net.Interfaces.Clients;
using HyperLiquid.Net.Interfaces.Clients;
using Kraken.Net.Interfaces.Clients;
using Kucoin.Net.Interfaces.Clients;
using LBank.Net.Interfaces.Clients;
using Lighter.Net.Interfaces.Clients;
using Mexc.Net.Interfaces.Clients;
using OKX.Net.Interfaces.Clients;
using Pionex.Net.Interfaces.Clients;
using Polymarket.Net.Interfaces.Clients;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tapbit.Net.Interfaces.Clients;
using Toobit.Net.Interfaces.Clients;
using Upbit.Net.Interfaces.Clients;
using Weex.Net.Interfaces.Clients;
using WhiteBit.Net.Interfaces.Clients;
using XT.Net.Interfaces.Clients;

namespace CryptoClients.Net.Interfaces
{
    /// <summary>
    /// Client for accessing the exchange REST API's.
    /// </summary>
    public interface IExchangeSharedRestClient
    {
        /// <summary>
        /// Total number of requests made
        /// </summary>
        public int TotalRequestsMade { get; }

        /// <summary>
        /// Aster REST API
        /// </summary>
        IAsterRestClient Aster { get; }
        /// <summary>
        /// Binance REST API
        /// </summary>
        IBinanceRestClient Binance { get; }
        /// <summary>
        /// BingX REST API
        /// </summary>
        IBingXRestClient BingX { get; }
        /// <summary>
        /// Bitfinex REST API
        /// </summary>
        IBitfinexRestClient Bitfinex { get; }
        /// <summary>
        /// Bitget REST API
        /// </summary>
        IBitgetRestClient Bitget { get; }
        /// <summary>
        /// Bitstamp REST API
        /// </summary>
        IBitstampRestClient Bitstamp { get; }
        /// <summary>
        /// Bitunix REST API
        /// </summary>
        IBitunixRestClient Bitunix { get; }
        /// <summary>
        /// BloFin REST API
        /// </summary>
        IBloFinRestClient BloFin { get; }
        /// <summary>
        /// Bybit REST API
        /// </summary>
        IBybitRestClient Bybit { get; }
        /// <summary>
        /// Coinbase REST API
        /// </summary>
        ICoinbaseRestClient Coinbase { get; }
        /// <summary>
        /// CoinW REST API
        /// </summary>
        ICoinWRestClient CoinW { get; }
        /// <summary>
        /// Crypto.com REST API
        /// </summary>
        ICryptoComRestClient CryptoCom { get; }
        /// <summary>
        /// DeepCoin REST API
        /// </summary>
        IDeepCoinRestClient DeepCoin { get; }
        /// <summary>
        /// Gate.io REST API
        /// </summary>
        IGateIoRestClient GateIo { get; }
        /// <summary>
        /// HTX REST API
        /// </summary>
        IHTXRestClient HTX { get; }
        /// <summary>
        /// HyperLiquid REST API
        /// </summary>
        IHyperLiquidRestClient HyperLiquid { get; }
        /// <summary>
        /// Kraken REST API
        /// </summary>
        IKrakenRestClient Kraken { get; }
        /// <summary>
        /// Kucoin REST API
        /// </summary>
        IKucoinRestClient Kucoin { get; }
        /// <summary>
        /// LBank REST API
        /// </summary>
        ILBankRestClient LBank { get; }
        /// <summary>
        /// Lighter REST API
        /// </summary>
        ILighterRestClient Lighter { get; }
        /// <summary>
        /// Mexc REST API
        /// </summary>
        IMexcRestClient Mexc { get; }
        /// <summary>
        /// OKX REST API
        /// </summary>
        IOKXRestClient OKX { get; }
        /// <summary>
        /// Pionex REST API
        /// </summary>
        IPionexRestClient Pionex { get; }
        /// <summary>
        /// Polymarket REST API
        /// </summary>
        IPolymarketRestClient Polymarket { get; }
        /// <summary>
        /// Tapbit REST API
        /// </summary>
        ITapbitRestClient Tapbit { get; }
        /// <summary>
        /// Toobit REST API
        /// </summary>
        IToobitRestClient Toobit { get; }
        /// <summary>
        /// Upbit REST API
        /// </summary>
        IUpbitRestClient Upbit { get; }
        /// <summary>
        /// Weex REST API
        /// </summary>
        IWeexRestClient Weex { get; }
        /// <summary>
        /// WhiteBit REST API
        /// </summary>
        IWhiteBitRestClient WhiteBit { get; }
        /// <summary>
        /// XT REST API
        /// </summary>
        IXTRestClient XT { get; }

        /// <summary>
        /// Set API credentials for exchanges
        /// </summary>
        /// <param name="credentials">Credential info</param>
        void SetApiCredentials(ExchangeCredentials credentials);

        /// <summary>
        /// Set API credentials for exchanges using dynamic credentials.
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        /// <param name="credentials">Credentials</param>
        void SetApiCredentials(string exchange, DynamicCredentials credentials);

        /// <summary>
        /// Return the exchange symbol name
        /// </summary>
        /// <param name="exchange">Exchange</param>
        /// <param name="symbol">Symbol</param>
        /// <returns></returns>
        string? GetSymbolName(string exchange, SharedSymbol symbol);

        /// <summary>
        /// Generate a new random client order id
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange</param>
        string? GenerateClientOrderId(TradingMode tradingMode, string exchange);
    }
}
