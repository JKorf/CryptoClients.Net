using Aster.Net.Interfaces;
using Binance.Net.Interfaces;
using BingX.Net.Interfaces;
using Bitfinex.Net.Interfaces;
using Bitget.Net.Interfaces;
using BitMart.Net.Interfaces;
using BitMEX.Net.Interfaces;
using Bybit.Net.Interfaces;
using Coinbase.Net.Interfaces;
using CoinEx.Net.Interfaces;
using CryptoCom.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.Klines;
using CryptoExchange.Net.Trackers.Trades;
using DeepCoin.Net.Interfaces;
using GateIo.Net.Interfaces;
using HTX.Net.Interfaces;
using HyperLiquid.Net.Interfaces;
using Kraken.Net.Interfaces;
using Kucoin.Net.Interfaces;
using Mexc.Net.Interfaces;
using OKX.Net.Interfaces;
using Toobit.Net.Interfaces;
using System;
using WhiteBit.Net.Interfaces;
using XT.Net.Interfaces;
using CoinW.Net.Interfaces;
using BloFin.Net.Interfaces;
using Upbit.Net.Interfaces;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Trackers.UserData.Objects;
using CryptoExchange.Net.Trackers.UserData.Interfaces;

namespace CryptoClients.Net.Interfaces
{
    /// <summary>
    /// Factory for creating tracker instances
    /// </summary>
    public interface IExchangeTrackerFactory
    {
        /// <summary>
        /// Aster tracker factory
        /// </summary>
        IAsterTrackerFactory Aster { get; }
        /// <summary>
        /// Binance tracker factory
        /// </summary>
        IBinanceTrackerFactory Binance { get; }
        /// <summary>
        /// BingX tracker factory
        /// </summary>
        IBingXTrackerFactory BingX { get; }
        /// <summary>
        /// Bitfinex tracker factory
        /// </summary>
        IBitfinexTrackerFactory Bitfinex { get; }
        /// <summary>
        /// Bitget tracker factory
        /// </summary>
        IBitgetTrackerFactory Bitget { get; }
        /// <summary>
        /// BitMart tracker factory
        /// </summary>
        IBitMartTrackerFactory BitMart { get; }
        /// <summary>
        /// BitMEX tracker factory
        /// </summary>
        IBitMEXTrackerFactory BitMEX { get; }
        /// <summary>
        /// BloFin tracker factory
        /// </summary>
        IBloFinTrackerFactory BloFin { get; }
        /// <summary>
        /// Bybit tracker factory
        /// </summary>
        IBybitTrackerFactory Bybit { get; }
        /// <summary>
        /// Coinbase tracker factory
        /// </summary>
        ICoinbaseTrackerFactory Coinbase { get; }
        /// <summary>
        /// CoinEx tracker factory
        /// </summary>
        ICoinExTrackerFactory CoinEx { get; }
        /// <summary>
        /// CoinW tracker factory
        /// </summary>
        ICoinWTrackerFactory CoinW { get; }
        /// <summary>
        /// Crypto.com tracker factory
        /// </summary>
        ICryptoComTrackerFactory CryptoCom { get; }
        /// <summary>
        /// DeepCoin tracker factory
        /// </summary>
        IDeepCoinTrackerFactory DeepCoin { get; }
        /// <summary>
        /// Gate.io tracker factory
        /// </summary>
        IGateIoTrackerFactory GateIo { get; }
        /// <summary>
        /// HTX tracker factory
        /// </summary>
        IHTXTrackerFactory HTX { get; }
        /// <summary>
        /// HyperLiquid tracker factory
        /// </summary>
        IHyperLiquidTrackerFactory HyperLiquid { get; }
        /// <summary>
        /// Kraken tracker factory
        /// </summary>
        IKrakenTrackerFactory Kraken { get; }
        /// <summary>
        /// Kucoin tracker factory
        /// </summary>
        IKucoinTrackerFactory Kucoin { get; }
        /// <summary>
        /// Mexc tracker factory
        /// </summary>
        IMexcTrackerFactory Mexc { get; }
        /// <summary>
        /// OKX tracker factory
        /// </summary>
        IOKXTrackerFactory OKX { get; }
        /// <summary>
        /// Toobit tracker factory
        /// </summary>
        IToobitTrackerFactory Toobit { get; }
        /// <summary>
        /// Upbit tracker factory
        /// </summary>
        IUpbitTrackerFactory Upbit { get; }
        /// <summary>
        /// WhiteBit tracker factory
        /// </summary>
        IWhiteBitTrackerFactory WhiteBit { get; }
        /// <summary>
        /// XT tracker factory
        /// </summary>
        IXTTrackerFactory XT { get; }

        /// <summary>
        /// Create a new kline tracker
        /// </summary>
        /// <param name="exchange">The exchange the tracker is for</param>
        /// <param name="symbol">Symbol the tracker is for</param>
        /// <param name="interval">Interval of the klines</param>
        /// <param name="limit">The max number of klines to be tracked, when the max is reached the oldest klines are removed to make room for newer klines</param>
        /// <param name="period">The max age of the klines to be tracked, any kline older than this period will be removed</param>
        /// <param name="exchangeParameters">Exchange specific parameters</param>
        IKlineTracker? CreateKlineTracker(string exchange, SharedSymbol symbol, SharedKlineInterval interval, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null);

        /// <summary>
        /// Create a new trade tracker
        /// </summary>
        /// <param name="exchange">The exchange the tracker is for</param>
        /// <param name="symbol">Symbol the tracker is for</param>
        /// <param name="limit">The max number of trades to be tracked, when the max is reached the oldest trades are removed to make room for newer trades</param>
        /// <param name="period">The max age of the trades to be tracked, any trade older than this period will be removed</param>
        /// <param name="exchangeParameters">Exchange specific parameters</param>
        ITradeTracker? CreateTradeTracker(string exchange, SharedSymbol symbol, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null);

        /// <summary>
        /// Create a new Spot user data tracker for an exchange
        /// </summary>
        /// <param name="exchange">The name of the exchange</param>
        /// <param name="config">Tracker config</param>
        IUserSpotDataTracker? CreateUserSpotDataTracker(string exchange, SpotUserDataTrackerConfig? config = null);

        /// <summary>
        /// Create a new Spot user data tracker for all or specified exchanges
        /// </summary>
        /// <param name="config">Tracker config</param>
        /// <param name="exchanges">Filter exchanges to create tracker for</param>
        IUserSpotDataTracker[] CreateUserSpotDataTrackers(SpotUserDataTrackerConfig? config = null, string[]? exchanges = null);

        /// <summary>
        /// Create a new Spot user data tracker for an exchange
        /// </summary>
        /// <param name="exchange">The name of the exchange</param>
        /// <param name="userIdentifier">User identifier</param>
        /// <param name="config">Configuration</param>
        /// <param name="credentials">Credentials</param>
        /// <param name="environment">Environment</param>
        IUserSpotDataTracker? CreateUserSpotDataTracker(
            string exchange,
            string userIdentifier,
            ApiCredentials credentials,
            SpotUserDataTrackerConfig? config = null,
            string? environment = null);

        /// <summary>
        /// Create a new Futures user data tracker for an exchange
        /// </summary>
        /// <param name="exchange">The name of the exchange</param>
        /// <param name="config">Configuration</param>
        /// <param name="tradeMode">Futures trade mode</param>
        /// <param name="exchangeParameters">Exchange parameters</param>
        IUserFuturesDataTracker? CreateUserFuturesDataTracker(
            string exchange, 
            TradingMode tradeMode,
            FuturesUserDataTrackerConfig? config = null,
            ExchangeParameters? exchangeParameters = null);

        /// <summary>
        /// Create a new Futures user data tracker for all or specified exchanges
        /// </summary>
        /// <param name="config">Configuration</param>
        /// <param name="tradeMode">Futures trade mode</param>
        /// <param name="exchangeParameters">Exchange parameters</param>
        /// <param name="exchanges">Filter exchanges to create tracker for</param>
        IUserFuturesDataTracker[] CreateUserFuturesDataTrackers(
            TradingMode tradeMode,
            FuturesUserDataTrackerConfig? config = null,
            ExchangeParameters? exchangeParameters = null,
            string[]? exchanges = null);

        /// <summary>
        /// Create a new Futures user data tracker for an exchange
        /// </summary>
        /// <param name="exchange">The name of the exchange</param>
        /// <param name="tradeMode">Futures trade mode</param>
        /// <param name="userIdentifier">User identifier</param>
        /// <param name="config">Configuration</param>
        /// <param name="credentials">Credentials</param>
        /// <param name="environment">Environment</param>
        /// <param name="exchangeParameters">Exchange parameters</param>
        IUserFuturesDataTracker? CreateUserFuturesDataTracker(
            string exchange,
            TradingMode tradeMode,
            string userIdentifier,
            ApiCredentials credentials,
            FuturesUserDataTrackerConfig? config = null,
            string? environment = null,
            ExchangeParameters? exchangeParameters = null);
    }
}