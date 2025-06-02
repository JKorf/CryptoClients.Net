using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients;
using BitMart.Net.Interfaces.Clients;
using BitMEX.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients;
using Coinbase.Net.Interfaces.Clients;
using CoinEx.Net.Interfaces.Clients;
using CryptoClients.Net.Models;
using CryptoCom.Net.Interfaces.Clients;
using CryptoExchange.Net.SharedApis;
using DeepCoin.Net.Interfaces.Clients;
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
        /// DeepCoin REST API
        /// </summary>
        IDeepCoinRestClient DeepCoin { get; }
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
        /// Get all ISharedClient REST Api interfaces supported for the specified exchange
        /// </summary>
        /// <param name="exchange">The exchange name</param>
        /// <param name="tradingMode">Filter clients by trading mode</param>
        IEnumerable<ISharedClient> GetExchangeSharedClients(string exchange, TradingMode? tradingMode = null);

        /// <summary>
        /// Set API credentials for exchanges
        /// </summary>
        /// <param name="credentials">Credential info</param>
        void SetApiCredentials(ExchangeCredentials credentials);

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
        /// Generate a new random client order id
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange</param>
        string? GenerateClientOrderId(TradingMode tradingMode, string exchange);

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
        /// Get the <see cref="ISpotOrderRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<ISpotOrderClientIdRestClient> GetSpotOrderClientIdClients();
        /// <summary>
        /// Get the <see cref="ISpotOrderRestClient"/> client for a specific exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        ISpotOrderClientIdRestClient? GetSpotOrderClientIdClient(string exchange);

        /// <summary>
        /// Get the <see cref="ISpotTriggerOrderRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<ISpotTriggerOrderRestClient> GetSpotTriggerOrderClients();
        /// <summary>
        /// Get the <see cref="ISpotTriggerOrderRestClient"/> client for a specific exchange
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        ISpotTriggerOrderRestClient? GetSpotTriggerOrderClient(string exchange);

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
        /// Get the <see cref="IFuturesOrderClientIdRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IFuturesOrderClientIdRestClient> GetFuturesOrderClientIdClients();
        /// <summary>
        /// Get all <see cref="IFuturesOrderClientIdRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IFuturesOrderClientIdRestClient> GetFuturesOrderClientIdClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IFuturesOrderClientIdRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IFuturesOrderClientIdRestClient? GetFuturesOrderClientIdClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IFuturesTriggerOrderRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IFuturesTriggerOrderRestClient> GetFuturesTriggerOrderClients();
        /// <summary>
        /// Get all <see cref="IFuturesTriggerOrderRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IFuturesTriggerOrderRestClient> GetFuturesTriggerOrderClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IFuturesTriggerOrderRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IFuturesTriggerOrderRestClient? GetFuturesTriggerOrderClient(TradingMode tradingMode, string exchange);

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
        /// Get the <see cref="IBookTickerRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IBookTickerRestClient> GetBookTickerClients();
        /// <summary>
        /// Get all <see cref="IBookTickerRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IBookTickerRestClient> GetBookTickerClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IBookTickerRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IBookTickerRestClient? GetBookTickerClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get the <see cref="IFuturesTpSlRestClient"/> clients for all exchanges
        /// </summary>
        IEnumerable<IFuturesTpSlRestClient> GetFuturesTpSlClients();
        /// <summary>
        /// Get all <see cref="IFuturesTpSlRestClient"/> clients for all exchanges which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">The trading mode the client should support</param>
        IEnumerable<IFuturesTpSlRestClient> GetFuturesTpSlClients(TradingMode tradingMode);
        /// <summary>
        /// Get the <see cref="IFuturesTpSlRestClient"/> client for a specific exchange which supports the provided trading mode
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="exchange">Exchange name</param>
        IFuturesTpSlRestClient? GetFuturesTpSlClient(TradingMode tradingMode, string exchange);

        /// <summary>
        /// Get spot ticker information for all symbols on a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedSpotTicker[]>> GetSpotTickerAsync(string exchange, GetTickersRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get spot ticker information for all symbols on all exchanges, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedSpotTicker[]>> GetSpotTickersAsyncEnumerable(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get spot ticker information for all symbols on all exchanges, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedSpotTicker[]>[]> GetSpotTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get spot ticker information for a symbol on a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedSpotTicker>> GetSpotTickerAsync(string exchange, GetTickerRequest request, CancellationToken ct = default);
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
        Task<ExchangeWebResult<SharedSpotTicker>[]> GetSpotTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get futures ticker information for all symbols on a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesTicker[]>> GetFuturesTickersAsync(string exchange, GetTickersRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get futures ticker information for all symbols on all exchanges, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedFuturesTicker[]>> GetFuturesTickersAsyncEnumerable(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get futures ticker information for all symbols on all exchanges, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesTicker[]>[]> GetFuturesTickersAsync(GetTickersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get futures ticker information for a specific symbol from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesTicker>> GetFuturesTickerAsync(string exchange, GetTickerRequest request, CancellationToken ct = default);
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
        Task<ExchangeWebResult<SharedFuturesTicker>[]> GetFuturesTickerAsync(GetTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get kline data for a specific symbol from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedKline[]>> GetKlinesAsync(string exchange, GetKlinesRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get kline data for a specific symbol from all exchanges, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedKline[]>> GetKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get kline data for a specific symbol from all exchanges, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedKline[]>[]> GetKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get mark price kline data for a specific symbol from a specific symbol
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesKline[]>> GetMarkPriceKlinesAsync(string exchange, GetKlinesRequest request, CancellationToken ct = default);

        /// <summary>
        /// Get mark price kline data for a specific symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedFuturesKline[]>> GetMarkPriceKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get mark price kline data for a specific symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesKline[]>[]> GetMarkPriceKlinesAsync(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get index price kline data for a specific symbol from a specific symbol
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesKline[]>> GetIndexPriceKlinesAsync(string exchange, GetKlinesRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get index price kline data for a specific symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedFuturesKline[]>> GetIndexPriceKlinesAsyncEnumerable(GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get index price kline data for a specific symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesKline[]>[]> GetIndexPriceKlinesAsync( GetKlinesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get recent trades public data for a specific symbol from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedTrade[]>> GetRecentTradesAsync(string exchange, GetRecentTradesRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get recent trades public data for a specific symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedTrade[]>> GetRecentTradesAsyncEnumerable(GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get recent trades public data for a specific symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedTrade[]>[]> GetRecentTradesAsync(GetRecentTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get public trade history data for a specific symbol from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedTrade[]>> GetTradeHistoryAsync(string exchange, GetTradeHistoryRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get public trade history data for a specific symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedTrade[]>> GetTradeHistoryAsyncEnumerable(GetTradeHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get public trade history data for a specific symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedTrade[]>[]> GetTradeHistoryAsync(GetTradeHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get order book data for a specific symbol from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedOrderBook>> GetOrderBookAsync(string exchange, GetOrderBookRequest request, CancellationToken ct = default);
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
        Task<ExchangeWebResult<SharedOrderBook>[]> GetOrderBookAsync(GetOrderBookRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get asset info of all assets on a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedAsset[]>> GetAssetsAsync(string exchange, GetAssetsRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get asset info of all assets on all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedAsset[]>> GetAssetsAsyncEnumerable(GetAssetsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get asset info of all assets on all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedAsset[]>[]> GetAssetsAsync(GetAssetsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get asset info of a specific asset on a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedAsset>> GetAssetAsync(string exchange, GetAssetRequest request, CancellationToken ct = default);
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
        Task<ExchangeWebResult<SharedAsset>[]> GetAssetAsync(GetAssetRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user balances from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedBalance[]>> GetBalancesAsync(string exchange, GetBalancesRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get user balances from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedBalance[]>> GetBalancesAsyncEnumerable(GetBalancesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get user balances from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedBalance[]>[]> GetBalancesAsync(GetBalancesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user deposit history from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedDeposit[]>> GetDepositsAsync(string exchange, GetDepositsRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get user deposit history from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedDeposit[]>> GetDepositsAsyncEnumerable(GetDepositsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get user deposit history from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedDeposit[]>[]> GetDepositsAsync(GetDepositsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user withdrawal history from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedWithdrawal[]>> GetWithdrawalsAsync(string exchange, GetWithdrawalsRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get user withdrawal history from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedWithdrawal[]>> GetWithdrawalsAsyncEnumerable(GetWithdrawalsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get user withdrawal history from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedWithdrawal[]>[]> GetWithdrawalsAsync(GetWithdrawalsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get spot symbol info of all symbols from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedSpotSymbol[]>> GetSpotSymbolsAsync(string exchange, GetSymbolsRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get spot symbol info of all symbols from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedSpotSymbol[]>> GetSpotSymbolsAsyncEnumerable(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get spot symbol info of all symbols from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedSpotSymbol[]>[]> GetSpotSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get open spot orders for the user from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedSpotOrder[]>> GetSpotOpenOrdersAsync(string exchange, GetOpenOrdersRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get open spot orders for the user from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedSpotOrder[]>> GetSpotOpenOrdersAsyncEnumerable(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get open spot orders for the user from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedSpotOrder[]>[]> GetSpotOpenOrdersAsync( GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get closed spot orders for a symbol for the user from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedSpotOrder[]>> GetSpotClosedOrdersAsync(string exchange, GetClosedOrdersRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get closed spot orders for a symbol for the user from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedSpotOrder[]>> GetSpotClosedOrdersAsyncEnumerable(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get closed spot orders for a symbol for the user from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedSpotOrder[]>[]> GetSpotClosedOrdersAsync(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user executed trades from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedUserTrade[]>> GetSpotUserTradesAsync(string exchange, GetUserTradesRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get user executed trades from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedUserTrade[]>> GetSpotUserTradesAsyncEnumerable(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get user executed trades from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedUserTrade[]>[]> GetSpotUserTradesAsync(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get funding rate history for a symbol from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFundingRate[]>> GetFundingRateHistoryAsync(string exchange, GetFundingRateHistoryRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get funding rate history for a symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedFundingRate[]>> GetFundingRateHistoryAsyncEnumerable(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get funding rate history for a symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFundingRate[]>[]> GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get current open interest for a symbol from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedOpenInterest>> GetOpenInterestAsync(string exchange, GetOpenInterestRequest request, CancellationToken ct = default);
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
        Task<ExchangeWebResult<SharedOpenInterest>[]> GetOpenInterestAsync(GetOpenInterestRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get futures symbol info of all symbols from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesSymbol[]>> GetFuturesSymbolsAsync(string exchange, GetSymbolsRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get futures symbol info of all symbols from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedFuturesSymbol[]>> GetFuturesSymbolsAsyncEnumerable(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get futures symbol info of all symbols from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesSymbol[]>[]> GetFuturesSymbolsAsync(GetSymbolsRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user position history from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedPositionHistory[]>> GetPositionHistoryAsync(string exchange, GetPositionHistoryRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get user position history from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedPositionHistory[]>> GetPositionHistoryAsyncEnumerable(GetPositionHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get user position history from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedPositionHistory[]>[]> GetPositionHistoryAsync(GetPositionHistoryRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get open Futures orders for the user from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesOpenOrdersAsync(string exchange, GetOpenOrdersRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get open Futures orders for the user from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesOpenOrdersAsyncEnumerable(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get open Futures orders for the user from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesOrder[]>[]> GetFuturesOpenOrdersAsync(GetOpenOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get closed Futures orders for a symbol from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesOpenOrdersAsync(string exchange, GetClosedOrdersRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get closed Futures orders for a symbol for the user from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedFuturesOrder[]>> GetFuturesClosedOrdersAsyncEnumerable(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);
        /// <summary>
        /// Get closed Futures orders for a symbol for the user from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesOrder[]>[]> GetFuturesClosedOrdersAsync(GetClosedOrdersRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user executed trades from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedUserTrade[]>> GetFuturesUserTradesAsync(string exchange, GetUserTradesRequest request, CancellationToken ct = default);
        /// <summary>
        /// Get user executed trades from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedUserTrade[]>> GetFuturesUserTradesAsyncEnumerable(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get user executed trades from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedUserTrade[]>[]> GetFuturesUserTradesAsync(GetUserTradesRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get Maker and Taker trading fees for a symbol for a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFee>> GetFeesAsync(string exchange, GetFeeRequest request, CancellationToken ct = default);

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
        Task<ExchangeWebResult<SharedFee>[]> GetFeesAsync(GetFeeRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get the book ticker (best ask/bid price and quantity) for a symbol from a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedBookTicker>> GetBookTickerAsync(string exchange, GetBookTickerRequest request, CancellationToken ct = default);

        /// <summary>
        /// Get the book ticker (best ask/bid price and quantity) for a symbol from all exchanges supporting this request, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<SharedBookTicker>> GetBookTickersAsyncEnumerable(GetBookTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get the book ticker (best ask/bid price and quantity) for a symbol from all exchanges supporting this request, returning all results when all responses have been received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedBookTicker>[]> GetBookTickersAsync(GetBookTickerRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get the listen key which can be used for user data updates on the socket client for a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<string>> StartListenKeyAsync(string exchange, StartListenKeyRequest request, CancellationToken ct = default);

        /// <summary>
        /// Get the listen key which can be used for user data updates on the socket client, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<string>> StartListenKeysAsyncEnumerable(StartListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Get the listen key which can be used for user data updates on the socket client from all or selected exchanges
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<string>[]> StartListenKeysAsync(StartListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Keep-Alive the listen key which can be used for user data updates on the socket client for a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<string>> KeepAliveListenKeyAsync(string exchange, KeepAliveListenKeyRequest request, CancellationToken ct = default);

        /// <summary>
        /// Keep-Alive the listen key which can be used for user data updates on the socket client, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<string>> KeepAliveListenKeysAsyncEnumerable(KeepAliveListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Keep-Alive the listen key which can be used for user data updates on the socket client from all or selected exchanges
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<string>[]> KeepAliveListenKeysAsync(KeepAliveListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// End the listen key which can be used for user data updates on the socket client for a specific exchange
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<string>> StopListenKeyAsync(string exchange, StopListenKeyRequest request, CancellationToken ct = default);

        /// <summary>
        /// End the listen key which can be used for user data updates on the socket client, async returning in the order the response from the server is received
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        IAsyncEnumerable<ExchangeWebResult<string>> StopListenKeysAsyncEnumerable(StopListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// End the listen key which can be used for user data updates on the socket client from all or selected exchanges
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="exchanges">Optional exchange filter, when not specified all exchanges will be queried</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<string>[]> StopListenKeysAsync(StopListenKeyRequest request, IEnumerable<string>? exchanges = null, CancellationToken ct = default);

        /// <summary>
        /// Place a new spot order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> PlaceSpotOrderAsync(string exchange, PlaceSpotOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Get info on a specific spot order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedSpotOrder>> GetSpotOrderAsync(string exchange, GetOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Get info on a specific spot order by client order id
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedSpotOrder>> GetSpotOrderByClientOrderIdAsync(string exchange, GetOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Get trades for a specific spot order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedUserTrade[]>> GetSpotOrderTradesAsync(string exchange, GetOrderTradesRequest request, CancellationToken ct = default);

        /// <summary>
        /// Cancel an open spot order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> CancelSpotOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Cancel an open spot order by client order id
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> CancelSpotOrderByClientOrderIdAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Place a futures order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> PlaceFuturesOrderAsync(string exchange, PlaceFuturesOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Get info on a specific futures order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesOrder>> GetFuturesOrderAsync(string exchange, GetOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Get info on a specific futures order by client order id
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedFuturesOrder>> GetFuturesOrderByClientOrderIdAsync(string exchange, GetOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Get trades for a specific futures order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedUserTrade[]>> GetFuturesOrderTradesAsync(string exchange, GetOrderTradesRequest request, CancellationToken ct = default);

        /// <summary>
        /// Cancel an open futures order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> CancelFuturesOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Cancel an open futures order by client order id
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> CancelFuturesOrderByClientOrderIdAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Close an open position
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> ClosePositionAsync(string exchange, ClosePositionRequest request, CancellationToken ct = default);

        /// <summary>
        /// Place a spot order triggering at a specific price
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> PlaceSpotTriggerOrderAsync(string exchange, PlaceSpotTriggerOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Cancel a spot trigger order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> CancelSpotTriggerOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Place a futures order triggering at a specific price
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> PlaceFuturesTriggerOrderAsync(string exchange, PlaceFuturesTriggerOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Cancel a futures trigger order
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> CancelFuturesTriggerOrderAsync(string exchange, CancelOrderRequest request, CancellationToken ct = default);

        /// <summary>
        /// Set a futures TP/SL price
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedId>> SetFuturesTpSlAsync(string exchange, SetTpSlRequest request, CancellationToken ct = default);

        /// <summary>
        /// Cancel a previously set TP/SL price
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<bool>> CancelFuturesTpSlAsync(string exchange, CancelTpSlRequest request, CancellationToken ct = default);

        /// <summary>
        /// Get the current position mode setting
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedPositionModeResult>> GetPositionModeAsync(string exchange, GetPositionModeRequest request, CancellationToken ct = default);

        /// <summary>
        /// Set the position mode to a new value
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedPositionModeResult>> SetPositionModeAsync(string exchange, SetPositionModeRequest request, CancellationToken ct = default);

        /// <summary>
        /// Get the current leverage setting for a symbol
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedLeverage>> GetLeverageAsync(string exchange, GetLeverageRequest request, CancellationToken ct = default);

        /// <summary>
        /// Set the leverage for a symbol
        /// </summary>
        /// <param name="exchange">The exchange</param>
        /// <param name="request">The request</param>
        /// <param name="ct">Cancelation token</param>
        Task<ExchangeWebResult<SharedLeverage>> SetLeverageAsync(string exchange, SetLeverageRequest request, CancellationToken ct = default);
    }
}
