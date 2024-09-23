using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients;
using BitMart.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients;
using CoinEx.Net.Interfaces.Clients;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Models;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis.Interfaces;
using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using CryptoExchange.Net.SharedApis.Interfaces.Socket.Futures;
using CryptoExchange.Net.SharedApis.Interfaces.Socket.Spot;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.Socket;
using CryptoExchange.Net.SharedApis.ResponseModels;
using GateIo.Net.Interfaces.Clients;
using HTX.Net.Interfaces.Clients;
using Kraken.Net.Interfaces.Clients;
using Kucoin.Net.Interfaces.Clients;
using Mexc.Net.Interfaces.Clients;
using OKX.Net.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClients.Net.Interfaces
{
    /// <summary>
    /// Client for accessing the exchange Websocket API's.
    /// </summary>
    public interface IExchangeSocketClient
    {
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
        /// Bybit Websocket API
        /// </summary>
        IBybitSocketClient Bybit { get; }
        /// <summary>
        /// CoinEx Websocket API
        /// </summary>
        ICoinExSocketClient CoinEx { get; }
        /// <summary>
        /// Gate.io Websocket API
        /// </summary>
        IGateIoSocketClient GateIo { get; }
        /// <summary>
        /// HTX Websocket API
        /// </summary>
        IHTXSocketClient HTX { get; }
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

        IEnumerable<ISharedClient> GetExchangeSharedClients(string exchange);

        IEnumerable<ITickerSocketClient> GetTickerClients();
        IEnumerable<ITickerSocketClient> GetTickerClients(TradingMode apiType);
        ITickerSocketClient? TickerClient(TradingMode api, string exchange);

        IEnumerable<ITickersSocketClient> GetTickersClients();
        IEnumerable<ITickersSocketClient> GetTickersClients(TradingMode apiType);
        ITickersSocketClient? TickersClient(TradingMode api, string exchange);

        IEnumerable<ITradeSocketClient> GetTradeClients();
        IEnumerable<ITradeSocketClient> GetTradeClients(TradingMode apiType);
        ITradeSocketClient? TradeClient(TradingMode api, string exchange);

        IEnumerable<IBookTickerSocketClient> GetBookTickerClients();
        IEnumerable<IBookTickerSocketClient> GetBookTickerClients(TradingMode apiType);
        IBookTickerSocketClient? BookTickerClient(TradingMode api, string exchange);

        IEnumerable<IKlineSocketClient> GetKlineClients();
        IEnumerable<IKlineSocketClient> GetKlineClients(TradingMode apiType);
        IKlineSocketClient? KlineClient(TradingMode api, string exchange);

        IEnumerable<IOrderBookSocketClient> GetOrderBookClients();
        IEnumerable<IOrderBookSocketClient> GetOrderBookClients(TradingMode apiType);
        IOrderBookSocketClient? OrderBookClient(TradingMode api, string exchange);

        IEnumerable<IBalanceSocketClient> GetBalanceClients();
        IEnumerable<IBalanceSocketClient> GetBalanceClients(TradingMode apiType);
        IBalanceSocketClient? BalanceClient(TradingMode api, string exchange);

        IEnumerable<ISpotOrderSocketClient> GetSpotOrderClients();
        ISpotOrderSocketClient? SpotOrderClient(string exchange);

        IEnumerable<IFuturesOrderSocketClient> GetFuturesOrderClients();
        IEnumerable<IFuturesOrderSocketClient> GetFuturesOrderClients(TradingMode apiType);
        IFuturesOrderSocketClient? FuturesOrderClient(TradingMode apiType, string exchange);

        IEnumerable<IUserTradeSocketClient> GetUserTradeClients();
        IEnumerable<IUserTradeSocketClient> GetUserTradeClients(TradingMode apiType);
        IUserTradeSocketClient? UserTradeClient(TradingMode apiType, string exchange);

        IEnumerable<IPositionSocketClient> GetPositionClients();
        IEnumerable<IPositionSocketClient> GetPositionClients(TradingMode apiType);
        IPositionSocketClient? PositionClient(TradingMode apiType, string exchange);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToAllTickerUpdatesAsync(SubscribeAllTickersRequest request, Action<ExchangeEvent<IEnumerable<SharedSpotTicker>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToAllTickerUpdatesAsyncEnumerable(SubscribeAllTickersRequest request, Action<ExchangeEvent<IEnumerable<SharedSpotTicker>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToTickerUpdatesAsyncEnumerable(SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTradeUpdatesAsync(SubscribeTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToTradeUpdatesAsyncEnumerable(SubscribeTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsyncEnumerable(SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToKlineUpdatesAsync(SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToKlineUpdatesAsyncEnumerable(SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToOrderBookUpdatesAsync(SubscribeOrderBookRequest request, Action<ExchangeEvent<SharedOrderBook>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsyncEnumerable(SubscribeOrderBookRequest request, Action<ExchangeEvent<SharedOrderBook>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBalanceUpdatesAsync(SubscribeBalancesRequest request, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsyncEnumerable(SubscribeBalancesRequest request, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToSpotOrderUpdatesAsync(SubscribeSpotOrderRequest request, Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToSpotOrderUpdatesAsyncEnumerable(SubscribeSpotOrderRequest request, Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToFuturesOrderUpdatesAsync(SubscribeFuturesOrderRequest request, Action<ExchangeEvent<IEnumerable<SharedFuturesOrder>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToFuturesOrderUpdatesAsyncEnumerable(SubscribeFuturesOrderRequest request, Action<ExchangeEvent<IEnumerable<SharedFuturesOrder>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToUserTradeUpdatesAsync(SubscribeUserTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsyncEnumerable(SubscribeUserTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Unsubscribe and close every connection
        /// </summary>
        /// <returns></returns>
        Task UnsubscribeAllAsync();
    }
}
