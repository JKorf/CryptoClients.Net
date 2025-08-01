﻿using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients;
using BitMart.Net.Interfaces.Clients;
using BitMEX.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients;
using Coinbase.Net.Interfaces.Clients;
using CoinEx.Net.Interfaces.Clients;
using CryptoClients.Net.Models;
using CryptoCom.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using DeepCoin.Net.Interfaces.Clients;
using GateIo.Net.Interfaces.Clients;
using HTX.Net.Interfaces.Clients;
using HyperLiquid.Net.Interfaces.Clients;
using Kraken.Net.Interfaces.Clients;
using Kucoin.Net.Interfaces.Clients;
using Mexc.Net.Interfaces.Clients;
using OKX.Net.Interfaces.Clients;
using Toobit.Net.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhiteBit.Net.Interfaces.Clients;
using XT.Net.Interfaces.Clients;
using CoinW.Net.Interfaces.Clients;

namespace CryptoClients.Net.Interfaces
{
    /// <summary>
    /// Client for accessing the exchange Websocket API's.
    /// </summary>
    public interface IExchangeSocketClient
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
        /// BitMart Websocket API
        /// </summary>
        IBitMartSocketClient BitMart { get; }
        /// <summary>
        /// BitMEX Websocket API
        /// </summary>
        IBitMEXSocketClient BitMEX { get; }
        /// <summary>
        /// Bybit Websocket API
        /// </summary>
        IBybitSocketClient Bybit { get; }
        /// <summary>
        /// Coinbase Websocket API
        /// </summary>
        ICoinbaseSocketClient Coinbase { get; }
        /// <summary>
        /// CoinEx Websocket API
        /// </summary>
        ICoinExSocketClient CoinEx { get; }
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
        /// Mexc Websocket API
        /// </summary>
        IMexcSocketClient Mexc { get; }
        /// <summary>
        /// OKX Websocket API
        /// </summary>
        IOKXSocketClient OKX { get; }
        /// <summary>
        /// Toobit Websocket API
        /// </summary>
        IToobitSocketClient Toobit { get; }
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
        /// Set API credentials for an exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        /// <param name="apiKey">API key</param>
        /// <param name="apiSecret">API secret</param>
        /// <param name="apiPass">API passphrase</param>
        void SetApiCredentials(string exchange, string apiKey, string apiSecret, string? apiPass = null);

        /// <summary>
        /// Return the exchange symbol name
        /// </summary>
        /// <param name="exchange">Exchange</param>
        /// <param name="symbol">Symbol</param>
        /// <returns></returns>
        string? GetSymbolName(string exchange, SharedSymbol symbol);

        /// <summary>
        /// Get all ISharedClient Socket Api interfaces supported for the specified exchange
        /// </summary>
        /// <param name="exchange">The exchange name</param>
        /// <param name="tradingMode">Filter clients by trading mode</param>
        IEnumerable<ISharedClient> GetExchangeSharedClients(string exchange, TradingMode? tradingMode = null);

        /// <summary>
        /// Get the <see cref="ITickerSocketClient"/> clients for all exchanges which have support for it
        /// </summary>
        IEnumerable<ITickerSocketClient> GetTickerClients();

        /// <summary>
        /// Get all <see cref="ITickerSocketClient"/> clients for all exchanges which have support for it and which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<ITickerSocketClient> GetTickerClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="ITickerSocketClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        ITickerSocketClient? GetTickerClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="ITickersSocketClient"/> clients for all exchanges which have support for it
        /// </summary>
        IEnumerable<ITickersSocketClient> GetTickersClients();
        /// <summary>
        /// Get all <see cref="ITickersSocketClient"/> clients for all exchanges which have support for it and which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<ITickersSocketClient> GetTickersClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="ITickersSocketClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        ITickersSocketClient? GetTickersClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="ITradeSocketClient"/> clients for all exchanges which have support for it
        /// </summary>
        IEnumerable<ITradeSocketClient> GetTradeClients();
        /// <summary>
        /// Get all <see cref="ITradeSocketClient"/> clients for all exchanges which have support for it and which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<ITradeSocketClient> GetTradeClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="ITradeSocketClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        ITradeSocketClient? GetTradeClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IBookTickerSocketClient"/> clients for all exchanges which have support for it
        /// </summary>
        IEnumerable<IBookTickerSocketClient> GetBookTickerClients();
        /// <summary>
        /// Get all <see cref="IBookTickerSocketClient"/> clients for all exchanges which have support for it and which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IBookTickerSocketClient> GetBookTickerClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IBookTickerSocketClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IBookTickerSocketClient? GetBookTickerClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IKlineSocketClient"/> clients for all exchanges which have support for it
        /// </summary>
        IEnumerable<IKlineSocketClient> GetKlineClients();
        /// <summary>
        /// Get all <see cref="IKlineSocketClient"/> clients for all exchanges which have support for it and which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IKlineSocketClient> GetKlineClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IKlineSocketClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IKlineSocketClient? GetKlineClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IOrderBookSocketClient"/> clients for all exchanges which have support for it
        /// </summary>
        IEnumerable<IOrderBookSocketClient> GetOrderBookClients();
        /// <summary>
        /// Get all <see cref="IOrderBookSocketClient"/> clients for all exchanges which have support for it and which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IOrderBookSocketClient> GetOrderBookClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IOrderBookSocketClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IOrderBookSocketClient? GetOrderBookClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IBalanceSocketClient"/> clients for all exchanges which have support for it
        /// </summary>
        IEnumerable<IBalanceSocketClient> GetBalanceClients();
        /// <summary>
        /// Get all <see cref="IBalanceSocketClient"/> clients for all exchanges which have support for it and which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IBalanceSocketClient> GetBalanceClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IBalanceSocketClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IBalanceSocketClient? GetBalanceClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="ISpotOrderSocketClient"/> clients for all exchanges which have support for it
        /// </summary>
        IEnumerable<ISpotOrderSocketClient> GetSpotOrderClients();
        /// <summary>
        /// Get the <see cref="ISpotOrderSocketClient"/> client for a specific exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        ISpotOrderSocketClient? GetSpotOrderClient(string exchange);

        /// <summary>
        /// Get the <see cref="IFuturesOrderSocketClient"/> clients for all exchanges which have support for it
        /// </summary>
        IEnumerable<IFuturesOrderSocketClient> GetFuturesOrderClients();
        /// <summary>
        /// Get all <see cref="IFuturesOrderSocketClient"/> clients for all exchanges which have support for it and which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IFuturesOrderSocketClient> GetFuturesOrderClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IFuturesOrderSocketClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IFuturesOrderSocketClient? GetFuturesOrderClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IUserTradeSocketClient"/> clients for all exchanges which have support for it
        /// </summary>
        IEnumerable<IUserTradeSocketClient> GetUserTradeClients();
        /// <summary>
        /// Get all <see cref="IUserTradeSocketClient"/> clients for all exchanges which have support for it and which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IUserTradeSocketClient> GetUserTradeClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IUserTradeSocketClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IUserTradeSocketClient? GetUserTradeClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IPositionSocketClient"/> clients for all exchanges which have support for it
        /// </summary>
        IEnumerable<IPositionSocketClient> GetPositionClients();
        /// <summary>
        /// Get all <see cref="IPositionSocketClient"/> clients for all exchanges which have support for it and which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IPositionSocketClient> GetPositionClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IPositionSocketClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IPositionSocketClient? GetPositionClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Subscribe to ticker updates for all symbols on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>> SubscribeToAllTickerUpdatesAsync(string exchange, SubscribeAllTickersRequest request, Action<ExchangeEvent<SharedSpotTicker[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates for all symbols on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>[]> SubscribeToAllTickerUpdatesAsync(SubscribeAllTickersRequest request, Action<ExchangeEvent<SharedSpotTicker[]>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates for a specific symbol on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string exchange, SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates for a specific symbol on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>[]> SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates for a symbol on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string exchange, SubscribeTradeRequest request, Action<ExchangeEvent<SharedTrade[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates for a symbol on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>[]> SubscribeToTradeUpdatesAsync(SubscribeTradeRequest request, Action<ExchangeEvent<SharedTrade[]>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to book ticker (best ask/bid price) updates for a symbol on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(string exchange, SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to book ticker (best ask/bid price) updates for a symbol on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>[]> SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline/candlestick updates for a symbol on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string exchange, SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline/candlestick updates for a symbol on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>[]> SubscribeToKlineUpdatesAsync(SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book snapshot updates for a symbol on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string exchange, SubscribeOrderBookRequest request, Action<ExchangeEvent<SharedOrderBook>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book snapshot updates for a symbol on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>[]> SubscribeToOrderBookUpdatesAsync(SubscribeOrderBookRequest request, Action<ExchangeEvent<SharedOrderBook>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user balance updates on on exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="listenKeyResults">Optional previously obtained listen keys used for subscribing to user data</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(
            string exchange,
            SubscribeBalancesRequest request,
            Action<ExchangeEvent<SharedBalance[]>> handler,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user balance updates on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="listenKeyResults">Optional previously obtained listen keys used for subscribing to user data</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>[]> SubscribeToBalanceUpdatesAsync(
            SubscribeBalancesRequest request,
            Action<ExchangeEvent<SharedBalance[]>> handler,
            IEnumerable<string>? exchanges = null,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user spot orders updates on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe</param>
        /// <param name="listenKeyResults">Optional previously obtained listen keys used for subscribing to user data</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>> SubscribeToSpotOrderUpdatesAsync(
            string exchange,
            SubscribeSpotOrderRequest request,
            Action<ExchangeEvent<SharedSpotOrder[]>> handler,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user spot orders updates on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="listenKeyResults">Optional previously obtained listen keys used for subscribing to user data</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>[]> SubscribeToSpotOrderUpdatesAsync(
            SubscribeSpotOrderRequest request,
            Action<ExchangeEvent<SharedSpotOrder[]>> handler,
            IEnumerable<string>? exchanges = null,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user futures orders updates on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe</param>
        /// <param name="listenKeyResults">Optional previously obtained listen keys used for subscribing to user data</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>> SubscribeToFuturesOrderUpdatesAsync(
            string exchange,
            SubscribeFuturesOrderRequest request,
            Action<ExchangeEvent<SharedFuturesOrder[]>> handler,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user futures orders updates on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="listenKeyResults">Optional previously obtained listen keys used for subscribing to user data</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>[]> SubscribeToFuturesOrderUpdatesAsync(
            SubscribeFuturesOrderRequest request,
            Action<ExchangeEvent<SharedFuturesOrder[]>> handler,
            IEnumerable<string>? exchanges = null,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade execution updates on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe</param>
        /// <param name="listenKeyResults">Optional previously obtained listen keys used for subscribing to user data</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(
            string exchange,
            SubscribeUserTradeRequest request,
            Action<ExchangeEvent<SharedUserTrade[]>> handler,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade execution updates on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="listenKeyResults">Optional previously obtained listen keys used for subscribing to user data</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>[]> SubscribeToUserTradeUpdatesAsync(
            SubscribeUserTradeRequest request,
            Action<ExchangeEvent<SharedUserTrade[]>> handler,
            IEnumerable<string>? exchanges = null,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user position updates on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe</param>
        /// <param name="listenKeyResults">Optional previously obtained listen keys used for subscribing to user data</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(
            string exchange,
            SubscribePositionRequest request,
            Action<ExchangeEvent<SharedPosition[]>> handler,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user position updates on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="listenKeyResults">Optional previously obtained listen keys used for subscribing to user data</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<ExchangeResult<UpdateSubscription>[]> SubscribeToPositionUpdatesAsync(
            SubscribePositionRequest request,
            Action<ExchangeEvent<SharedPosition[]>> handler,
            IEnumerable<string>? exchanges = null,
            ExchangeWebResult<string>[]? listenKeyResults = null,
            CancellationToken ct = default);

        /// <summary>
        /// Unsubscribe and close every connection
        /// </summary>
        /// <returns></returns>
        Task UnsubscribeAllAsync();
    }
}
