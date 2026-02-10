using Aster.Net;
using Aster.Net.Interfaces;
using Binance.Net;
using Binance.Net.Interfaces;
using BingX.Net;
using BingX.Net.Interfaces;
using Bitfinex.Net;
using Bitfinex.Net.Interfaces;
using Bitget.Net;
using Bitget.Net.Enums;
using Bitget.Net.Interfaces;
using BitMart.Net;
using BitMart.Net.Interfaces;
using BitMEX.Net;
using BitMEX.Net.Interfaces;
using BloFin.Net;
using BloFin.Net.Interfaces;
using Bybit.Net;
using Bybit.Net.Interfaces;
using Coinbase.Net;
using Coinbase.Net.Interfaces;
using CoinEx.Net;
using CoinEx.Net.Interfaces;
using CoinW.Net;
using CoinW.Net.Interfaces;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.Models;
using CryptoCom.Net;
using CryptoCom.Net.Interfaces;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.Klines;
using CryptoExchange.Net.Trackers.Trades;
using CryptoExchange.Net.Trackers.UserData.Interfaces;
using CryptoExchange.Net.Trackers.UserData.Objects;
using DeepCoin.Net;
using DeepCoin.Net.Interfaces;
using GateIo.Net;
using GateIo.Net.Interfaces;
using HTX.Net;
using HTX.Net.Interfaces;
using HyperLiquid.Net;
using HyperLiquid.Net.Interfaces;
using Kraken.Net;
using Kraken.Net.Interfaces;
using Kucoin.Net;
using Kucoin.Net.Interfaces;
using Mexc.Net;
using Mexc.Net.Interfaces;
using OKX.Net;
using OKX.Net.Interfaces;
using System;
using System.Collections.Generic;
using Toobit.Net;
using Toobit.Net.Interfaces;
using Upbit.Net.Interfaces;
using WhiteBit.Net;
using WhiteBit.Net.Interfaces;
using XT.Net;
using XT.Net.Interfaces;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public class ExchangeTrackerFactory : IExchangeTrackerFactory
    {
        /// <inheritdoc />
        public IAsterTrackerFactory Aster { get; }
        /// <inheritdoc />
        public IBinanceTrackerFactory Binance { get; }
        /// <inheritdoc />
        public IBingXTrackerFactory BingX { get; }
        /// <inheritdoc />
        public IBitfinexTrackerFactory Bitfinex { get; }
        /// <inheritdoc />
        public IBitgetTrackerFactory Bitget { get; }
        /// <inheritdoc />
        public IBitMartTrackerFactory BitMart { get; }
        /// <inheritdoc />
        public IBitMEXTrackerFactory BitMEX { get; }
        /// <inheritdoc />
        public IBloFinTrackerFactory BloFin { get; }
        /// <inheritdoc />
        public IBybitTrackerFactory Bybit { get; }
        /// <inheritdoc />
        public ICoinbaseTrackerFactory Coinbase { get; }
        /// <inheritdoc />
        public ICoinExTrackerFactory CoinEx { get; }
        /// <inheritdoc />
        public ICoinWTrackerFactory CoinW { get; }
        /// <inheritdoc />
        public ICryptoComTrackerFactory CryptoCom { get; }
        /// <inheritdoc />
        public IDeepCoinTrackerFactory DeepCoin { get; }
        /// <inheritdoc />
        public IGateIoTrackerFactory GateIo { get; }
        /// <inheritdoc />
        public IHTXTrackerFactory HTX { get; }
        /// <inheritdoc />
        public IHyperLiquidTrackerFactory HyperLiquid { get; }
        /// <inheritdoc />
        public IKrakenTrackerFactory Kraken { get; }
        /// <inheritdoc />
        public IKucoinTrackerFactory Kucoin { get; }
        /// <inheritdoc />
        public IMexcTrackerFactory Mexc { get; }
        /// <inheritdoc />
        public IOKXTrackerFactory OKX { get; }
        /// <inheritdoc />
        public IToobitTrackerFactory Toobit { get; }
        /// <inheritdoc />
        public IUpbitTrackerFactory Upbit { get; }
        /// <inheritdoc />
        public IWhiteBitTrackerFactory WhiteBit { get; }
        /// <inheritdoc />
        public IXTTrackerFactory XT { get; }

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeTrackerFactory(
            IAsterTrackerFactory aster,
            IBinanceTrackerFactory binance,
            IBingXTrackerFactory bingx,
            IBitfinexTrackerFactory bitfinex,
            IBitgetTrackerFactory bitget,
            IBitMartTrackerFactory bitMart,
            IBitMEXTrackerFactory bitMEX,
            IBloFinTrackerFactory bloFin,
            IBybitTrackerFactory bybit,
            ICoinbaseTrackerFactory coinbase,
            ICoinExTrackerFactory coinEx,
            ICoinWTrackerFactory coinW,
            ICryptoComTrackerFactory cryptoCom,
            IDeepCoinTrackerFactory deepCoin,
            IGateIoTrackerFactory gateIo,
            IHTXTrackerFactory htx,
            IHyperLiquidTrackerFactory hyperLiquid,
            IKrakenTrackerFactory kraken,
            IKucoinTrackerFactory kucoin,
            IMexcTrackerFactory mexc,
            IOKXTrackerFactory okx,
            IToobitTrackerFactory toobit,
            IUpbitTrackerFactory upbit,
            IWhiteBitTrackerFactory whiteBit,
            IXTTrackerFactory xt)
        {
            Aster = aster;
            Binance = binance;
            BingX = bingx;
            Bitfinex = bitfinex;
            Bitget = bitget;
            BitMart = bitMart;
            BitMEX = bitMEX;
            BloFin = bloFin;
            Bybit = bybit;
            Coinbase = coinbase;
            CoinEx = coinEx;
            CoinW = coinW;
            CryptoCom = cryptoCom;
            DeepCoin = deepCoin;
            GateIo = gateIo;
            HTX = htx;
            HyperLiquid = hyperLiquid;
            Kraken = kraken;
            Kucoin = kucoin;
            Mexc = mexc;
            OKX = okx;
            Toobit = toobit;
            Upbit = upbit;
            WhiteBit = whiteBit;
            XT = xt;
        }

        private ITrackerFactory? GetTrackerFactoryForExchange(string exchange)
        {
            return exchange switch
            {
                "Aster" => Aster,
                "Binance" => Binance,
                "BingX" => BingX,
                "Bitfinex" => Bitfinex,
                "Bitget" => Bitget,
                "BitMart" => BitMart,
                "BitMEX" => BitMEX,
                "BloFin" => BloFin,
                "Bybit" => Bybit,
                "Coinbase" => Coinbase,
                "CoinEx" => CoinEx,
                "CoinW" => CoinW,
                "CryptoCom" => CryptoCom,
                "DeepCoin" => DeepCoin,
                "GateIo" => GateIo,
                "HTX" => HTX,
                "HyperLiquid" => HyperLiquid,
                "Kraken" => Kraken,
                "Kucoin" => Kucoin,
                "Mexc" => Mexc,
                "OKX" => OKX,
                "Toobit" => Toobit,
                "Upbit" => Upbit,
                "WhiteBit" => WhiteBit,
                "XT" => XT,
                _ => null
            };
        }

        /// <inheritdoc />
        public IKlineTracker? CreateKlineTracker(string exchange, SharedSymbol symbol, SharedKlineInterval interval, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null)
        {
            var factory = GetTrackerFactoryForExchange(exchange);
            if (factory == null)
                return null;

            if (!factory.CanCreateKlineTracker(symbol, interval))
                return null;

            return factory.CreateKlineTracker(symbol, interval);
        }

        /// <inheritdoc />
        public ITradeTracker? CreateTradeTracker(string exchange, SharedSymbol symbol, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null)
        {
            var factory = GetTrackerFactoryForExchange(exchange);
            if (factory == null)
                return null;

            if (!factory.CanCreateTradeTracker(symbol))
                return null;

            return factory.CreateTradeTracker(symbol);
        }

        /// <inheritdoc />
        public IUserSpotDataTracker? CreateUserSpotDataTracker(string exchange, SpotUserDataTrackerConfig? config = null)
        {
            return exchange switch
            {
                "Aster" => Aster.CreateUserSpotDataTracker(config),
                "Binance" => Binance.CreateUserSpotDataTracker(config),
                "BingX" => BingX.CreateUserSpotDataTracker(config),
                "Bitfinex" => Bitfinex.CreateUserSpotDataTracker(config),
                "Bitget" => Bitget.CreateUserSpotDataTracker(config),
                "BitMart" => BitMart.CreateUserSpotDataTracker(config),
                "BitMEX" => BitMEX.CreateUserSpotDataTracker(config),
                "Bybit" => Bybit.CreateUserSpotDataTracker(config),
                "Coinbase" => Coinbase.CreateUserSpotDataTracker(config),
                "CoinEx" => CoinEx.CreateUserSpotDataTracker(config),
                "CoinW" => CoinW.CreateUserSpotDataTracker(config),
                "CryptoCom" => CryptoCom.CreateUserSpotDataTracker(config),
                "DeepCoin" => DeepCoin.CreateUserSpotDataTracker(config),
                "GateIo" => GateIo.CreateUserSpotDataTracker(config),
                "HTX" => HTX.CreateUserSpotDataTracker(config),
                "HyperLiquid" => HyperLiquid.CreateUserSpotDataTracker(config),
                "Kraken" => Kraken.CreateUserSpotDataTracker(config),
                "Kucoin" => Kucoin.CreateUserSpotDataTracker(config),
                "Mexc" => Mexc.CreateUserSpotDataTracker(config),
                "OKX" => OKX.CreateUserSpotDataTracker(config),
                "Toobit" => Toobit.CreateUserSpotDataTracker(config),
                "WhiteBit" => WhiteBit.CreateUserSpotDataTracker(config),
                "XT" => XT.CreateUserSpotDataTracker(config),
                _ => null
            };
        }

        /// <inheritdoc />
        public IUserSpotDataTracker[] CreateUserSpotDataTrackers(SpotUserDataTrackerConfig? config = null, string[]? exchanges = null)
        {
            var result = new List<IUserSpotDataTracker>();
            foreach (var exchange in exchanges ?? Exchange.All)
            {
                var tracker = CreateUserSpotDataTracker(exchange, config);
                if (tracker == null)
                    continue;

                result.Add(tracker);
            }

            return result.ToArray();
        }

        /// <inheritdoc />
        public IUserSpotDataTracker? CreateUserSpotDataTracker(string exchange, string userIdentifier, ApiCredentials credentials, SpotUserDataTrackerConfig? config = null, string? environment = null)
        {
            return exchange switch
            {
                "Aster" => Aster.CreateUserSpotDataTracker(userIdentifier, credentials, config, AsterEnvironment.GetEnvironmentByName(environment)),
                "Binance" => Binance.CreateUserSpotDataTracker(userIdentifier, credentials, config, BinanceEnvironment.GetEnvironmentByName(environment)),
                "BingX" => BingX.CreateUserSpotDataTracker(userIdentifier, credentials, config, BingXEnvironment.GetEnvironmentByName(environment)),
                "Bitfinex" => Bitfinex.CreateUserSpotDataTracker(userIdentifier, credentials, config, BitfinexEnvironment.GetEnvironmentByName(environment)),
                "Bitget" => Bitget.CreateUserSpotDataTracker(userIdentifier, credentials, config, BitgetEnvironment.GetEnvironmentByName(environment)),
                "BitMart" => BitMart.CreateUserSpotDataTracker(userIdentifier, credentials, config, BitMartEnvironment.GetEnvironmentByName(environment)),
                "BitMEX" => BitMEX.CreateUserSpotDataTracker(userIdentifier, credentials, config, BitMEXEnvironment.GetEnvironmentByName(environment)),
                "Bybit" => Bybit.CreateUserSpotDataTracker(userIdentifier, credentials, config, BybitEnvironment.GetEnvironmentByName(environment)),
                "Coinbase" => Coinbase.CreateUserSpotDataTracker(userIdentifier, credentials, config, CoinbaseEnvironment.GetEnvironmentByName(environment)),
                "CoinEx" => CoinEx.CreateUserSpotDataTracker(userIdentifier, credentials, config, CoinExEnvironment.GetEnvironmentByName(environment)),
                "CoinW" => CoinW.CreateUserSpotDataTracker(userIdentifier, credentials, config, CoinWEnvironment.GetEnvironmentByName(environment)),
                "CryptoCom" => CryptoCom.CreateUserSpotDataTracker(userIdentifier, credentials, config, CryptoComEnvironment.GetEnvironmentByName(environment)),
                "DeepCoin" => DeepCoin.CreateUserSpotDataTracker(userIdentifier, credentials, config, DeepCoinEnvironment.GetEnvironmentByName(environment)),
                "GateIo" => GateIo.CreateUserSpotDataTracker(userIdentifier, credentials, config, GateIoEnvironment.GetEnvironmentByName(environment)),
                "HTX" => HTX.CreateUserSpotDataTracker(userIdentifier, credentials, config, HTXEnvironment.GetEnvironmentByName(environment)),
                "HyperLiquid" => HyperLiquid.CreateUserSpotDataTracker(userIdentifier, credentials, config, HyperLiquidEnvironment.GetEnvironmentByName(environment)),
                "Kraken" => Kraken.CreateUserSpotDataTracker(userIdentifier, credentials, config, KrakenEnvironment.GetEnvironmentByName(environment)),
                "Kucoin" => Kucoin.CreateUserSpotDataTracker(userIdentifier, credentials, config, KucoinEnvironment.GetEnvironmentByName(environment)),
                "Mexc" => Mexc.CreateUserSpotDataTracker(userIdentifier, credentials, config, MexcEnvironment.GetEnvironmentByName(environment)),
                "OKX" => OKX.CreateUserSpotDataTracker(userIdentifier, credentials, config, OKXEnvironment.GetEnvironmentByName(environment)),
                "Toobit" => Toobit.CreateUserSpotDataTracker(userIdentifier, credentials, config, ToobitEnvironment.GetEnvironmentByName(environment)),
                "WhiteBit" => WhiteBit.CreateUserSpotDataTracker(userIdentifier, credentials, config, WhiteBitEnvironment.GetEnvironmentByName(environment)),
                "XT" => XT.CreateUserSpotDataTracker(userIdentifier, credentials, config, XTEnvironment.GetEnvironmentByName(environment)),
                _ => null
            };
        }

        /// <inheritdoc />
        public IUserSpotDataTracker[] CreateUserSpotDataTracker(
            string userIdentifier,
            ExchangeCredentials credentials, 
            SpotUserDataTrackerConfig? config = null, 
            Dictionary<string, string>? environments = null,
            string[]? exchanges = null)
        {
            var result = new List<IUserSpotDataTracker>();
            foreach (var exchange in exchanges ?? Exchange.All)
            {
                var tracker = CreateUserSpotDataTracker(
                    exchange,
                    userIdentifier,
                    credentials.GetCredentials(exchange) ?? throw new ArgumentNullException("No credentials provided for " + exchange),
                    config,
                    environments?.TryGetValue(exchange, out var env) == true ? env : null);
                if (tracker == null)
                    continue;

                result.Add(tracker);
            }

            return result.ToArray();
        }

        /// <inheritdoc />
        public IUserFuturesDataTracker? CreateUserFuturesDataTracker(string exchange, TradingMode tradeMode, FuturesUserDataTrackerConfig? config = null, ExchangeParameters? exchangeParameters = null)
        {
            return exchange switch
            {
                "Aster" => Aster.CreateUserFuturesDataTracker(config),
                "Binance" => tradeMode.IsLinear() ? Binance.CreateUserUsdFuturesDataTracker(config) : Binance.CreateUserCoinFuturesDataTracker(config),
                "BingX" => BingX.BingXUserPerpetualFuturesDataTracker(config),
                "Bitget" => Bitget.CreateUserFuturesDataTracker(
                    ExchangeParameters.GetValue<string?>(exchangeParameters, "Bitget", "ProductType") == "UsdtFutures" ? BitgetProductTypeV2.UsdtFutures : BitgetProductTypeV2.UsdcFutures,
                    config),
                "BitMart" => BitMart.CreateUserUsdFuturesDataTracker(config),
                "BitMEX" => BitMEX.CreateUserFuturesDataTracker(config),
                "BloFin" => BloFin.CreateUserFuturesDataTracker(config),
                "Bybit" => Bybit.CreateUserFuturesDataTracker(config),
                "Coinbase" => Coinbase.CreateUserFuturesDataTracker(config),
                "CoinEx" => CoinEx.CreateUserFuturesDataTracker(config),
                "CoinW" => CoinW.CreateUserFuturesDataTracker(config),
                "CryptoCom" => CryptoCom.CreateUserFuturesDataTracker(config),
                "DeepCoin" => DeepCoin.CreateUserFuturesDataTracker(config),
                "GateIo" => GateIo.CreateUserPerpetualFuturesDataTracker(
                    ExchangeParameters.GetValue<string>(exchangeParameters, "GateIo", "SettleAsset") ?? throw new ArgumentException("SettleAsset exchange parameter should be provided for GateIo", "SettleAsset"),
                    ExchangeParameters.GetValue<long?>(exchangeParameters, "GateIo", "UserId") ?? throw new ArgumentException("UserId exchange parameter should be provided for GateIo", "UserId"), 
                    config),
                "HTX" => HTX.CreateUserFuturesDataTracker(
                    ExchangeParameters.GetValue<SharedMarginMode?>(exchangeParameters, "HTX", "MarginMode") == SharedMarginMode.Isolated ? SharedMarginMode.Isolated : SharedMarginMode.Cross,
                    config),
                "HyperLiquid" => HyperLiquid.CreateUserFuturesDataTracker(config),
                "Kraken" => Kraken.CreateUserFuturesDataTracker(config),
                "Kucoin" => Kucoin.CreateUserFuturesDataTracker(config),
                "OKX" => OKX.CreateUserFuturesDataTracker(config),
                "Toobit" => Toobit.CreateUserUsdtFuturesDataTracker(config),
                "WhiteBit" => WhiteBit.CreateUserFuturesDataTracker(config),
                "XT" => tradeMode.IsLinear() ? XT.CreateUserUsdtFuturesDataTracker(config) : null,
                _ => null
            };
        }

        /// <inheritdoc />
        public IUserFuturesDataTracker[] CreateUserFuturesDataTrackers(TradingMode tradeMode, FuturesUserDataTrackerConfig? config = null, ExchangeParameters? exchangeParameters = null, string[]? exchanges = null)
        {
            var result = new List<IUserFuturesDataTracker>();
            foreach (var exchange in exchanges ?? Exchange.All)
            {
                var tracker = CreateUserFuturesDataTracker(exchange, tradeMode, config, exchangeParameters);
                if (tracker == null)
                    continue;

                result.Add(tracker);
            }

            return result.ToArray();
        }

        /// <inheritdoc />
        public IUserFuturesDataTracker? CreateUserFuturesDataTracker(string exchange, TradingMode tradeMode, string userIdentifier, ApiCredentials credentials, FuturesUserDataTrackerConfig? config = null, string? environment = null, ExchangeParameters? exchangeParameters = null)
        {
            return exchange switch
            {
                "Aster" => Aster.CreateUserFuturesDataTracker(userIdentifier, credentials, config, AsterEnvironment.GetEnvironmentByName(environment)),
                "Binance" => tradeMode.IsLinear() 
                                ? Binance.CreateUserUsdFuturesDataTracker(userIdentifier, credentials, config, BinanceEnvironment.GetEnvironmentByName(environment)) 
                                : Binance.CreateUserCoinFuturesDataTracker(userIdentifier, credentials, config, BinanceEnvironment.GetEnvironmentByName(environment)),
                "BingX" => BingX.BingXUserPerpetualFuturesDataTracker(userIdentifier, credentials, config, BingXEnvironment.GetEnvironmentByName(environment)),
                "Bitget" => Bitget.CreateUserFuturesDataTracker(
                    userIdentifier,
                    credentials,
                    ExchangeParameters.GetValue<string?>(exchangeParameters, "Bitget", "ProductType") == "UsdtFutures" ? BitgetProductTypeV2.UsdtFutures : BitgetProductTypeV2.UsdcFutures,
                    config,
                    BitgetEnvironment.GetEnvironmentByName(environment)),
                "BitMart" => BitMart.CreateUserUsdFuturesDataTracker(userIdentifier, credentials, config, BitMartEnvironment.GetEnvironmentByName(environment)),
                "BitMEX" => BitMEX.CreateUserFuturesDataTracker(userIdentifier, credentials, config, BitMEXEnvironment.GetEnvironmentByName(environment)),
                "BloFin" => BloFin.CreateUserFuturesDataTracker(userIdentifier, credentials, config, BloFinEnvironment.GetEnvironmentByName(environment)),
                "Bybit" => Bybit.CreateUserFuturesDataTracker(userIdentifier, credentials, config, BybitEnvironment.GetEnvironmentByName(environment)),
                "Coinbase" => Coinbase.CreateUserFuturesDataTracker(userIdentifier, credentials, config, CoinbaseEnvironment.GetEnvironmentByName(environment)),
                "CoinEx" => CoinEx.CreateUserFuturesDataTracker(userIdentifier, credentials, config, CoinExEnvironment.GetEnvironmentByName(environment)),
                "CoinW" => CoinW.CreateUserFuturesDataTracker(userIdentifier, credentials, config, CoinWEnvironment.GetEnvironmentByName(environment)),
                "CryptoCom" => CryptoCom.CreateUserFuturesDataTracker(userIdentifier, credentials, config, CryptoComEnvironment.GetEnvironmentByName(environment)),
                "DeepCoin" => DeepCoin.CreateUserFuturesDataTracker(userIdentifier, credentials, config, DeepCoinEnvironment.GetEnvironmentByName(environment)),
                "GateIo" => GateIo.CreateUserPerpetualFuturesDataTracker(
                    userIdentifier, 
                    credentials,
                    ExchangeParameters.GetValue<string>(exchangeParameters, "GateIo", "SettleAsset") ?? throw new ArgumentException("SettleAsset exchange parameter should be provided for GateIo", "SettleAsset"),
                    ExchangeParameters.GetValue<long?>(exchangeParameters, "GateIo", "UserId") ?? throw new ArgumentException("UserId exchange parameter should be provided for GateIo", "UserId"),
                    config,
                    GateIoEnvironment.GetEnvironmentByName(environment)),
                "HTX" => HTX.CreateUserFuturesDataTracker(
                    userIdentifier,
                    credentials,
                    ExchangeParameters.GetValue<SharedMarginMode?>(exchangeParameters, "HTX", "MarginMode") == SharedMarginMode.Isolated ? SharedMarginMode.Isolated : SharedMarginMode.Cross,
                    config,
                    HTXEnvironment.GetEnvironmentByName(environment)),
                "HyperLiquid" => HyperLiquid.CreateUserFuturesDataTracker(userIdentifier, credentials, config, HyperLiquidEnvironment.GetEnvironmentByName(environment)),
                "Kraken" => Kraken.CreateUserFuturesDataTracker(userIdentifier, credentials, config, KrakenEnvironment.GetEnvironmentByName(environment)),
                "Kucoin" => Kucoin.CreateUserFuturesDataTracker(userIdentifier, credentials, config, KucoinEnvironment.GetEnvironmentByName(environment)),
                "OKX" => OKX.CreateUserFuturesDataTracker(userIdentifier, credentials, config, OKXEnvironment.GetEnvironmentByName(environment)),
                "Toobit" => Toobit.CreateUserUsdtFuturesDataTracker(userIdentifier, credentials, config, ToobitEnvironment.GetEnvironmentByName(environment)),
                "WhiteBit" => WhiteBit.CreateUserFuturesDataTracker(userIdentifier, credentials, config, WhiteBitEnvironment.GetEnvironmentByName(environment)),
                "XT" => tradeMode.IsLinear() ? XT.CreateUserUsdtFuturesDataTracker(userIdentifier, credentials, config, XTEnvironment.GetEnvironmentByName(environment)) : null,
                _ => null
            };
        }

        /// <inheritdoc />
        public IUserFuturesDataTracker[] CreateUserFuturesDataTracker(
            string userIdentifier,
            TradingMode tradingMode,
            ExchangeCredentials credentials,
            FuturesUserDataTrackerConfig? config = null,
            Dictionary<string, string>? environments = null,
            string[]? exchanges = null)
        {
            var result = new List<IUserFuturesDataTracker>();
            foreach (var exchange in exchanges ?? Exchange.All)
            {
                var tracker = CreateUserFuturesDataTracker(
                    exchange,
                    tradingMode,
                    userIdentifier,
                    credentials.GetCredentials(exchange) ?? throw new ArgumentNullException("No credentials provided for " + exchange),
                    config,
                    environments?.TryGetValue(exchange, out var env) == true ? env : null);
                if (tracker == null)
                    continue;

                result.Add(tracker);
            }

            return result.ToArray();
        }

    }
}
