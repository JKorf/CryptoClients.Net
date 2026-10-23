using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClients.Net.Interfaces
{
    /// <summary>
    /// Client for accessing the exchange Websocket API's.
    /// </summary>
    public interface IExchangeSocketClient : IExchangeSharedSocketClient
    {
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
        /// Get the <see cref="ISpotOrderManagementSocketClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<ISpotOrderManagementSocketClient> GetSpotOrderManagementClients();
        /// <summary>
        /// Get the <see cref="ISpotOrderManagementSocketClient"/> client for a specific exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        ISpotOrderManagementSocketClient? GetSpotOrderManagementClient(string exchange);

        /// <summary>
        /// Get the <see cref="IFuturesOrderManagementSocketClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IFuturesOrderManagementSocketClient> GetFuturesOrderManagementClients();
        /// <summary>
        /// Get the <see cref="IFuturesOrderManagementSocketClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IFuturesOrderManagementSocketClient? GetFuturesOrderManagementClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Subscribe to ticker updates for all symbols on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToAllTickerUpdatesAsync(string exchange, SubscribeAllTickersRequest request, Action<DataEvent<SharedSpotTicker[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates for all symbols on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>[]> SubscribeToAllTickerUpdatesAsync(SubscribeAllTickersRequest request, Action<DataEvent<SharedSpotTicker[]>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates for a specific symbol on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string exchange, SubscribeTickerRequest request, Action<DataEvent<SharedSpotTicker>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates for a specific symbol on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>[]> SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<DataEvent<SharedSpotTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates for a symbol on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string exchange, SubscribeTradeRequest request, Action<DataEvent<SharedTrade[]>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates for a symbol on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>[]> SubscribeToTradeUpdatesAsync(SubscribeTradeRequest request, Action<DataEvent<SharedTrade[]>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to book ticker (best ask/bid price) updates for a symbol on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(string exchange, SubscribeBookTickerRequest request, Action<DataEvent<SharedBookTicker>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to book ticker (best ask/bid price) updates for a symbol on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>[]> SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<DataEvent<SharedBookTicker>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline/candlestick updates for a symbol on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string exchange, SubscribeKlineRequest request, Action<DataEvent<SharedKline>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline/candlestick updates for a symbol on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>[]> SubscribeToKlineUpdatesAsync(SubscribeKlineRequest request, Action<DataEvent<SharedKline>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book snapshot updates for a symbol on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string exchange, SubscribeOrderBookRequest request, Action<DataEvent<SharedOrderBook>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book snapshot updates for a symbol on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>[]> SubscribeToOrderBookUpdatesAsync(SubscribeOrderBookRequest request, Action<DataEvent<SharedOrderBook>> handler, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user balance updates on on exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe on</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(
            string exchange,
            SubscribeBalancesRequest request,
            Action<DataEvent<SharedBalance[]>> handler,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user balance updates on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>[]> SubscribeToBalanceUpdatesAsync(
            SubscribeBalancesRequest request,
            Action<DataEvent<SharedBalance[]>> handler,
            IEnumerable<string>? exchanges = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user spot orders updates on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToSpotOrderUpdatesAsync(
            string exchange,
            SubscribeSpotOrderRequest request,
            Action<DataEvent<SharedSpotOrder[]>> handler,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user spot orders updates on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>[]> SubscribeToSpotOrderUpdatesAsync(
            SubscribeSpotOrderRequest request,
            Action<DataEvent<SharedSpotOrder[]>> handler,
            IEnumerable<string>? exchanges = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user futures orders updates on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToFuturesOrderUpdatesAsync(
            string exchange,
            SubscribeFuturesOrderRequest request,
            Action<DataEvent<SharedFuturesOrder[]>> handler,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user futures orders updates on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>[]> SubscribeToFuturesOrderUpdatesAsync(
            SubscribeFuturesOrderRequest request,
            Action<DataEvent<SharedFuturesOrder[]>> handler,
            IEnumerable<string>? exchanges = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade execution updates on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(
            string exchange,
            SubscribeUserTradeRequest request,
            Action<DataEvent<SharedUserTrade[]>> handler,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade execution updates on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>[]> SubscribeToUserTradeUpdatesAsync(
            SubscribeUserTradeRequest request,
            Action<DataEvent<SharedUserTrade[]>> handler,
            IEnumerable<string>? exchanges = null,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user position updates on an exchange
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchange">Exchange to subscribe</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(
            string exchange,
            SubscribePositionRequest request,
            Action<DataEvent<SharedPosition[]>> handler,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user position updates on all exchanges that support this subscription
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="handler">The data handler callback</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancellation token, can be used to stop the updates</param>
        Task<WebSocketResult<UpdateSubscription>[]> SubscribeToPositionUpdatesAsync(
            SubscribePositionRequest request,
            Action<DataEvent<SharedPosition[]>> handler,
            IEnumerable<string>? exchanges = null,
            CancellationToken ct = default);

        /// <summary>
        /// Place a new spot order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<QueryResult<SharedId>> PlaceSpotOrderAsync(string exchange, PlaceSpotOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Cancel an open spot order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<QueryResult<SharedId>> CancelSpotOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Place a new futures order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<QueryResult<SharedId>> PlaceFuturesOrderAsync(string exchange, PlaceFuturesOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Cancel an open futures order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<QueryResult<SharedId>> CancelFuturesOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default);

    }
}
