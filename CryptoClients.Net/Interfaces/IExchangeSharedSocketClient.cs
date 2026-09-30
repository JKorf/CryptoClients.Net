using Aster.Net.Interfaces.Clients;
using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients;
using Bitstamp.Net.Interfaces.Clients;
using BloFin.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients;
using Coinbase.Net.Interfaces.Clients;
using CoinW.Net.Interfaces.Clients;
using CryptoClients.Net.Models;
using CryptoCom.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
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
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toobit.Net.Interfaces.Clients;
using Upbit.Net.Interfaces.Clients;
using Weex.Net.Interfaces.Clients;
using WhiteBit.Net.Interfaces.Clients;
using XT.Net.Interfaces.Clients;

namespace CryptoClients.Net.Interfaces
{
    /// <summary>
    /// Client for accessing the exchange Websocket API's.
    /// </summary>
    public interface IExchangeSharedSocketClient
    {
        /// <summary>
        /// Incoming kilobytes per second of data
        /// </summary>
        public double IncomingKbps { get; }
        /// <summary>
        /// The current number of connections to the API from this client. A connection can have multiple subscriptions
        /// </summary>
        public int CurrentConnections { get; }
        /// <summary>
        /// The current number of subscriptions running from the client
        /// </summary>
        public int CurrentSubscriptions { get; }

        /// <summary>
        /// Aster Websocket API
        /// </summary>
        IAsterSocketClient Aster { get; }
        /// <summary>
        /// Binance Websocket API
        /// </summary>
        IBinanceSocketClient Binance { get; }
        /// <summary>
        /// BingX Websocket API
        /// </summary>
        IBingXSocketClient BingX { get; }
        /// <summary>
        /// Bitfinex Websocket API
        /// </summary>
        IBitfinexSocketClient Bitfinex { get; }
        /// <summary>
        /// Bitget Websocket API
        /// </summary>
        IBitgetSocketClient Bitget { get; }
        /// <summary>
        /// Bitstamp Websocket API
        /// </summary>
        IBitstampSocketClient Bitstamp { get; }
        /// <summary>
        /// BloFin Websocket API
        /// </summary>
        IBloFinSocketClient BloFin { get; }
        /// <summary>
        /// Bybit Websocket API
        /// </summary>
        IBybitSocketClient Bybit { get; }
        /// <summary>
        /// Coinbase Websocket API
        /// </summary>
        ICoinbaseSocketClient Coinbase { get; }
        /// <summary>
        /// CoinW Websocket API
        /// </summary>
        ICoinWSocketClient CoinW { get; }
        /// <summary>
        /// Crypto.com Websocket API
        /// </summary>
        ICryptoComSocketClient CryptoCom { get; }
        /// <summary>
        /// DeepCoin Websocket API
        /// </summary>
        IDeepCoinSocketClient DeepCoin { get; }
        /// <summary>
        /// Gate.io Websocket API
        /// </summary>
        IGateIoSocketClient GateIo { get; }
        /// <summary>
        /// HTX Websocket API
        /// </summary>
        IHTXSocketClient HTX { get; }
        /// <summary>
        /// HyperLiquid Websocket API
        /// </summary>
        IHyperLiquidSocketClient HyperLiquid { get; }
        /// <summary>
        /// Kraken Websocket API
        /// </summary>
        IKrakenSocketClient Kraken { get; }
        /// <summary>
        /// Kucoin Websocket API
        /// </summary>
        IKucoinSocketClient Kucoin { get; }
        /// <summary>
        /// LBank Websocket API
        /// </summary>
        ILBankSocketClient LBank { get; }
        /// <summary>
        /// Lighter Websocket API
        /// </summary>
        ILighterSocketClient Lighter { get; }
        /// <summary>
        /// Mexc Websocket API
        /// </summary>
        IMexcSocketClient Mexc { get; }
        /// <summary>
        /// OKX Websocket API
        /// </summary>
        IOKXSocketClient OKX { get; }
        /// <summary>
        /// Pionex Websocket API
        /// </summary>
        IPionexSocketClient Pionex { get; }
        /// <summary>
        /// Polymarket Websocket API
        /// </summary>
        IPolymarketSocketClient Polymarket { get; }
        /// <summary>
        /// Toobit Websocket API
        /// </summary>
        IToobitSocketClient Toobit { get; }
        /// <summary>
        /// Upbit Websocket API
        /// </summary>
        IUpbitSocketClient Upbit { get; }
        /// <summary>
        /// Weex Websocket API
        /// </summary>
        IWeexSocketClient Weex { get; }
        /// <summary>
        /// WhiteBit Websocket API
        /// </summary>
        IWhiteBitSocketClient WhiteBit { get; }
        /// <summary>
        /// XT Websocket API
        /// </summary>
        IXTSocketClient XT { get; }

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
        /// Unsubscribe and close every connection
        /// </summary>
        /// <returns></returns>
        Task UnsubscribeAllAsync();
    }
}
