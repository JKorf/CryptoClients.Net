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

        IEnumerable<IAssetsRestClient> GetAssetClients();
        IAssetsRestClient AssetClient(string exchange);

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

        IEnumerable<IRecentTradeRestClient> GetRecentTradesClients(ApiType api);
        IRecentTradeRestClient RecentTradesClient(ApiType api, string exchange);

        IEnumerable<IWithdrawalRestClient> GetWithdrawalClients(ApiType api);
        IWithdrawalRestClient WithdrawalClient(ApiType api, string exchange);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedTicker>>> GetTickersAsyncEnumerable(ApiType api, GetTickerRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedTicker>>>> GetTickersAsync(ApiType api, GetTickerRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<SharedTicker>> GetTickerAsyncEnumerable(ApiType api, GetTickerRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedTicker>>> GetTickerAsync(ApiType api, GetTickerRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>> GetKlinesAsyncEnumerable(ApiType api, GetKlinesRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>>> GetKlinesAsync(ApiType api, GetKlinesRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>> GetRecentTradesAsyncEnumerable(ApiType api, GetRecentTradesRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetRecentTradesAsync(ApiType api, GetRecentTradesRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>> GetTradeHistoryAsyncEnumerable(ApiType api, GetTradeHistoryRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetTradeHistoryAsync(ApiType api, GetTradeHistoryRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<SharedOrderBook>> GetOrderBookAsyncEnumerable(ApiType api, GetOrderBookRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedOrderBook>>> GetOrderBookAsync(ApiType api, GetOrderBookRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedAsset>>> GetAssetsAsyncEnumerable(ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedAsset>>>> GetAssetsAsync(ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedBalance>>> GetBalancesAsyncEnumerable(ApiType api, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedBalance>>>> GetBalancesAsync(ApiType api, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedDeposit>>> GetDepositsAsyncEnumerable(GetDepositsRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedDeposit>>>> GetDepositsAsync(GetDepositsRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>> GetSpotSymbolsAsyncEnumerable(ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>>> GetSpotSymbolsAsync(ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<SharedId>> PlaceSpotOrderAsyncEnumerable(PlaceSpotOrderRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedId>>> PlaceSpotOrderAsync(PlaceSpotOrderRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> GetSpotOpenOrdersAsyncEnumerable(GetOpenOrdersRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotOpenOrdersAsync( GetOpenOrdersRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> GetSpotClosedOrdersAsyncEnumerable(GetClosedOrdersRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotClosedOrdersAsync(GetClosedOrdersRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>> GetUserTradesAsyncEnumerable(ApiType api, GetUserTradesRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>>> GetUserTradesAsync(ApiType api, GetUserTradesRequest request, ExchangeParameters? exchangeParamters = null, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

    }
}
