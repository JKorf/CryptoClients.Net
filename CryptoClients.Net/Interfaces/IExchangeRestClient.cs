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
        ISpotClient GetUnifiedSpotClient(Exchange exchange);

        /// <summary>
        /// Get all ISpotClient interfaces
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISpotClient> GetUnifiedSpotClients();

        IEnumerable<IAssetRestClient> GetAssetClients();
        IAssetRestClient AssetClient(Exchange exchange);

        IEnumerable<IBalanceRestClient> GetBalanceClients();
        IBalanceRestClient BalanceClient(Exchange exchange);

        IEnumerable<IDepositRestClient> GetDepositClients();
        IDepositRestClient DepositClient(Exchange exchange);

        IEnumerable<IFuturesOrderRestClient> GetFuturesOrderClients(ApiType api);
        IFuturesOrderRestClient FuturesOrderClient(ApiType api, Exchange exchange);

        IEnumerable<IFuturesSymbolRestClient> GetFuturesSymbolClients(ApiType api);
        IFuturesSymbolRestClient FuturesSymbolClient(ApiType api, Exchange exchange);

        IEnumerable<IKlineRestClient> GetKlineClients(ApiType api);
        IKlineRestClient KlineClient(ApiType api, Exchange exchange);

        IEnumerable<IOrderBookRestClient> GetOrderBookClients(ApiType api);
        IOrderBookRestClient OrderBookClient(ApiType api, Exchange exchange);

        IEnumerable<ISpotOrderRestClient> GetSpotOrderClients();
        ISpotOrderRestClient SpotOrderClient(Exchange exchange);

        IEnumerable<ISpotSymbolRestClient> GetSpotSymbolClients();
        ISpotSymbolRestClient SpotSymbolClient(Exchange exchange);

        IEnumerable<ITickerRestClient> GetTickerClients(ApiType api);
        ITickerRestClient TickerClient(ApiType api, Exchange exchange);

        IEnumerable<ITradeRestClient> GetTradeClients(ApiType api);
        ITradeRestClient TradeClient(ApiType api, Exchange exchange);

        IEnumerable<IWithdrawalRestClient> GetWithdrawalClients(ApiType api);
        IWithdrawalRestClient WithdrawalClient(ApiType api, Exchange exchange);

        IAsyncEnumerable<ExchangeWebResult<SharedTicker>> StreamTickersAsync(ApiType api, GetTickerRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<SharedTicker>>> GetTickersAsync(ApiType api, GetTickerRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>> StreamKlinesAsync(ApiType api, GetKlinesRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>>> GetKlinesAsync(ApiType api, GetKlinesRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>> StreamTradesAsync(ApiType api, GetTradesRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetTradesAsync(ApiType api, GetTradesRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

    }
}
