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

        IEnumerable<IFuturesSymbolClient> GetFuturesSymbolClients(ApiType api);
        IEnumerable<ISpotSymbolClient> GetSpotSymbolClients(ApiType api);
        IEnumerable<ITickerClient> GetTickerClients(ApiType api);
        IEnumerable<IKlineClient> GetKlineClients(ApiType api);
        IEnumerable<ITradeClient> GetTradeClients(ApiType api);

        IAsyncEnumerable<ExchangeResult<SharedTicker>> StreamTickersAsync(ApiType api, TickerRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeResult<SharedTicker>>> GetTickersAsync(ApiType api, TickerRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeResult<IEnumerable<SharedKline>>> StreamKlinesAsync(ApiType api, KlineRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeResult<IEnumerable<SharedKline>>>> GetKlinesAsync(ApiType api, KlineRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

        IAsyncEnumerable<ExchangeResult<IEnumerable<SharedTrade>>> StreamTradesAsync(ApiType api, TradeRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);
        Task<IEnumerable<ExchangeResult<IEnumerable<SharedTrade>>>> GetTradesAsync(ApiType api, TradeRequest request, IEnumerable<Exchange>? exchanges = null, CancellationToken ct = default);

    }
}
