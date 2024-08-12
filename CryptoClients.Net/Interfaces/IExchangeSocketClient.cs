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

        IEnumerable<ITickerSocketClient> GetTickerClients(ApiType apiType);
        ITickerSocketClient TickerClient(ApiType api, Exchange exchange);

        IEnumerable<ITickersSocketClient> GetTickersClients(ApiType apiType);
        ITickersSocketClient TickersClient(ApiType api, Exchange exchange);

        IEnumerable<ITradeSocketClient> GetTradeClients(ApiType apiType);
        ITradeSocketClient TradeClient(ApiType api, Exchange exchange);

        IEnumerable<IBookTickerSocketClient> GetBookTickerClients(ApiType apiType);
        IBookTickerSocketClient BookTickerClient(ApiType api, Exchange exchange);

        IEnumerable<IBalanceSocketClient> GetBalanceClients(ApiType apiType);
        IBalanceSocketClient BalanceClient(ApiType api, Exchange exchange);

        IEnumerable<ISpotOrderSocketClient> GetSpotOrderClients();
        ISpotOrderSocketClient SpotOrderClient(Exchange exchange);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToAllTickerUpdatesAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedTicker>>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToAllTickerUpdatesEnumerateAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedTicker>>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTickerUpdatesAsync(ApiType apiType, TickerSubscribeRequest request, Action<ExchangeEvent<SharedTicker>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToTickerUpdatesEnumerateAsync(ApiType apiType, TickerSubscribeRequest request, Action<ExchangeEvent<SharedTicker>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToTradeUpdatesAsync(ApiType apiType, TradeSubscribeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToTradeUpdatesEnumerateAsync(ApiType apiType, TradeSubscribeRequest request, Action<ExchangeEvent<IEnumerable<SharedTrade>>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBookTickerUpdatesAsync(ApiType apiType, BookTickerSubscribeRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToBookTickerUpdatesEnumerateAsync(ApiType apiType, BookTickerSubscribeRequest request, Action<ExchangeEvent<SharedBookTicker>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToBalanceUpdatesAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToBalanceUpdatesEnumerateAsync(ApiType apiType, Action<ExchangeEvent<IEnumerable<SharedBalance>>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

        Task<IEnumerable<ExchangeResult<UpdateSubscription>>> SubscribeToSpotOrderUpdatesAsync(Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        IAsyncEnumerable<ExchangeResult<UpdateSubscription>> SubscribeToSpotOrderUpdatesEnumerateAsync(Action<ExchangeEvent<IEnumerable<SharedSpotOrder>>> handler, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Unsubscribe and close every connection
        /// </summary>
        /// <returns></returns>
        Task UnsubscribeAllAsync();
    }
}
