using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients;
using BitMart.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients;
using CoinEx.Net.Interfaces.Clients;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Models;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis.Interfaces;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.Rest;
using CryptoExchange.Net.SharedApis.RequestModels;
using CryptoExchange.Net.SharedApis.ResponseModels;
using GateIo.Net.Interfaces.Clients;
using HTX.Net.Interfaces.Clients;
using Kraken.Net.Interfaces.Clients;
using Kucoin.Net.Interfaces.Clients;
using Mexc.Net.Interfaces.Clients;
using OKX.Net.Interfaces.Clients;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClients.Net.Interfaces
{
    /// <summary>
    /// Client for accessing the exchange REST API's.
    /// </summary>
    public interface IExchangeRestClient
    {
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
        /// BitMart REST API
        /// </summary>
        IBitMartRestClient BitMart { get; }
        /// <summary>
        /// Bybit REST API
        /// </summary>
        IBybitRestClient Bybit { get; }
        /// <summary>
        /// CoinEx REST API
        /// </summary>
        ICoinExRestClient CoinEx { get; }
        /// <summary>
        /// Gate.io REST API
        /// </summary>
        IGateIoRestClient GateIo { get; }
        /// <summary>
        /// HTX REST API
        /// </summary>
        IHTXRestClient HTX { get; }
        /// <summary>
        /// Kraken REST API
        /// </summary>
        IKrakenRestClient Kraken { get; }
        /// <summary>
        /// Kucoin REST API
        /// </summary>
        IKucoinRestClient Kucoin { get; }
        /// <summary>
        /// Mexc REST API
        /// </summary>
        IMexcRestClient Mexc { get; }
        /// <summary>
        /// OKX REST API
        /// </summary>
        IOKXRestClient OKX { get; }

        /// <summary>
        /// Get an ISpotClient for the specific exchange. 
        /// </summary>
        /// <param name="exchange">Exchange</param>
        /// <returns></returns>
        ISpotClient GetUnifiedSpotClient(string exchange);

        /// <summary>
        /// Get all ISpotClient interfaces
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISpotClient> GetUnifiedSpotClients();

        IEnumerable<IAssetRestClient> GetAssetClients();
        IAssetRestClient AssetClient(string exchange);

        IEnumerable<IBalanceRestClient> GetBalanceClients(ApiType api);
        IBalanceRestClient BalanceClient(ApiType api, string exchange);

        IEnumerable<IDepositRestClient> GetDepositClients();
        IDepositRestClient DepositClient(string exchange);

        IEnumerable<IFuturesOrderRestClient> GetFuturesOrderClients(ApiType api);
        IFuturesOrderRestClient FuturesOrderClient(ApiType api, string exchange);

        IEnumerable<IFuturesSymbolRestClient> GetFuturesSymbolClients(ApiType api);
        IFuturesSymbolRestClient FuturesSymbolClient(ApiType api, string exchange);

        IEnumerable<IKlineRestClient> GetKlineClients(ApiType api);
        IKlineRestClient KlineClient(ApiType api, string exchange);

        IEnumerable<IOrderBookRestClient> GetOrderBookClients(ApiType api);
        IOrderBookRestClient OrderBookClient(ApiType api, string exchange);

        IEnumerable<ISpotOrderRestClient> GetSpotOrderClients();
        ISpotOrderRestClient SpotOrderClient(string exchange);

        IEnumerable<ISpotSymbolRestClient> GetSpotSymbolClients();
        ISpotSymbolRestClient SpotSymbolClient(string exchange);

        IEnumerable<ITickerRestClient> GetTickerClients(ApiType api);
        ITickerRestClient TickerClient(ApiType api, string exchange);

        IEnumerable<IRecentTradeRestClient> GetTradeClients(ApiType api);
        IRecentTradeRestClient TradeClient(ApiType api, string exchange);

        IEnumerable<IWithdrawalRestClient> GetWithdrawalClients(ApiType api);
        IWithdrawalRestClient WithdrawalClient(ApiType api, string exchange);

        IAsyncEnumerable<ExchangeWebResult<SharedTicker>> GetTickersStreamAsync(ApiType api, GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedTicker>>> GetTickersWaitAsync(ApiType api, GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>> GetKlinesStreamAsync(ApiType api, GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>>> GetKlinesWaitAsync(ApiType api, GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>> GetRecentTradesStreamAsync(ApiType api, GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetRecentTradesWaitAsync(ApiType api, GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedBalance>>> GetBalancesStreamAsync(ApiType api, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedBalance>>>> GetBalancesWaitAsync(ApiType api, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<SharedOrderId>> PlaceSpotOrderStreamAsync(PlaceSpotOrderRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedOrderId>>> PlaceSpotOrderWaitAsync(PlaceSpotOrderRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> GetSpotOpenOrdersStreamAsync(GetSpotOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotOpenOrdersWaitAsync( GetSpotOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> GetSpotClosedOrdersStreamAsync(GetSpotClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotClosedOrdersWaitAsync(GetSpotClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>> GetUserTradesStreamAsync(ApiType api, GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>>> GetUserTradesWaitAsync(ApiType api, GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

    }
}
