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
using Bitstamp.Net;
using Bitstamp.Net.Interfaces;
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
using LBank.Net;
using LBank.Net.Interfaces;
using Lighter.Net;
using Lighter.Net.Interfaces;
using Mexc.Net;
using Mexc.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using OKX.Net;
using OKX.Net.Interfaces;
using Pionex.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using Tapbit.Net;
using Tapbit.Net.Interfaces;
using Toobit.Net;
using Toobit.Net.Interfaces;
using Upbit.Net.Interfaces;
using Weex.Net;
using Weex.Net.Interfaces;
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
        public IAsterTrackerFactory Aster => GetFactory(Exchange.Aster, _aster);
        /// <inheritdoc />
        public IBinanceTrackerFactory Binance => GetFactory(Exchange.Binance, _binance);
        /// <inheritdoc />
        public IBingXTrackerFactory BingX => GetFactory(Exchange.BingX, _bingX);
        /// <inheritdoc />
        public IBitfinexTrackerFactory Bitfinex => GetFactory(Exchange.Bitfinex, _bitfinex);
        /// <inheritdoc />
        public IBitgetTrackerFactory Bitget => GetFactory(Exchange.Bitget, _bitget);
        /// <inheritdoc />
        public IBitMartTrackerFactory BitMart => GetFactory(Exchange.BitMart, _bitMart);
        /// <inheritdoc />
        public IBitMEXTrackerFactory BitMEX => GetFactory(Exchange.BitMEX, _bitMEX);
        /// <inheritdoc />
        public IBitstampTrackerFactory Bitstamp => GetFactory(Exchange.Bitstamp, _bitstamp);
        /// <inheritdoc />
        public IBloFinTrackerFactory BloFin => GetFactory(Exchange.BloFin, _bloFin);
        /// <inheritdoc />
        public IBybitTrackerFactory Bybit => GetFactory(Exchange.Bybit, _bybit);
        /// <inheritdoc />
        public ICoinbaseTrackerFactory Coinbase => GetFactory(Exchange.Coinbase, _coinbase);
        /// <inheritdoc />
        public ICoinExTrackerFactory CoinEx => GetFactory(Exchange.CoinEx, _coinEx);
        /// <inheritdoc />
        public ICoinWTrackerFactory CoinW => GetFactory(Exchange.CoinW, _coinW);
        /// <inheritdoc />
        public ICryptoComTrackerFactory CryptoCom => GetFactory(Exchange.CryptoCom, _cryptoCom);
        /// <inheritdoc />
        public IDeepCoinTrackerFactory DeepCoin => GetFactory(Exchange.DeepCoin, _deepCoin);
        /// <inheritdoc />
        public IGateIoTrackerFactory GateIo => GetFactory(Exchange.GateIo, _gateIo);
        /// <inheritdoc />
        public IHTXTrackerFactory HTX => GetFactory(Exchange.HTX, _htx);
        /// <inheritdoc />
        public IHyperLiquidTrackerFactory HyperLiquid => GetFactory(Exchange.HyperLiquid, _hyperLiquid);
        /// <inheritdoc />
        public IKrakenTrackerFactory Kraken => GetFactory(Exchange.Kraken, _kraken);
        /// <inheritdoc />
        public IKucoinTrackerFactory Kucoin => GetFactory(Exchange.Kucoin, _kucoin);
        /// <inheritdoc />
        public ILBankTrackerFactory LBank => GetFactory(Exchange.LBank, _lBank);
        /// <inheritdoc />
        public ILighterTrackerFactory Lighter => GetFactory(Exchange.Lighter, _lighter);
        /// <inheritdoc />
        public IMexcTrackerFactory Mexc => GetFactory(Exchange.Mexc, _mexc);
        /// <inheritdoc />
        public IOKXTrackerFactory OKX => GetFactory(Exchange.OKX, _okx);
        /// <inheritdoc />
        public IPionexTrackerFactory Pionex => GetFactory(Exchange.Pionex, _pionex);
        /// <inheritdoc />
        public ITapbitTrackerFactory Tapbit => GetFactory(Exchange.Tapbit, _tapbit);
        /// <inheritdoc />
        public IToobitTrackerFactory Toobit => GetFactory(Exchange.Toobit, _toobit);
        /// <inheritdoc />
        public IUpbitTrackerFactory Upbit => GetFactory(Exchange.Upbit, _upbit);
        /// <inheritdoc />
        public IWeexTrackerFactory Weex => GetFactory(Exchange.Weex, _weex);
        /// <inheritdoc />
        public IWhiteBitTrackerFactory WhiteBit => GetFactory(Exchange.WhiteBit, _whiteBit);
        /// <inheritdoc />
        public IXTTrackerFactory XT => GetFactory(Exchange.XT, _xt);

        private HashSet<string>? _enabledExchanges;
        private Lazy<IAsterTrackerFactory> _aster = null!;
        private Lazy<IBinanceTrackerFactory> _binance = null!;
        private Lazy<IBingXTrackerFactory> _bingX = null!;
        private Lazy<IBitfinexTrackerFactory> _bitfinex = null!;
        private Lazy<IBitgetTrackerFactory> _bitget = null!;
        private Lazy<IBitMartTrackerFactory> _bitMart = null!;
        private Lazy<IBitMEXTrackerFactory> _bitMEX = null!;
        private Lazy<IBitstampTrackerFactory> _bitstamp = null!;
        private Lazy<IBloFinTrackerFactory> _bloFin = null!;
        private Lazy<IBybitTrackerFactory> _bybit = null!;
        private Lazy<ICoinbaseTrackerFactory> _coinbase = null!;
        private Lazy<ICoinExTrackerFactory> _coinEx = null!;
        private Lazy<ICoinWTrackerFactory> _coinW = null!;
        private Lazy<ICryptoComTrackerFactory> _cryptoCom = null!;
        private Lazy<IDeepCoinTrackerFactory> _deepCoin = null!;
        private Lazy<IGateIoTrackerFactory> _gateIo = null!;
        private Lazy<IHTXTrackerFactory> _htx = null!;
        private Lazy<IHyperLiquidTrackerFactory> _hyperLiquid = null!;
        private Lazy<IKrakenTrackerFactory> _kraken = null!;
        private Lazy<IKucoinTrackerFactory> _kucoin = null!;
        private Lazy<ILBankTrackerFactory> _lBank = null!;
        private Lazy<ILighterTrackerFactory> _lighter = null!;
        private Lazy<IMexcTrackerFactory> _mexc = null!;
        private Lazy<IOKXTrackerFactory> _okx = null!;
        private Lazy<IPionexTrackerFactory> _pionex = null!;
        private Lazy<ITapbitTrackerFactory> _tapbit = null!;
        private Lazy<IToobitTrackerFactory> _toobit = null!;
        private Lazy<IUpbitTrackerFactory> _upbit = null!;
        private Lazy<IWeexTrackerFactory> _weex = null!;
        private Lazy<IWhiteBitTrackerFactory> _whiteBit = null!;
        private Lazy<IXTTrackerFactory> _xt = null!;

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
            IBitstampTrackerFactory bitstamp,
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
            ILBankTrackerFactory lBank,
            ILighterTrackerFactory lighter,
            IMexcTrackerFactory mexc,
            IOKXTrackerFactory okx,
            IPionexTrackerFactory pionex,
            ITapbitTrackerFactory tapbit,
            IToobitTrackerFactory toobit,
            IUpbitTrackerFactory upbit,
            IWeexTrackerFactory weex,
            IWhiteBitTrackerFactory whiteBit,
            IXTTrackerFactory xt)
        {
            InitializeFactories(null,
                () => aster, () => binance, () => bingx, () => bitfinex, () => bitget, () => bitMart, () => bitMEX, () => bitstamp,
                () => bloFin, () => bybit, () => coinbase, () => coinEx, () => coinW, () => cryptoCom, () => deepCoin, () => gateIo,
                () => htx, () => hyperLiquid, () => kraken, () => kucoin, () => lBank, () => lighter, () => mexc, () => okx,
                () => pionex, () => tapbit, () => toobit, () => upbit, () => weex, () => whiteBit, () => xt);
        }

        internal ExchangeTrackerFactory(IEnumerable<string>? enabledExchanges, IServiceProvider serviceProvider)
        {
            InitializeFactories(enabledExchanges,
                () => serviceProvider.GetRequiredService<IAsterTrackerFactory>(), () => serviceProvider.GetRequiredService<IBinanceTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IBingXTrackerFactory>(), () => serviceProvider.GetRequiredService<IBitfinexTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IBitgetTrackerFactory>(), () => serviceProvider.GetRequiredService<IBitMartTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IBitMEXTrackerFactory>(), () => serviceProvider.GetRequiredService<IBitstampTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IBloFinTrackerFactory>(), () => serviceProvider.GetRequiredService<IBybitTrackerFactory>(),
                () => serviceProvider.GetRequiredService<ICoinbaseTrackerFactory>(), () => serviceProvider.GetRequiredService<ICoinExTrackerFactory>(),
                () => serviceProvider.GetRequiredService<ICoinWTrackerFactory>(), () => serviceProvider.GetRequiredService<ICryptoComTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IDeepCoinTrackerFactory>(), () => serviceProvider.GetRequiredService<IGateIoTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IHTXTrackerFactory>(), () => serviceProvider.GetRequiredService<IHyperLiquidTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IKrakenTrackerFactory>(), () => serviceProvider.GetRequiredService<IKucoinTrackerFactory>(),
                () => serviceProvider.GetRequiredService<ILBankTrackerFactory>(), () => serviceProvider.GetRequiredService<ILighterTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IMexcTrackerFactory>(), () => serviceProvider.GetRequiredService<IOKXTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IPionexTrackerFactory>(), () => serviceProvider.GetRequiredService<ITapbitTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IToobitTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IUpbitTrackerFactory>(), () => serviceProvider.GetRequiredService<IWeexTrackerFactory>(),
                () => serviceProvider.GetRequiredService<IWhiteBitTrackerFactory>(), () => serviceProvider.GetRequiredService<IXTTrackerFactory>());
        }

        /// <inheritdoc />
        public bool CanCreateKlineTracker(string exchange, SharedSymbol symbol, SharedKlineInterval interval)
        {
            var factory = GetTrackerFactoryForExchange(exchange);
            if (factory == null)
                return false;
            
            return factory.CanCreateKlineTracker(symbol, interval);
        }

        /// <inheritdoc />
        public IKlineTracker? CreateKlineTracker(string exchange, SharedSymbol symbol, SharedKlineInterval interval, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null)
        {
            var factory = GetTrackerFactoryForExchange(exchange);
            if (factory == null)
                return null;

            if (!factory.CanCreateKlineTracker(symbol, interval))
                return null;

            return factory.CreateKlineTracker(symbol, interval, limit, period, exchangeParameters);
        }

        /// <inheritdoc />
        public bool CanCreateTradeTracker(string exchange, SharedSymbol symbol)
        {
            var factory = GetTrackerFactoryForExchange(exchange);
            if (factory == null)
                return false;

            return factory.CanCreateTradeTracker(symbol);
        }

        /// <inheritdoc />
        public ITradeTracker? CreateTradeTracker(string exchange, SharedSymbol symbol, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null)
        {
            var factory = GetTrackerFactoryForExchange(exchange);
            if (factory == null)
                return null;

            if (!factory.CanCreateTradeTracker(symbol))
                return null;

            return factory.CreateTradeTracker(symbol, limit, period, exchangeParameters);
        }

        /// <inheritdoc />
        public IUserSpotDataTracker? CreateUserSpotDataTracker(string exchange, SpotUserDataTrackerConfig? config = null)
        {
            if (!IsEnabled(exchange))
                return null;

            return exchange switch
            {
                "Aster" => Aster.CreateUserSpotDataTracker(config),
                "Binance" => Binance.CreateUserSpotDataTracker(config),
                "BingX" => BingX.CreateUserSpotDataTracker(config),
                "Bitfinex" => Bitfinex.CreateUserSpotDataTracker(config),
                "Bitget" => Bitget.CreateUserSpotDataTracker(config),
                "BitMart" => BitMart.CreateUserSpotDataTracker(config),
                "BitMEX" => BitMEX.CreateUserSpotDataTracker(config),
                "Bitstamp" => Bitstamp.CreateUserSpotDataTracker(config),
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
                "LBank" => LBank.CreateUserSpotDataTracker(config),
                "Lighter" => Lighter.CreateUserSpotDataTracker(config),
                "Mexc" => Mexc.CreateUserSpotDataTracker(config),
                "OKX" => OKX.CreateUserSpotDataTracker(config),
                "Tapbit" => Tapbit.CreateUserSpotDataTracker(config),
                "Toobit" => Toobit.CreateUserSpotDataTracker(config),
                "Weex" => Weex.CreateUserSpotDataTracker(config),
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
        public IUserSpotDataTracker? CreateUserSpotDataTracker(string exchange, string userIdentifier, ExchangeCredentials credentials, SpotUserDataTrackerConfig? config = null, string? environment = null)
        {
            if (!IsEnabled(exchange))
                return null;

            return exchange switch
            {
                "Aster" => Aster.CreateUserSpotDataTracker(userIdentifier, credentials.Aster ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, AsterEnvironment.GetEnvironmentByName(environment)),
                "Binance" => Binance.CreateUserSpotDataTracker(userIdentifier, credentials.Binance ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BinanceEnvironment.GetEnvironmentByName(environment)),
                "BingX" => BingX.CreateUserSpotDataTracker(userIdentifier, credentials.BingX ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BingXEnvironment.GetEnvironmentByName(environment)),
                "Bitfinex" => Bitfinex.CreateUserSpotDataTracker(userIdentifier, credentials.Bitfinex ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BitfinexEnvironment.GetEnvironmentByName(environment)),
                "Bitget" => Bitget.CreateUserSpotDataTracker(userIdentifier, credentials.Bitget ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BitgetEnvironment.GetEnvironmentByName(environment)),
                "BitMart" => BitMart.CreateUserSpotDataTracker(userIdentifier, credentials.BitMart ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BitMartEnvironment.GetEnvironmentByName(environment)),
                "BitMEX" => BitMEX.CreateUserSpotDataTracker(userIdentifier, credentials.BitMEX ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BitMEXEnvironment.GetEnvironmentByName(environment)),
                "Bitstamp" => Bitstamp.CreateUserSpotDataTracker(userIdentifier, credentials.Bitstamp ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BitstampEnvironment.GetEnvironmentByName(environment)),
                "Bybit" => Bybit.CreateUserSpotDataTracker(userIdentifier, credentials.Bybit ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BybitEnvironment.GetEnvironmentByName(environment)),
                "Coinbase" => Coinbase.CreateUserSpotDataTracker(userIdentifier, credentials.Coinbase ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, CoinbaseEnvironment.GetEnvironmentByName(environment)),
                "CoinEx" => CoinEx.CreateUserSpotDataTracker(userIdentifier, credentials.CoinEx ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, CoinExEnvironment.GetEnvironmentByName(environment)),
                "CoinW" => CoinW.CreateUserSpotDataTracker(userIdentifier, credentials.CoinW ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, CoinWEnvironment.GetEnvironmentByName(environment)),
                "CryptoCom" => CryptoCom.CreateUserSpotDataTracker(userIdentifier, credentials.CryptoCom ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, CryptoComEnvironment.GetEnvironmentByName(environment)),
                "DeepCoin" => DeepCoin.CreateUserSpotDataTracker(userIdentifier, credentials.DeepCoin ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, DeepCoinEnvironment.GetEnvironmentByName(environment)),
                "GateIo" => GateIo.CreateUserSpotDataTracker(userIdentifier, credentials.GateIo ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, GateIoEnvironment.GetEnvironmentByName(environment)),
                "HTX" => HTX.CreateUserSpotDataTracker(userIdentifier, credentials.HTX ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, HTXEnvironment.GetEnvironmentByName(environment)),
                "HyperLiquid" => HyperLiquid.CreateUserSpotDataTracker(userIdentifier, credentials.HyperLiquid ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, HyperLiquidEnvironment.GetEnvironmentByName(environment)),
                "Kraken" => Kraken.CreateUserSpotDataTracker(userIdentifier, credentials.Kraken ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, KrakenEnvironment.GetEnvironmentByName(environment)),
                "Kucoin" => Kucoin.CreateUserSpotDataTracker(userIdentifier, credentials.Kucoin ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, KucoinEnvironment.GetEnvironmentByName(environment)),
                "LBank" => LBank.CreateUserSpotDataTracker(userIdentifier, credentials.LBank ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, LBankEnvironment.GetEnvironmentByName(environment)),
                "Lighter" => Lighter.CreateUserSpotDataTracker(userIdentifier, credentials.Lighter ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, LighterEnvironment.GetEnvironmentByName(environment)),
                "Mexc" => Mexc.CreateUserSpotDataTracker(userIdentifier, credentials.Mexc ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, MexcEnvironment.GetEnvironmentByName(environment)),
                "OKX" => OKX.CreateUserSpotDataTracker(userIdentifier, credentials.OKX ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, OKXEnvironment.GetEnvironmentByName(environment)),
                "Tapbit" => Tapbit.CreateUserSpotDataTracker(userIdentifier, credentials.Tapbit ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, TapbitEnvironment.GetEnvironmentByName(environment)),
                "Toobit" => Toobit.CreateUserSpotDataTracker(userIdentifier, credentials.Toobit ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, ToobitEnvironment.GetEnvironmentByName(environment)),
                "Weex" => Weex.CreateUserSpotDataTracker(userIdentifier, credentials.Weex ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, WeexEnvironment.GetEnvironmentByName(environment)),
                "WhiteBit" => WhiteBit.CreateUserSpotDataTracker(userIdentifier, credentials.WhiteBit ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, WhiteBitEnvironment.GetEnvironmentByName(environment)),
                "XT" => XT.CreateUserSpotDataTracker(userIdentifier, credentials.XT ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, XTEnvironment.GetEnvironmentByName(environment)),
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
                    credentials,
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
            if (!IsEnabled(exchange))
                return null;

            return exchange switch
            {
                "Aster" => Aster.CreateUserFuturesDataTracker(config),
                "Binance" => tradeMode.IsLinear() ? Binance.CreateUserUsdFuturesDataTracker(config) : Binance.CreateUserCoinFuturesDataTracker(config),
                "BingX" => BingX.BingXUserPerpetualFuturesDataTracker(config),
                "Bitget" => Bitget.CreateUserFuturesDataTracker(
                    ExchangeParameters.GetValue<string?>(exchangeParameters, "Bitget", "ProductType") == "UsdtFutures" ? BitgetProductTypeV2.UsdtFutures : BitgetProductTypeV2.UsdcFutures,
                    ExchangeParameters.GetValue<string?>(exchangeParameters, "Bitget", "MarginAsset") ?? "usdt",
                    config),
                "BitMart" => BitMart.CreateUserUsdFuturesDataTracker(config),
                "BitMEX" => BitMEX.CreateUserFuturesDataTracker(config),
                "Bitstamp" => Bitstamp.CreateUserFuturesDataTracker(config),
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
                "Lighter" => Lighter.CreateUserFuturesDataTracker(config),
                "OKX" => OKX.CreateUserFuturesDataTracker(config),
                "Toobit" => Toobit.CreateUserUsdtFuturesDataTracker(config),
                "Weex" => Weex.CreateUserFuturesDataTracker(config),
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
        public IUserFuturesDataTracker? CreateUserFuturesDataTracker(string exchange, TradingMode tradeMode, string userIdentifier, ExchangeCredentials credentials, FuturesUserDataTrackerConfig? config = null, string? environment = null, ExchangeParameters? exchangeParameters = null)
        {
            if (!IsEnabled(exchange))
                return null;

            return exchange switch
            {
                "Aster" => Aster.CreateUserFuturesDataTracker(userIdentifier, credentials.Aster ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, AsterEnvironment.GetEnvironmentByName(environment)),
                "Binance" => tradeMode.IsLinear() 
                                ? Binance.CreateUserUsdFuturesDataTracker(userIdentifier, credentials.Binance ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BinanceEnvironment.GetEnvironmentByName(environment)) 
                                : Binance.CreateUserCoinFuturesDataTracker(userIdentifier, credentials.Binance ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BinanceEnvironment.GetEnvironmentByName(environment)),
                "BingX" => BingX.BingXUserPerpetualFuturesDataTracker(userIdentifier, credentials.BingX ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BingXEnvironment.GetEnvironmentByName(environment)),
                "Bitget" => Bitget.CreateUserFuturesDataTracker(
                    userIdentifier,
                    credentials.Bitget ?? throw new ArgumentNullException($"No credentials provided for {exchange}"),
                    ExchangeParameters.GetValue<string?>(exchangeParameters, "Bitget", "ProductType") == "UsdtFutures" ? BitgetProductTypeV2.UsdtFutures : BitgetProductTypeV2.UsdcFutures,
                    ExchangeParameters.GetValue<string?>(exchangeParameters, "Bitget", "MarginAsset") ?? "usdt",
                    config,
                    BitgetEnvironment.GetEnvironmentByName(environment)),
                "BitMart" => BitMart.CreateUserUsdFuturesDataTracker(userIdentifier, credentials.BitMart ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BitMartEnvironment.GetEnvironmentByName(environment)),
                "BitMEX" => BitMEX.CreateUserFuturesDataTracker(userIdentifier, credentials.BitMEX ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BitMEXEnvironment.GetEnvironmentByName(environment)),
                "Bitstamp" => Bitstamp.CreateUserFuturesDataTracker(userIdentifier, credentials.Bitstamp ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BitstampEnvironment.GetEnvironmentByName(environment)),
                "BloFin" => BloFin.CreateUserFuturesDataTracker(userIdentifier, credentials.BloFin ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BloFinEnvironment.GetEnvironmentByName(environment)),
                "Bybit" => Bybit.CreateUserFuturesDataTracker(userIdentifier, credentials.Bybit ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, BybitEnvironment.GetEnvironmentByName(environment)),
                "Coinbase" => Coinbase.CreateUserFuturesDataTracker(userIdentifier, credentials.Coinbase ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, CoinbaseEnvironment.GetEnvironmentByName(environment)),
                "CoinEx" => CoinEx.CreateUserFuturesDataTracker(userIdentifier, credentials.CoinEx ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, CoinExEnvironment.GetEnvironmentByName(environment)),
                "CoinW" => CoinW.CreateUserFuturesDataTracker(userIdentifier, credentials.CoinW ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, CoinWEnvironment.GetEnvironmentByName(environment)),
                "CryptoCom" => CryptoCom.CreateUserFuturesDataTracker(userIdentifier, credentials.CryptoCom ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, CryptoComEnvironment.GetEnvironmentByName(environment)),
                "DeepCoin" => DeepCoin.CreateUserFuturesDataTracker(userIdentifier, credentials.DeepCoin ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, DeepCoinEnvironment.GetEnvironmentByName(environment)),
                "GateIo" => GateIo.CreateUserPerpetualFuturesDataTracker(
                    userIdentifier, 
                    credentials.GateIo ?? throw new ArgumentNullException($"No credentials provided for {exchange}"),
                    ExchangeParameters.GetValue<string>(exchangeParameters, "GateIo", "SettleAsset") ?? throw new ArgumentException("SettleAsset exchange parameter should be provided for GateIo", "SettleAsset"),
                    ExchangeParameters.GetValue<long?>(exchangeParameters, "GateIo", "UserId") ?? throw new ArgumentException("UserId exchange parameter should be provided for GateIo", "UserId"),
                    config,
                    GateIoEnvironment.GetEnvironmentByName(environment)),
                "HTX" => HTX.CreateUserFuturesDataTracker(
                    userIdentifier,
                    credentials.HTX ?? throw new ArgumentNullException($"No credentials provided for {exchange}"),
                    ExchangeParameters.GetValue<SharedMarginMode?>(exchangeParameters, "HTX", "MarginMode") == SharedMarginMode.Isolated ? SharedMarginMode.Isolated : SharedMarginMode.Cross,
                    config,
                    HTXEnvironment.GetEnvironmentByName(environment)),
                "HyperLiquid" => HyperLiquid.CreateUserFuturesDataTracker(userIdentifier, credentials.HyperLiquid ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, HyperLiquidEnvironment.GetEnvironmentByName(environment)),
                "Kraken" => Kraken.CreateUserFuturesDataTracker(userIdentifier, credentials.Kraken ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, KrakenEnvironment.GetEnvironmentByName(environment)),
                "Kucoin" => Kucoin.CreateUserFuturesDataTracker(userIdentifier, credentials.Kucoin ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, KucoinEnvironment.GetEnvironmentByName(environment)),
                "Lighter" => Lighter.CreateUserFuturesDataTracker(userIdentifier, credentials.Lighter ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, LighterEnvironment.GetEnvironmentByName(environment)),
                "OKX" => OKX.CreateUserFuturesDataTracker(userIdentifier, credentials.OKX ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, OKXEnvironment.GetEnvironmentByName(environment)),
                "Toobit" => Toobit.CreateUserUsdtFuturesDataTracker(userIdentifier, credentials.Toobit ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, ToobitEnvironment.GetEnvironmentByName(environment)),
                "Weex" => Weex.CreateUserFuturesDataTracker(userIdentifier, credentials.Weex ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, WeexEnvironment.GetEnvironmentByName(environment)),
                "WhiteBit" => WhiteBit.CreateUserFuturesDataTracker(userIdentifier, credentials.WhiteBit ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, WhiteBitEnvironment.GetEnvironmentByName(environment)),
                "XT" => tradeMode.IsLinear() ? XT.CreateUserUsdtFuturesDataTracker(userIdentifier, credentials.XT ?? throw new ArgumentNullException($"No credentials provided for {exchange}"), config, XTEnvironment.GetEnvironmentByName(environment)) : null,
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
                    credentials,
                    config,
                    environments?.TryGetValue(exchange, out var env) == true ? env : null);
                if (tracker == null)
                    continue;

                result.Add(tracker);
            }

            return result.ToArray();
        }

        private void InitializeFactories(
            IEnumerable<string>? enabledExchanges,
            Func<IAsterTrackerFactory> aster, Func<IBinanceTrackerFactory> binance, Func<IBingXTrackerFactory> bingX, Func<IBitfinexTrackerFactory> bitfinex,
            Func<IBitgetTrackerFactory> bitget, Func<IBitMartTrackerFactory> bitMart, Func<IBitMEXTrackerFactory> bitMEX, Func<IBitstampTrackerFactory> bitstamp,
            Func<IBloFinTrackerFactory> bloFin, Func<IBybitTrackerFactory> bybit, Func<ICoinbaseTrackerFactory> coinbase, Func<ICoinExTrackerFactory> coinEx,
            Func<ICoinWTrackerFactory> coinW, Func<ICryptoComTrackerFactory> cryptoCom, Func<IDeepCoinTrackerFactory> deepCoin, Func<IGateIoTrackerFactory> gateIo,
            Func<IHTXTrackerFactory> htx, Func<IHyperLiquidTrackerFactory> hyperLiquid, Func<IKrakenTrackerFactory> kraken, Func<IKucoinTrackerFactory> kucoin,
            Func<ILBankTrackerFactory> lBank, Func<ILighterTrackerFactory> lighter, Func<IMexcTrackerFactory> mexc, Func<IOKXTrackerFactory> okx,
            Func<IPionexTrackerFactory> pionex, Func<ITapbitTrackerFactory> tapbit, Func<IToobitTrackerFactory> toobit, Func<IUpbitTrackerFactory> upbit,
            Func<IWeexTrackerFactory> weex, Func<IWhiteBitTrackerFactory> whiteBit, Func<IXTTrackerFactory> xt)
        {
            _enabledExchanges = enabledExchanges == null ? null : new HashSet<string>(enabledExchanges, StringComparer.OrdinalIgnoreCase);
            _aster = new Lazy<IAsterTrackerFactory>(aster, LazyThreadSafetyMode.ExecutionAndPublication);
            _binance = new Lazy<IBinanceTrackerFactory>(binance, LazyThreadSafetyMode.ExecutionAndPublication);
            _bingX = new Lazy<IBingXTrackerFactory>(bingX, LazyThreadSafetyMode.ExecutionAndPublication);
            _bitfinex = new Lazy<IBitfinexTrackerFactory>(bitfinex, LazyThreadSafetyMode.ExecutionAndPublication);
            _bitget = new Lazy<IBitgetTrackerFactory>(bitget, LazyThreadSafetyMode.ExecutionAndPublication);
            _bitMart = new Lazy<IBitMartTrackerFactory>(bitMart, LazyThreadSafetyMode.ExecutionAndPublication);
            _bitMEX = new Lazy<IBitMEXTrackerFactory>(bitMEX, LazyThreadSafetyMode.ExecutionAndPublication);
            _bitstamp = new Lazy<IBitstampTrackerFactory>(bitstamp, LazyThreadSafetyMode.ExecutionAndPublication);
            _bloFin = new Lazy<IBloFinTrackerFactory>(bloFin, LazyThreadSafetyMode.ExecutionAndPublication);
            _bybit = new Lazy<IBybitTrackerFactory>(bybit, LazyThreadSafetyMode.ExecutionAndPublication);
            _coinbase = new Lazy<ICoinbaseTrackerFactory>(coinbase, LazyThreadSafetyMode.ExecutionAndPublication);
            _coinEx = new Lazy<ICoinExTrackerFactory>(coinEx, LazyThreadSafetyMode.ExecutionAndPublication);
            _coinW = new Lazy<ICoinWTrackerFactory>(coinW, LazyThreadSafetyMode.ExecutionAndPublication);
            _cryptoCom = new Lazy<ICryptoComTrackerFactory>(cryptoCom, LazyThreadSafetyMode.ExecutionAndPublication);
            _deepCoin = new Lazy<IDeepCoinTrackerFactory>(deepCoin, LazyThreadSafetyMode.ExecutionAndPublication);
            _gateIo = new Lazy<IGateIoTrackerFactory>(gateIo, LazyThreadSafetyMode.ExecutionAndPublication);
            _htx = new Lazy<IHTXTrackerFactory>(htx, LazyThreadSafetyMode.ExecutionAndPublication);
            _hyperLiquid = new Lazy<IHyperLiquidTrackerFactory>(hyperLiquid, LazyThreadSafetyMode.ExecutionAndPublication);
            _kraken = new Lazy<IKrakenTrackerFactory>(kraken, LazyThreadSafetyMode.ExecutionAndPublication);
            _kucoin = new Lazy<IKucoinTrackerFactory>(kucoin, LazyThreadSafetyMode.ExecutionAndPublication);
            _lBank = new Lazy<ILBankTrackerFactory>(lBank, LazyThreadSafetyMode.ExecutionAndPublication);
            _lighter = new Lazy<ILighterTrackerFactory>(lighter, LazyThreadSafetyMode.ExecutionAndPublication);
            _mexc = new Lazy<IMexcTrackerFactory>(mexc, LazyThreadSafetyMode.ExecutionAndPublication);
            _okx = new Lazy<IOKXTrackerFactory>(okx, LazyThreadSafetyMode.ExecutionAndPublication);
            _pionex = new Lazy<IPionexTrackerFactory>(pionex, LazyThreadSafetyMode.ExecutionAndPublication);
            _toobit = new Lazy<IToobitTrackerFactory>(toobit, LazyThreadSafetyMode.ExecutionAndPublication);
            _tapbit = new Lazy<ITapbitTrackerFactory>(tapbit, LazyThreadSafetyMode.ExecutionAndPublication);
            _upbit = new Lazy<IUpbitTrackerFactory>(upbit, LazyThreadSafetyMode.ExecutionAndPublication);
            _weex = new Lazy<IWeexTrackerFactory>(weex, LazyThreadSafetyMode.ExecutionAndPublication);
            _whiteBit = new Lazy<IWhiteBitTrackerFactory>(whiteBit, LazyThreadSafetyMode.ExecutionAndPublication);
            _xt = new Lazy<IXTTrackerFactory>(xt, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        private ITrackerFactory? GetTrackerFactoryForExchange(string exchange)
        {
            if (!IsEnabled(exchange))
                return null;

            return exchange switch
            {
                "Aster" => Aster,
                "Binance" => Binance,
                "BingX" => BingX,
                "Bitfinex" => Bitfinex,
                "Bitget" => Bitget,
                "BitMart" => BitMart,
                "BitMEX" => BitMEX,
                "Bitstamp" => Bitstamp,
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
                "LBank" => LBank,
                "Lighter" => Lighter,
                "Mexc" => Mexc,
                "OKX" => OKX,
                "Pionex" => Pionex,
                "Tapbit" => Tapbit,
                "Toobit" => Toobit,
                "Upbit" => Upbit,
                "Weex" => Weex,
                "WhiteBit" => WhiteBit,
                "XT" => XT,
                _ => null
            };
        }

        private bool IsEnabled(string name) => _enabledExchanges == null || _enabledExchanges.Contains(name);

#pragma warning disable IL2091
        private T GetFactory<T>(string name, Lazy<T> factory)
        {
            if (!IsEnabled(name))
                throw new InvalidOperationException($"The {name} tracker factory is disabled. Add it to {nameof(GlobalExchangeOptions.EnabledExchanges)} before accessing it.");

            return factory.Value;
        }
#pragma warning restore IL2091

    }
}
