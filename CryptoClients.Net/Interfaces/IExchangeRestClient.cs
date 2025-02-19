using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients;
using BitMart.Net.Interfaces.Clients;
using BitMEX.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients;
using Coinbase.Net.Interfaces.Clients;
using CoinEx.Net.Interfaces.Clients;
using CryptoCom.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.SharedApis;
using GateIo.Net.Interfaces.Clients;
using HTX.Net.Interfaces.Clients;
using HyperLiquid.Net.Interfaces.Clients;
using Kraken.Net.Interfaces.Clients;
using Kucoin.Net.Interfaces.Clients;
using Mexc.Net.Interfaces.Clients;
using OKX.Net.Interfaces.Clients;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhiteBit.Net.Interfaces.Clients;
using XT.Net.Interfaces.Clients;

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
        /// BitMEX REST API
        /// </summary>
        IBitMEXRestClient BitMEX { get; }
        /// <summary>
        /// Bybit REST API
        /// </summary>
        IBybitRestClient Bybit { get; }
        /// <summary>
        /// Coinbase REST API
        /// </summary>
        ICoinbaseRestClient Coinbase { get; }
        /// <summary>
        /// CoinEx REST API
        /// </summary>
        ICoinExRestClient CoinEx { get; }
        /// <summary>
        /// Crypto.com REST API
        /// </summary>
        ICryptoComRestClient CryptoCom { get; }
        /// <summary>
        /// Gate.io REST API
        /// </summary>
        IGateIoRestClient GateIo { get; }
        /// <summary>
        /// HTX REST API
        /// </summary>
        IHTXRestClient HTX { get; }
        /// <summary>
        /// HyperLiquid REST API
        /// </summary>
        IHyperLiquidRestClient HyperLiquid { get; }
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
        /// WhiteBit REST API
        /// </summary>
        IWhiteBitRestClient WhiteBit { get; }
        /// <summary>
        /// XT REST API
        /// </summary>
        IXTRestClient XT { get; }

        /// <summary>
        /// DEPRECATED; use <see cref="ISharedClient" /> instead for common/shared functionality. See <see href="https://jkorf.github.io/CryptoExchange.Net/docs/index.html#shared" /> for more info.
        /// </summary>
        ISpotClient GetUnifiedSpotClient(string exchange);

        /// <summary>
        /// DEPRECATED; use <see cref="ISharedClient" /> instead for common/shared functionality. See <see href="https://jkorf.github.io/CryptoExchange.Net/docs/index.html#shared" /> for more info.
        /// </summary>
        IEnumerable<ISpotClient> GetUnifiedSpotClients();

        /// <summary>
        /// Get all ISharedClient REST Api interfaces supported for the specified exchange
        /// </summary>
        /// <param name="exchange">The exchange name</param>
        /// <param name="tradingMode">Filter clients by trading mode</param>
        IEnumerable<ISharedClient> GetExchangeSharedClients(string exchange, TradingMode? tradingMode = null);

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
        /// Get the <see cref="IAssetsRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IAssetsRestClient> GetAssetsClients();
        /// <summary>
        /// Get the <see cref="IAssetsRestClient"/> client for a specific exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        IAssetsRestClient? GetAssetClient(string exchange);

        /// <summary>
        /// Get the <see cref="IBalanceRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IBalanceRestClient> GetBalancesClients();
        /// <summary>
        /// Get all <see cref="IBalanceRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IBalanceRestClient> GetBalancesClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IAssetsRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IBalanceRestClient? GetBalancesClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IDepositRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IDepositRestClient> GetDepositsClients();
        /// <summary>
        /// Get the <see cref="IDepositRestClient"/> client for a specific exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        IDepositRestClient? GetDepositsClient(string exchange);

        /// <summary>
        /// Get the <see cref="IKlineRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IKlineRestClient> GetKlineClients();
        /// <summary>
        /// Get all <see cref="IKlineRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IKlineRestClient> GetKlineClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IKlineRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IKlineRestClient? GetKlineClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IOrderBookRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IOrderBookRestClient> GetOrderBookClients();
        /// <summary>
        /// Get all <see cref="IOrderBookRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IOrderBookRestClient> GetOrderBookClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IOrderBookRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IOrderBookRestClient? GetOrderBookClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IRecentTradeRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IRecentTradeRestClient> GetRecentTradesClients();
        /// <summary>
        /// Get all <see cref="IRecentTradeRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IRecentTradeRestClient> GetRecentTradesClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IRecentTradeRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IRecentTradeRestClient? GetRecentTradesClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="ITradeHistoryRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<ITradeHistoryRestClient> GetTradeHistoryClients();
        /// <summary>
        /// Get all <see cref="ITradeHistoryRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<ITradeHistoryRestClient> GetTradeHistoryClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="ITradeHistoryRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        ITradeHistoryRestClient? GetTradeHistoryClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IWithdrawalRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IWithdrawalRestClient> GetWithdrawalsClients();
        /// <summary>
        /// Get the <see cref="IWithdrawalRestClient"/> client for a specific exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        IWithdrawalRestClient? GetWithdrawalsClient(string exchange);

        /// <summary>
        /// Get the <see cref="IWithdrawRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IWithdrawRestClient> GetWithdrawClients();
        /// <summary>
        /// Get the <see cref="IWithdrawRestClient"/> client for a specific exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        IWithdrawRestClient? GetWithdrawClient(string exchange);

        /// <summary>
        /// Get the <see cref="ISpotOrderRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<ISpotOrderRestClient> GetSpotOrderClients();
        /// <summary>
        /// Get the <see cref="ISpotOrderRestClient"/> client for a specific exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        ISpotOrderRestClient? GetSpotOrderClient(string exchange);

        /// <summary>
        /// Get the <see cref="ISpotSymbolRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<ISpotSymbolRestClient> GetSpotSymbolClients();
        /// <summary>
        /// Get the <see cref="ISpotSymbolRestClient"/> client for a specific exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        ISpotSymbolRestClient? GetSpotSymbolClient(string exchange);

        /// <summary>
        /// Get the <see cref="ISpotTickerRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<ISpotTickerRestClient> GetSpotTickerClients();
        /// <summary>
        /// Get the <see cref="ISpotTickerRestClient"/> client for a specific exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        ISpotTickerRestClient? GetSpotTickerClient(string exchange);

        /// <summary>
        /// Get the <see cref="IFundingRateRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IFundingRateRestClient> GetFundingRateClients();
        /// <summary>
        /// Get all <see cref="IFundingRateRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IFundingRateRestClient> GetFundingRateClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IFundingRateRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IFundingRateRestClient? GetFundingRateClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IFundingRateRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IFuturesOrderRestClient> GetFuturesOrderClients();
        /// <summary>
        /// Get all <see cref="IFuturesOrderRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IFuturesOrderRestClient> GetFuturesOrderClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IFuturesOrderRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IFuturesOrderRestClient? GetFuturesOrderClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IFuturesSymbolRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IFuturesSymbolRestClient> GetFuturesSymbolClients();
        /// <summary>
        /// Get all <see cref="IFuturesSymbolRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IFuturesSymbolRestClient> GetFuturesSymbolClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IFuturesSymbolRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IFuturesSymbolRestClient? GetFuturesSymbolClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IFuturesTickerRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IFuturesTickerRestClient> GetFuturesTickerClients();
        /// <summary>
        /// Get all <see cref="IFuturesTickerRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IFuturesTickerRestClient> GetFuturesTickerClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IFuturesTickerRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IFuturesTickerRestClient? GetFuturesTickerClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IIndexPriceKlineRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IIndexPriceKlineRestClient> GetIndexPriceKlineClients();
        /// <summary>
        /// Get all <see cref="IIndexPriceKlineRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IIndexPriceKlineRestClient> GetIndexPriceKlineClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IIndexPriceKlineRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IIndexPriceKlineRestClient? GetIndexPriceKlineClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="ILeverageRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<ILeverageRestClient> GetLeverageClients();
        /// <summary>
        /// Get all <see cref="ILeverageRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<ILeverageRestClient> GetLeverageClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="ILeverageRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        ILeverageRestClient? GetLeverageClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IMarkPriceKlineRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IMarkPriceKlineRestClient> GetMarkPriceKlineClients();
        /// <summary>
        /// Get all <see cref="IMarkPriceKlineRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IMarkPriceKlineRestClient> GetMarkPriceKlineClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IMarkPriceKlineRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IMarkPriceKlineRestClient? GetMarkPriceKlineClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IOpenInterestRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IOpenInterestRestClient> GetOpenInterestClients();
        /// <summary>
        /// Get all <see cref="IOpenInterestRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IOpenInterestRestClient> GetOpenInterestClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IOpenInterestRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IOpenInterestRestClient? GetOpenInterestClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IPositionModeRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IPositionModeRestClient> GetPositionModeClients();
        /// <summary>
        /// Get all <see cref="IPositionModeRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IPositionModeRestClient> GetPositionModeClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IPositionModeRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IPositionModeRestClient? GetPositionModeClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IPositionHistoryRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IPositionHistoryRestClient> GetPositionHistoryClients();
        /// <summary>
        /// Get all <see cref="IPositionHistoryRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IPositionHistoryRestClient> GetPositionHistoryClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IPositionHistoryRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IPositionHistoryRestClient? GetPositionHistoryClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IListenKeyRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IListenKeyRestClient> GetListenKeyClients();
        /// <summary>
        /// Get all <see cref="IListenKeyRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IListenKeyRestClient> GetListenKeyClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IListenKeyRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IListenKeyRestClient? GetListenKeyClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IFeeRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IFeeRestClient> GetFeeClients();
        /// <summary>
        /// Get all <see cref="IFeeRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IFeeRestClient> GetFeeClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IFeeRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IFeeRestClient? GetFeeClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get spot ticker information for all symbols on all exchanges, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotTicker>>> GetSpotTickersAsyncEnumerable(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get spot ticker information for all symbols on all exchanges, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotTicker>>>> GetSpotTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get spot ticker information for a specific symbol from all exchanges, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedSpotTicker>> GetSpotTickerAsyncEnumerable(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get spot ticker information for a specific symbol from all exchanges, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<SharedSpotTicker>>> GetSpotTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get futures ticker information for all symbols on all exchanges, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesTicker>>> GetFuturesTickersAsyncEnumerable(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get futures ticker information for all symbols on all exchanges, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesTicker>>>> GetFuturesTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        
        /// <summary>
        /// Get futures ticker information for a specific symbol from all exchanges, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedFuturesTicker>> GetFuturesTickerAsyncEnumerable(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get futures ticker information for a specific symbol from all exchanges, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<SharedFuturesTicker>>> GetFuturesTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get kline data for a specific symbol from all exchanges, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>> GetKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get kline data for a specific symbol from all exchanges, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedKline>>>> GetKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get mark price kline data for a specific symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesKline>>> GetMarkPriceKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get mark price kline data for a specific symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesKline>>>> GetMarkPriceKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get index price kline data for a specific symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesKline>>> GetIndexPriceKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get index price kline data for a specific symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesKline>>>> GetIndexPriceKlinesAsync( GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get recent trades public data for a specific symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>> GetRecentTradesAsyncEnumerable(GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get recent trades public data for a specific symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetRecentTradesAsync(GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get public trade history data for a specific symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>> GetTradeHistoryAsyncEnumerable(GetTradeHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get public trade history data for a specific symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedTrade>>>> GetTradeHistoryAsync(GetTradeHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get order book data for a specific symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedOrderBook>> GetOrderBookAsyncEnumerable(GetOrderBookRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get order book data for a specific symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<SharedOrderBook>>> GetOrderBookAsync(GetOrderBookRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        
        /// <summary>
        /// Get asset info of all assets on all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedAsset>>> GetAssetsAsyncEnumerable(GetAssetsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get asset info of all assets on all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedAsset>>>> GetAssetsAsync(GetAssetsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get asset info of a specific asset on all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedAsset>> GetAssetAsyncEnumerable(GetAssetRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get asset info of a specific asset on all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<SharedAsset>>> GetAssetAsync(GetAssetRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user balances from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedBalance>>> GetBalancesAsyncEnumerable(GetBalancesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get user balances from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedBalance>>>> GetBalancesAsync(GetBalancesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user deposit history from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedDeposit>>> GetDepositsAsyncEnumerable(GetDepositsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get user deposit history from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedDeposit>>>> GetDepositsAsync(GetDepositsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user withdrawal history from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedWithdrawal>>> GetWithdrawalsAsyncEnumerable(GetWithdrawalsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get user withdrawal history from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedWithdrawal>>>> GetWithdrawalsAsync(GetWithdrawalsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        
        /// <summary>
        /// Get spot symbol info of all symbols from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>> GetSpotSymbolsAsyncEnumerable(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get spot symbol info of all symbols from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>>> GetSpotSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        
        /// <summary>
        /// Get open spot orders for the user from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> GetSpotOpenOrdersAsyncEnumerable(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get open spot orders for the user from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotOpenOrdersAsync( GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get closed spot orders for a symbol for the user from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> GetSpotClosedOrdersAsyncEnumerable(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get closed spot orders for a symbol for the user from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedSpotOrder>>>> GetSpotClosedOrdersAsync(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user executed trades from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>> GetSpotUserTradesAsyncEnumerable(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get user executed trades from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>>> GetSpotUserTradesAsync(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get funding rate history for a symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFundingRate>>> GetFundingRateHistoryAsyncEnumerable(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get funding rate history for a symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFundingRate>>>> GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get current open interest for a symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedOpenInterest>> GetOpenInterestAsyncEnumerable(GetOpenInterestRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get current open interest for a symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<SharedOpenInterest>>> GetOpenInterestAsync(GetOpenInterestRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get futures symbol info of all symbols from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesSymbol>>> GetFuturesSymbolsAsyncEnumerable(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get futures symbol info of all symbols from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesSymbol>>>> GetFuturesSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user position history from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedPositionHistory>>> GetPositionHistoryAsyncEnumerable(GetPositionHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get user position history from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedPositionHistory>>>> GetPositionHistoryAsync(GetPositionHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get open Futures orders for the user from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesOrder>>> GetFuturesOpenOrdersAsyncEnumerable(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get open Futures orders for the user from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesOrder>>>> GetFuturesOpenOrdersAsync(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get closed Futures orders for a symbol for the user from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesOrder>>> GetFuturesClosedOrdersAsyncEnumerable(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get closed Futures orders for a symbol for the user from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedFuturesOrder>>>> GetFuturesClosedOrdersAsync(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user executed trades from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>> GetFuturesUserTradesAsyncEnumerable(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get user executed trades from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<IEnumerable<SharedUserTrade>>>> GetFuturesUserTradesAsync(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get Maker and Taker trading fees for a symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedFee>> GetFeesAsyncEnumerable(GetFeeRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get Maker and Taker trading fees for a symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<IEnumerable<ExchangeWebResult<SharedFee>>> GetFeesAsync(GetFeeRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

    }
}
