using CryptoClients.Net.Models;
using Aster.Net;
using Aster.Net.Objects.Options;
using Binance.Net;
using Binance.Net.Objects.Options;
using BingX.Net;
using BingX.Net.Objects.Options;
using Bitfinex.Net;
using Bitfinex.Net.Objects.Options;
using Bitget.Net;
using Bitget.Net.Objects.Options;
using Bitstamp.Net;
using Bitstamp.Net.Objects.Options;
using BloFin.Net;
using BloFin.Net.Objects.Options;
using Bybit.Net;
using Bybit.Net.Objects.Options;
using Coinbase.Net;
using Coinbase.Net.Objects.Options;
using CoinGecko.Net;
using CoinGecko.Net.Objects.Options;
using CoinW.Net;
using CoinW.Net.Objects.Options;
using CryptoClients.Net.Enums;
using CryptoCom.Net;
using CryptoCom.Net.Objects.Options;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using DeepCoin.Net;
using DeepCoin.Net.Objects.Options;
using GateIo.Net;
using GateIo.Net.Objects.Options;
using HTX.Net;
using HTX.Net.Objects.Options;
using HyperLiquid.Net;
using HyperLiquid.Net.Objects.Options;
using Kraken.Net;
using Kraken.Net.Objects.Options;
using Kucoin.Net;
using Kucoin.Net.Objects.Options;
using LBank.Net;
using LBank.Net.Objects.Options;
using Lighter.Net;
using Lighter.Net.Objects.Options;
using Mexc.Net;
using Mexc.Net.Objects.Options;
using Microsoft.Extensions.Options;
using OKX.Net;
using OKX.Net.Objects.Options;
using Pionex.Net;
using Pionex.Net.Objects.Options;
using Polymarket.Net;
using Polymarket.Net.Objects.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tapbit.Net;
using Tapbit.Net.Objects.Options;
using Toobit.Net;
using Toobit.Net.Objects.Options;
using Upbit.Net;
using Upbit.Net.Objects.Options;
using Weex.Net;
using Weex.Net.Objects.Options;
using WhiteBit.Net;
using WhiteBit.Net.Objects.Options;
using XT.Net;
using XT.Net.Objects.Options;

namespace CryptoClients.Net
{
    /// <summary>
    /// Client configuration
    /// </summary>
    public class CryptoClientsConfiguration
    {
        private readonly IReadOnlyDictionary<Type, Delegate[]> _exchangeConfigurators;
        private readonly Dictionary<Type, Func<object>> _options = [];

        /// <summary>
        /// Global options for all API clients
        /// </summary>
        public GlobalExchangeOptions GlobalOptions { get; }

        internal CryptoClientsConfiguration(
            GlobalExchangeOptions globalOptions,
            Dictionary<Type, List<Delegate>> exchangeConfigurators)
        {
            GlobalOptions = globalOptions;

            _exchangeConfigurators = exchangeConfigurators.ToDictionary(
                x => x.Key,
                x => x.Value.ToArray());

            Register<AsterOptions, AsterRestOptions, AsterSocketOptions, AsterEnvironment>(AsterOptions.Create, Exchange.Aster, x => x.Rest, x => x.Socket, AsterEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Aster);
            Register<BinanceOptions, BinanceRestOptions, BinanceSocketOptions, BinanceEnvironment>(BinanceOptions.Create, Exchange.Binance, x => x.Rest, x => x.Socket, BinanceEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Binance);
            Register<BingXOptions, BingXRestOptions, BingXSocketOptions, BingXEnvironment>(BingXOptions.Create, Exchange.BingX, x => x.Rest, x => x.Socket, BingXEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.BingX);
            Register<BitfinexOptions, BitfinexRestOptions, BitfinexSocketOptions, BitfinexEnvironment>(BitfinexOptions.Create, Exchange.Bitfinex, x => x.Rest, x => x.Socket, BitfinexEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Bitfinex);
            Register<BitgetOptions, BitgetRestOptions, BitgetSocketOptions, BitgetEnvironment>(BitgetOptions.Create, Exchange.Bitget, x => x.Rest, x => x.Socket, BitgetEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Bitget);
            Register<BitstampOptions, BitstampRestOptions, BitstampSocketOptions, BitstampEnvironment>(BitstampOptions.Create, Exchange.Bitstamp, x => x.Rest, x => x.Socket, BitstampEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Bitstamp);
            Register<BloFinOptions, BloFinRestOptions, BloFinSocketOptions, BloFinEnvironment>(BloFinOptions.Create, Exchange.BloFin, x => x.Rest, x => x.Socket, BloFinEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.BloFin);
            Register<BybitOptions, BybitRestOptions, BybitSocketOptions, BybitEnvironment>(BybitOptions.Create, Exchange.Bybit, x => x.Rest, x => x.Socket, BybitEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Bybit);
            Register<CoinbaseOptions, CoinbaseRestOptions, CoinbaseSocketOptions, CoinbaseEnvironment>(CoinbaseOptions.Create, Exchange.Coinbase, x => x.Rest, x => x.Socket, CoinbaseEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Coinbase);
            Register<CoinWOptions, CoinWRestOptions, CoinWSocketOptions, CoinWEnvironment>(CoinWOptions.Create, Exchange.CoinW, x => x.Rest, x => x.Socket, CoinWEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.CoinW);
            Register<CryptoComOptions, CryptoComRestOptions, CryptoComSocketOptions, CryptoComEnvironment>(CryptoComOptions.Create, Exchange.CryptoCom, x => x.Rest, x => x.Socket, CryptoComEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.CryptoCom);
            Register<DeepCoinOptions, DeepCoinRestOptions, DeepCoinSocketOptions, DeepCoinEnvironment>(DeepCoinOptions.Create, Exchange.DeepCoin, x => x.Rest, x => x.Socket, DeepCoinEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.DeepCoin);
            Register<GateIoOptions, GateIoRestOptions, GateIoSocketOptions, GateIoEnvironment>(GateIoOptions.Create, Exchange.GateIo, x => x.Rest, x => x.Socket, GateIoEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.GateIo);
            Register<HTXOptions, HTXRestOptions, HTXSocketOptions, HTXEnvironment>(HTXOptions.Create, Exchange.HTX, x => x.Rest, x => x.Socket, HTXEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.HTX);
            Register<HyperLiquidOptions, HyperLiquidRestOptions, HyperLiquidSocketOptions, HyperLiquidEnvironment>(HyperLiquidOptions.Create, Exchange.HyperLiquid, x => x.Rest, x => x.Socket, HyperLiquidEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.HyperLiquid);
            Register<KrakenOptions, KrakenRestOptions, KrakenSocketOptions, KrakenEnvironment>(KrakenOptions.Create, Exchange.Kraken, x => x.Rest, x => x.Socket, KrakenEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Kraken);
            Register<KucoinOptions, KucoinRestOptions, KucoinSocketOptions, KucoinEnvironment>(KucoinOptions.Create, Exchange.Kucoin, x => x.Rest, x => x.Socket, KucoinEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Kucoin);
            Register<LBankOptions, LBankRestOptions, LBankSocketOptions, LBankEnvironment>(LBankOptions.Create, Exchange.LBank, x => x.Rest, x => x.Socket, LBankEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.LBank);
            Register<LighterOptions, LighterRestOptions, LighterSocketOptions, LighterEnvironment>(LighterOptions.Create, Exchange.Lighter, x => x.Rest, x => x.Socket, LighterEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Lighter);
            Register<MexcOptions, MexcRestOptions, MexcSocketOptions, MexcEnvironment>(MexcOptions.Create, Exchange.Mexc, x => x.Rest, x => x.Socket, MexcEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Mexc);
            Register<OKXOptions, OKXRestOptions, OKXSocketOptions, OKXEnvironment>(OKXOptions.Create, Exchange.OKX, x => x.Rest, x => x.Socket, OKXEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.OKX);
            Register<PionexOptions, PionexRestOptions, PionexSocketOptions, PionexEnvironment>(PionexOptions.Create, Exchange.Pionex, x => x.Rest, x => x.Socket, PionexEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Pionex);
            Register<PolymarketOptions, PolymarketRestOptions, PolymarketSocketOptions, PolymarketEnvironment>(PolymarketOptions.Create, Platform.Polymarket, x => x.Rest, x => x.Socket, PolymarketEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Polymarket);
            Register<TapbitOptions, TapbitRestOptions, TapbitSocketOptions, TapbitEnvironment>(TapbitOptions.Create, Exchange.Tapbit, x => x.Rest, x => x.Socket, TapbitEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Tapbit);
            Register<ToobitOptions, ToobitRestOptions, ToobitSocketOptions, ToobitEnvironment>(ToobitOptions.Create, Exchange.Toobit, x => x.Rest, x => x.Socket, ToobitEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Toobit);
            Register<UpbitOptions, UpbitRestOptions, UpbitSocketOptions, UpbitEnvironment>(UpbitOptions.Create, Exchange.Upbit, x => x.Rest, x => x.Socket, UpbitEnvironment.GetEnvironmentByName);
            Register<WeexOptions, WeexRestOptions, WeexSocketOptions, WeexEnvironment>(WeexOptions.Create, Exchange.Weex, x => x.Rest, x => x.Socket, WeexEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.Weex);
            Register<WhiteBitOptions, WhiteBitRestOptions, WhiteBitSocketOptions, WhiteBitEnvironment>(WhiteBitOptions.Create, Exchange.WhiteBit, x => x.Rest, x => x.Socket, WhiteBitEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.WhiteBit);
            Register<XTOptions, XTRestOptions, XTSocketOptions, XTEnvironment>(XTOptions.Create, Exchange.XT, x => x.Rest, x => x.Socket, XTEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.XT);
            RegisterRest<CoinGeckoRestOptions, CoinGeckoEnvironment>(CoinGeckoRestOptions.Create, Platform.CoinGecko, CoinGeckoEnvironment.GetEnvironmentByName, x => x.ApiCredentials = GlobalOptions.ApiCredentials?.CoinGecko);
        }

        /// <summary>
        /// Create a new CryptoClientsConfiguration instance
        /// </summary>
        public CryptoClientsConfiguration(Action<ClientConfigurationBuilder>? configure = null)
            : this(CreateState(configure))
        {
        }

        private CryptoClientsConfiguration(ClientConfigurationState state)
            : this(state.GlobalOptions, state.ExchangeConfigurators)
        {
        }

        private static ClientConfigurationState CreateState(Action<ClientConfigurationBuilder>? configure)
        {
            var builder = new ClientConfigurationBuilder();
            configure?.Invoke(builder);
            return builder.Build();
        }

        internal void Apply<TOptions>(TOptions options)
            where TOptions : class
        {
            if (!_exchangeConfigurators.TryGetValue(
                    typeof(TOptions),
                    out var configurators))
            {
                return;
            }

            foreach (var configurator in configurators)
                ((Action<TOptions>)configurator)(options);
        }

        internal IOptions<TOptions> CreateOptions<TOptions>()
            where TOptions : class, new()
        {
            if (!_options.TryGetValue(typeof(TOptions), out var factory))
                throw new InvalidOperationException($"No options registration exists for {typeof(TOptions).Name}");

            return Options.Create((TOptions)factory());
        }

        private void Register<TOptions, TRestOptions, TSocketOptions, TEnvironment>(
            Func<Action<TOptions>?, TOptions> factory,
            string exchange,
            Func<TOptions, TRestOptions> getRest,
            Func<TOptions, TSocketOptions> getSocket,
            Func<string, TEnvironment?> getEnvironment,
            Action<TOptions>? applyCredentials = null)
            where TOptions : LibraryOptions<TRestOptions, TSocketOptions, TEnvironment>, new()
            where TRestOptions : RestExchangeOptions<TEnvironment>, new()
            where TSocketOptions : SocketExchangeOptions<TEnvironment>, new()
            where TEnvironment : TradeEnvironment
        {
            var options = new Lazy<TOptions>(() => factory(x =>
            {
                ApplyGlobal<TRestOptions, TSocketOptions, TEnvironment>(x.Rest, x.Socket);
                ApplyEnvironment<TOptions, TRestOptions, TSocketOptions, TEnvironment>(x, exchange, getEnvironment);
                applyCredentials?.Invoke(x);
                Apply(x);
            }), LazyThreadSafetyMode.ExecutionAndPublication);

            _options.Add(typeof(TOptions), () => options.Value);
            _options.Add(typeof(TRestOptions), () => getRest(options.Value));
            _options.Add(typeof(TSocketOptions), () => getSocket(options.Value));
        }

        private void RegisterRest<TOptions, TEnvironment>(
            Func<Action<TOptions>?, TOptions> factory,
            string exchange,
            Func<string, TEnvironment?> getEnvironment,
            Action<TOptions>? applyCredentials = null)
            where TOptions : RestExchangeOptions<TEnvironment>, new()
            where TEnvironment : TradeEnvironment
        {
            var options = new Lazy<TOptions>(() => factory(x =>
            {
                ApplyRestGlobal<TOptions, TEnvironment>(x);
                ApplyEnvironment<TOptions, TEnvironment>(x, exchange, getEnvironment);
                applyCredentials?.Invoke(x);
                Apply(x);
            }), LazyThreadSafetyMode.ExecutionAndPublication);

            _options.Add(typeof(TOptions), () => options.Value);
        }

        private void ApplyGlobal<TRestOptions, TSocketOptions, TEnvironment>(
            TRestOptions restOptions,
            TSocketOptions socketOptions)
            where TRestOptions : RestExchangeOptions<TEnvironment>
            where TSocketOptions : SocketExchangeOptions<TEnvironment>
            where TEnvironment : TradeEnvironment
        {
            ApplyRestGlobal<TRestOptions, TEnvironment>(restOptions);
            ApplySocketGlobal<TSocketOptions, TEnvironment>(socketOptions);
        }

        private void ApplyRestGlobal<TRestOptions, TEnvironment>(TRestOptions restOptions)
            where TRestOptions : RestExchangeOptions<TEnvironment>
            where TEnvironment : TradeEnvironment
        {
            restOptions.Proxy = GlobalOptions.Proxy ?? restOptions.Proxy;
            restOptions.OutputOriginalData = GlobalOptions.OutputOriginalData ?? restOptions.OutputOriginalData;
            restOptions.RequestTimeout = GlobalOptions.RequestTimeout ?? restOptions.RequestTimeout;
            restOptions.RateLimiterEnabled = GlobalOptions.RateLimiterEnabled ?? restOptions.RateLimiterEnabled;
            restOptions.RateLimitingBehaviour = GlobalOptions.RateLimitingBehaviour ?? restOptions.RateLimitingBehaviour;
            restOptions.CachingEnabled = GlobalOptions.CachingEnabled ?? restOptions.CachingEnabled;
        }

        private void ApplySocketGlobal<TSocketOptions, TEnvironment>(TSocketOptions socketOptions)
            where TSocketOptions : SocketExchangeOptions<TEnvironment>
            where TEnvironment : TradeEnvironment
        {
            socketOptions.Proxy = GlobalOptions.Proxy ?? socketOptions.Proxy;
            socketOptions.OutputOriginalData = GlobalOptions.OutputOriginalData ?? socketOptions.OutputOriginalData;
            socketOptions.RequestTimeout = GlobalOptions.RequestTimeout ?? socketOptions.RequestTimeout;
            socketOptions.RateLimiterEnabled = GlobalOptions.RateLimiterEnabled ?? socketOptions.RateLimiterEnabled;
            socketOptions.RateLimitingBehaviour = GlobalOptions.RateLimitingBehaviour ?? socketOptions.RateLimitingBehaviour;
            socketOptions.ReconnectPolicy = GlobalOptions.ReconnectPolicy ?? socketOptions.ReconnectPolicy;
            socketOptions.ReconnectInterval = GlobalOptions.ReconnectInterval ?? socketOptions.ReconnectInterval;
        }

        private void ApplyEnvironment<TOptions, TRestOptions, TSocketOptions, TEnvironment>(
            TOptions options,
            string exchange,
            Func<string, TEnvironment?> getEnvironment)
            where TOptions : LibraryOptions<TRestOptions, TSocketOptions, TEnvironment>
            where TRestOptions : RestExchangeOptions<TEnvironment>, new()
            where TSocketOptions : SocketExchangeOptions<TEnvironment>, new()
            where TEnvironment : TradeEnvironment
        {
            if (GlobalOptions.ApiEnvironments?.TryGetValue(exchange, out var environmentName) != true
                || environmentName == null)
            {
                return;
            }

            var environment = getEnvironment(environmentName);
            if (environment != null)
                options.Environment = environment;
        }

        private void ApplyEnvironment<TOptions, TEnvironment>(
            TOptions options,
            string exchange,
            Func<string, TEnvironment?> getEnvironment)
            where TOptions : RestExchangeOptions<TEnvironment>
            where TEnvironment : TradeEnvironment
        {
            if (GlobalOptions.ApiEnvironments?.TryGetValue(exchange, out var environmentName) != true
                || environmentName == null)
            {
                return;
            }

            var environment = getEnvironment(environmentName);
            if (environment != null)
                options.Environment = environment;
        }
    }
}
