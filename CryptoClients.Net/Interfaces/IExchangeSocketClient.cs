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
using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.Socket;
using CryptoExchange.Net.SharedApis.RequestModels;
using CryptoExchange.Net.SharedApis.ResponseModels;
using CryptoExchange.Net.SharedApis.SubscribeModels;
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

        IEnumerable<ITickerSocketClient> GetTickerClients();
        IEnumerable<ITickerSocketClient> GetTickerClients(ApiType apiType);
        ITickerSocketClient TickerClient(ApiType api, string exchange);

        IEnumerable<ITickersSocketClient> GetTickersClients();
        IEnumerable<ITickersSocketClient> GetTickersClients(ApiType apiType);
        ITickersSocketClient TickersClient(ApiType api, string exchange);

        IEnumerable<ITradeSocketClient> GetTradeClients();
        IEnumerable<ITradeSocketClient> GetTradeClients(ApiType apiType);
        ITradeSocketClient TradeClient(ApiType api, string exchange);

        IEnumerable<IBookTickerSocketClient> GetBookTickerClients();
        IEnumerable<IBookTickerSocketClient> GetBookTickerClients(ApiType apiType);
        IBookTickerSocketClient BookTickerClient(ApiType api, string exchange);

        IEnumerable<IKlineSocketClient> GetKlineClients();
        IEnumerable<IKlineSocketClient> GetKlineClients(ApiType apiType);
        IKlineSocketClient KlineClient(ApiType api, string exchange);

        IEnumerable<IOrderBookSocketClient> GetOrderBookClients();
        IEnumerable<IOrderBookSocketClient> GetOrderBookClients(ApiType apiType);
        IOrderBookSocketClient OrderBookClient(ApiType api, string exchange);

        IEnumerable<IBalanceSocketClient> GetBalanceClients();
        IEnumerable<IBalanceSocketClient> GetBalanceClients(ApiType apiType);
        IBalanceSocketClient BalanceClient(ApiType api, string exchange);

        IEnumerable<ISpotOrderSocketClient> GetSpotOrderClients();
        ISpotOrderSocketClient SpotOrderClient(string exchange);

        IEnumerable<IFuturesOrderSocketClient> GetFuturesOrderClients();
        IEnumerable<IFuturesOrderSocketClient> GetFuturesOrderClients(ApiType apiType);
        IFuturesOrderSocketClient FuturesOrderClient(ApiType apiType, string exchange);

        IEnumerable<IUserTradeSocketClient> GetUserTradeClients();
        IEnumerable<IUserTradeSocketClient> GetUserTradeClients(ApiType apiType);
        IUserTradeSocketClient UserTradeClient(ApiType apiType, string exchange);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToAllTickerUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedSpotTicker>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToAllTickerUpdatesAsyncEnumerable(Action<ExchangeEvent<IEnumerable<SharedSpotTicker>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToTickerUpdatesAsyncEnumerable(SubscribeTickerRequest request, Action<ExchangeEvent<SharedSpotTicker>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTradeUpdatesAsync(SubscribeTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToTradeUpdatesAsyncEnumerable(SubscribeTradeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsyncEnumerable(SubscribeBookTickerRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToKlineUpdatesAsync(SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToKlineUpdatesAsyncEnumerable(SubscribeKlineRequest request, Action<ExchangeEvent<SharedKline>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToOrderBookUpdatesAsync(SubscribeOrderBookRequest request, Action<ExchangeEvent<SharedOrderBook>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsyncEnumerable(SubscribeOrderBookRequest request, Action<ExchangeEvent<SharedOrderBook>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBalanceUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsyncEnumerable(Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToSpotOrderUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToSpotOrderUpdatesAsyncEnumerable(Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToFuturesOrderUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedFuturesOrder>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToFuturesOrderUpdatesAsyncEnumerable(Action<ExchangeEvent<IEnumerable<SharedFuturesOrder>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToUserTradeUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsyncEnumerable(Action<ExchangeEvent<IEnumerable<SharedUserTrade>>> handler, ApiType? apiType, ExchangeParameters? exchangeParameters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Unsubscribe and close every connection
        /// </summary>
        /// <returns></returns>
        Task UnsubscribeAllAsync();
    }
}
