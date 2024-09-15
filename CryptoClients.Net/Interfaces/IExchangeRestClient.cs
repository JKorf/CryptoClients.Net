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
using CryptoExchange.Net.SharedApis.Interfaces.Rest.Futures;
using CryptoExchange.Net.SharedApis.Interfaces.Rest.Spot;
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
        IAssetsRestClient? AssetClient(string exchange);

        IEnumerable<IBalanceRestClient> GetBalanceClients();
        IEnumerable<IBalanceRestClient> GetBalanceClients(ApiType api);
        IBalanceRestClient? BalanceClient(ApiType api, string exchange);

        IEnumerable<IDepositRestClient> GetDepositClients();
        IDepositRestClient? DepositClient(string exchange);

        IEnumerable<IKlineRestClient> GetKlineClients();
        IEnumerable<IKlineRestClient> GetKlineClients(ApiType api);
        IKlineRestClient? KlineClient(ApiType api, string exchange);

        IEnumerable<IOrderBookRestClient> GetOrderBookClients();
        IEnumerable<IOrderBookRestClient> GetOrderBookClients(ApiType api);
        IOrderBookRestClient? OrderBookClient(ApiType api, string exchange);

        IEnumerable<IRecentTradeRestClient> GetRecentTradesClients();
        IEnumerable<IRecentTradeRestClient> GetRecentTradesClients(ApiType api);
        IRecentTradeRestClient? RecentTradesClient(ApiType api, string exchange);

        IEnumerable<ITradeHistoryRestClient> GetTradeHistoryClients();
        IEnumerable<ITradeHistoryRestClient> GetTradeHistoryClients(ApiType api);
        ITradeHistoryRestClient? TradeHistoryClient(ApiType api, string exchange);

        IEnumerable<IWithdrawalRestClient> GetWithdrawalClients();
        IWithdrawalRestClient? WithdrawalClient(string exchange);

        IEnumerable<IWithdrawRestClient> GetWithdrawClients();
        IWithdrawRestClient? WithdrawClient(string exchange);

        IEnumerable<ISpotOrderRestClient> GetSpotOrderClients();
        ISpotOrderRestClient? SpotOrderClient(string exchange);

        IEnumerable<ISpotSymbolRestClient> GetSpotSymbolClients();
        ISpotSymbolRestClient? SpotSymbolClient(string exchange);

        IEnumerable<ISpotTickerRestClient> GetSpotTickerClients();
        ISpotTickerRestClient? SpotTickerClient(string exchange);

        IEnumerable<IFundingRateRestClient> GetFundingRateClients();
        IEnumerable<IFundingRateRestClient> GetFundingRateClients(ApiType api);
        IFundingRateRestClient? FundingRateClient(ApiType api, string exchange);

        IEnumerable<IFuturesOrderRestClient> GetFuturesOrderClients();
        IEnumerable<IFuturesOrderRestClient> GetFuturesOrderClients(ApiType api);
        IFuturesOrderRestClient? FuturesOrderClient(ApiType api, string exchange);

        IEnumerable<IFuturesSymbolRestClient> GetFuturesSymbolClients();
        IEnumerable<IFuturesSymbolRestClient> GetFuturesSymbolClients(ApiType api);
        IFuturesSymbolRestClient? FuturesSymbolClient(ApiType api, string exchange);

        IEnumerable<IFuturesTickerRestClient> GetFuturesTickerClients();
        IEnumerable<IFuturesTickerRestClient> GetFuturesTickerClients(ApiType api);
        IFuturesTickerRestClient? FuturesTickerClient(ApiType api, string exchange);

        IEnumerable<IIndexPriceKlineRestClient> GetIndexPriceKlineClients();
        IEnumerable<IIndexPriceKlineRestClient> GetIndexPriceKlineClients(ApiType api);
        IIndexPriceKlineRestClient? IndexPriceKlineClient(ApiType api, string exchange);

        IEnumerable<ILeverageRestClient> GetLeverageClients();
        IEnumerable<ILeverageRestClient> GetLeverageClients(ApiType api);
        ILeverageRestClient? LeverageClient(ApiType api, string exchange);

        IEnumerable<IMarkPriceKlineRestClient> GetMarkPriceKlineClients();
        IEnumerable<IMarkPriceKlineRestClient> GetMarkPriceKlineClients(ApiType api);
        IMarkPriceKlineRestClient? MarkPriceKlineClient(ApiType api, string exchange);

        IEnumerable<IOpenInterestRestClient> GetOpenInterestClients();
        IEnumerable<IOpenInterestRestClient> GetOpenInterestClients(ApiType api);
        IOpenInterestRestClient? OpenInterestClient(ApiType api, string exchange);

        IEnumerable<IPositionModeRestClient> GetPositionModeClients();
        IEnumerable<IPositionModeRestClient> GetPositionModeClients(ApiType api);
        IPositionModeRestClient? PositionModeClient(ApiType api, string exchange);

        IEnumerable<IPositionHistoryRestClient> GetPositionHistoryClients();
        IEnumerable<IPositionHistoryRestClient> GetPositionHistoryClients(ApiType api);
        IPositionHistoryRestClient? PositionHistoryClient(ApiType api, string exchange);


        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotTicker>>> GetSpotTickersAsyncEnumerable(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotTicker>>>> GetSpotTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<SharedSpotTicker>> GetSpotTickerAsyncEnumerable(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedSpotTicker>>> GetSpotTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesTicker>>> GetFuturesTickersAsyncEnumerable(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesTicker>>>> GetFuturesTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<SharedFuturesTicker>> GetFuturesTickerAsyncEnumerable(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedFuturesTicker>>> GetFuturesTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>> GetKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>>> GetKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedMarkKline>>> GetMarkPriceKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedMarkKline>>>> GetMarkPriceKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedMarkKline>>> GetIndexPriceKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedMarkKline>>>> GetIndexPriceKlinesAsync( GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>> GetRecentTradesAsyncEnumerable(GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetRecentTradesAsync(GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>> GetTradeHistoryAsyncEnumerable(GetTradeHistoryRequest request, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetTradeHistoryAsync(GetTradeHistoryRequest request, IEnumerable<string>? exchanges = null, IEnumerable<INextPageToken>? nextPageTokens = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<SharedOrderBook>> GetOrderBookAsyncEnumerable(GetOrderBookRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedOrderBook>>> GetOrderBookAsync(GetOrderBookRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedAsset>>> GetAssetsAsyncEnumerable(GetAssetsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedAsset>>>> GetAssetsAsync(GetAssetsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<SharedAsset>> GetAssetAsyncEnumerable(GetAssetRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedAsset>>> GetAssetAsync(GetAssetRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedBalance>>> GetBalancesAsyncEnumerable(GetBalancesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedBalance>>>> GetBalancesAsync(GetBalancesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedDeposit>>> GetDepositsAsyncEnumerable(GetDepositsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedDeposit>>>> GetDepositsAsync(GetDepositsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedWithdrawal>>> GetWithdrawalsAsyncEnumerable(GetWithdrawalsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedWithdrawal>>>> GetWithdrawalsAsync(GetWithdrawalsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>> GetSpotSymbolsAsyncEnumerable(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>>> GetSpotSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<SharedId>> PlaceSpotOrderAsyncEnumerable(PlaceSpotOrderRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedId>>> PlaceSpotOrderAsync(PlaceSpotOrderRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> GetSpotOpenOrdersAsyncEnumerable(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotOpenOrdersAsync( GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> GetSpotClosedOrdersAsyncEnumerable(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotClosedOrdersAsync(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>> GetSpotUserTradesAsyncEnumerable(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>>> GetSpotUserTradesAsync(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFundingRate>>> GetFundingRateHistoryAsyncEnumerable(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFundingRate>>>> GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<SharedOpenInterest>> GetOpenInterestAsyncEnumerable(GetOpenInterestRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedOpenInterest>>> GetOpenInterestAsync(GetOpenInterestRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesSymbol>>> GetFuturesSymbolsAsyncEnumerable(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesSymbol>>>> GetFuturesSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedPositionHistory>>> GetPositionHistoryAsyncEnumerable(GetPositionHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedPositionHistory>>>> GetPositionHistoryAsync(GetPositionHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

    }
}
