using CryptoClients.Net.Models;
using System;
using System.Collections.Generic;
using Aster.Net.Objects.Options;
using Binance.Net.Objects.Options;
using BingX.Net.Objects.Options;
using Bitfinex.Net.Objects.Options;
using Bitget.Net.Objects.Options;
using Bitstamp.Net.Objects.Options;
using BloFin.Net.Objects.Options;
using Bybit.Net.Objects.Options;
using Coinbase.Net.Objects.Options;
using CoinGecko.Net.Objects.Options;
using CoinW.Net.Objects.Options;
using CryptoCom.Net.Objects.Options;
using DeepCoin.Net.Objects.Options;
using GateIo.Net.Objects.Options;
using HTX.Net.Objects.Options;
using HyperLiquid.Net.Objects.Options;
using Kraken.Net.Objects.Options;
using Kucoin.Net.Objects.Options;
using LBank.Net.Objects.Options;
using Lighter.Net.Objects.Options;
using Mexc.Net.Objects.Options;
using OKX.Net.Objects.Options;
using Pionex.Net.Objects.Options;
using Polymarket.Net.Objects.Options;
using Tapbit.Net.Objects.Options;
using Toobit.Net.Objects.Options;
using Upbit.Net.Objects.Options;
using Weex.Net.Objects.Options;
using WhiteBit.Net.Objects.Options;
using XT.Net.Objects.Options;

namespace CryptoClients.Net
{
    /// <summary>
    /// Client configuration builder
    /// </summary>
    public class ClientConfigurationBuilder
    {
        private readonly List<Action<GlobalExchangeOptions>> _globalConfigurators = [];
        private readonly Dictionary<Type, List<Delegate>> _exchangeConfigurators = [];

        /// <summary>
        /// Configure global options
        /// </summary>
        /// <param name="configure"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ClientConfigurationBuilder ConfigureGlobal(Action<GlobalExchangeOptions> configure)
        {
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            _globalConfigurators.Add(configure);
            return this;
        }

        /// <summary>
        /// Configure Aster API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureAster(Action<AsterOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Binance API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureBinance(Action<BinanceOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure BingX API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureBingX(Action<BingXOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure BingX API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureBitfinex(Action<BitfinexOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Bitget API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureBitget(Action<BitgetOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Bitstamp API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureBitstamp(Action<BitstampOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure BloFin API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureBloFin(Action<BloFinOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Bybit API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureBybit(Action<BybitOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Coinbase API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureCoinbase(Action<CoinbaseOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure CoinGecko API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureCoinGecko(Action<CoinGeckoRestOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure CoinW API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureCoinW(Action<CoinWOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure CryptoCom API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureCryptoCom(Action<CryptoComOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure DeepCoin API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureDeepCoin(Action<DeepCoinOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure GateIo API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureGateIo(Action<GateIoOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure HTX API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureHTX(Action<HTXOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure HyperLiquid API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureHyperLiquid(Action<HyperLiquidOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Kraken API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureKraken(Action<KrakenOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Kucoin API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureKucoin(Action<KucoinOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure LBank API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureLBank(Action<LBankOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Lighter API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureLighter(Action<LighterOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Mexc API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureMexc(Action<MexcOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure OKX API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureOKX(Action<OKXOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Pionex API options
        /// </summary>
        public ClientConfigurationBuilder ConfigurePionex(Action<PionexOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Polymarket API options
        /// </summary>
        public ClientConfigurationBuilder ConfigurePolymarket(Action<PolymarketOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Tapbit API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureTapbit(Action<TapbitOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Toobit API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureToobit(Action<ToobitOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Upbit API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureUpbit(Action<UpbitOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure Weex API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureWeex(Action<WeexOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure WhiteBit API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureWhiteBit(Action<WhiteBitOptions> configure) => ConfigureCore(configure);
        /// <summary>
        /// Configure XT API options
        /// </summary>
        public ClientConfigurationBuilder ConfigureXT(Action<XTOptions> configure) => ConfigureCore(configure);

        private ClientConfigurationBuilder ConfigureCore<TOptions>(
            Action<TOptions> configure)
            where TOptions : class
        {
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            if (!_exchangeConfigurators.TryGetValue(typeof(TOptions), out var configurators))
            {
                configurators = [];
                _exchangeConfigurators.Add(
                    typeof(TOptions),
                    configurators);
            }

            configurators.Add(configure);
            return this;
        }

        internal ClientConfigurationState Build()
        {
            var globalOptions = new GlobalExchangeOptions();
            foreach (var configure in _globalConfigurators)
                configure(globalOptions);

            return new ClientConfigurationState(globalOptions, _exchangeConfigurators);
        }
    }

    internal sealed class ClientConfigurationState
    {
        public GlobalExchangeOptions GlobalOptions { get; }
        public Dictionary<Type, List<Delegate>> ExchangeConfigurators { get; }

        public ClientConfigurationState(
            GlobalExchangeOptions globalOptions,
            Dictionary<Type, List<Delegate>> exchangeConfigurators)
        {
            GlobalOptions = globalOptions;
            ExchangeConfigurators = exchangeConfigurators;
        }
    }
}
