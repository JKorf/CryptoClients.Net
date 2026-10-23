using Aster.Net.Clients;
using Aster.Net.Interfaces.Clients;
using Aster.Net.Objects.Options;
using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Options;
using BingX.Net.Clients;
using BingX.Net.Interfaces.Clients;
using BingX.Net.Objects.Options;
using Bitfinex.Net.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitfinex.Net.Objects.Options;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using Bitstamp.Net.Clients;
using Bitstamp.Net.Interfaces.Clients;
using Bitstamp.Net.Objects.Options;
using Bitunix.Net.Clients;
using Bitunix.Net.Interfaces.Clients;
using Bitunix.Net.Objects.Options;
using BloFin.Net.Clients;
using BloFin.Net.Interfaces.Clients;
using BloFin.Net.Objects.Options;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using Coinbase.Net.Clients;
using Coinbase.Net.Interfaces.Clients;
using Coinbase.Net.Objects.Options;
using CoinW.Net.Clients;
using CoinW.Net.Interfaces.Clients;
using CoinW.Net.Objects.Options;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.Models;
using CryptoCom.Net.Clients;
using CryptoCom.Net.Interfaces.Clients;
using CryptoCom.Net.Objects.Options;
using CryptoExchange.Net.SharedApis;
using DeepCoin.Net.Clients;
using DeepCoin.Net.Interfaces.Clients;
using DeepCoin.Net.Objects.Options;
using GateIo.Net.Clients;
using GateIo.Net.Interfaces.Clients;
using GateIo.Net.Objects.Options;
using HTX.Net.Clients;
using HTX.Net.Interfaces.Clients;
using HTX.Net.Objects.Options;
using HyperLiquid.Net.Clients;
using HyperLiquid.Net.Interfaces.Clients;
using HyperLiquid.Net.Objects.Options;
using Kraken.Net.Clients;
using Kraken.Net.Interfaces.Clients;
using Kraken.Net.Objects.Options;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects.Options;
using LBank.Net.Clients;
using LBank.Net.Interfaces.Clients;
using LBank.Net.Objects.Options;
using Lighter.Net.Clients;
using Lighter.Net.Interfaces.Clients;
using Lighter.Net.Objects.Options;
using Mexc.Net.Clients;
using Mexc.Net.Interfaces.Clients;
using Mexc.Net.Objects.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OKX.Net.Clients;
using OKX.Net.Interfaces.Clients;
using OKX.Net.Objects.Options;
using Pionex.Net.Clients;
using Pionex.Net.Interfaces.Clients;
using Pionex.Net.Objects.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tapbit.Net.Clients;
using Tapbit.Net.Interfaces.Clients;
using Tapbit.Net.Objects.Options;
using Toobit.Net.Clients;
using Toobit.Net.Interfaces.Clients;
using Toobit.Net.Objects.Options;
using Upbit.Net.Clients;
using Upbit.Net.Interfaces.Clients;
using Upbit.Net.Objects.Options;
using Weex.Net.Clients;
using Weex.Net.Interfaces.Clients;
using Weex.Net.Objects.Options;
using WhiteBit.Net.Clients;
using WhiteBit.Net.Interfaces.Clients;
using WhiteBit.Net.Objects.Options;
using XT.Net.Clients;
using XT.Net.Interfaces.Clients;
using XT.Net.Objects.Options;

namespace CryptoClients.Net.Clients
{
    /// <inheritdoc />
    public class ExchangeSharedApiClient : IExchangeSharedApiClient
    {
        private readonly IExchangeSharedRestClient _exchangeRestClient;
        private readonly IExchangeSharedSocketClient _exchangeSocketClient;
        private readonly Dictionary<string, Lazy<ISharedApiClientBase>> _clients;
        private readonly HashSet<string>? _enabledExchanges;

        /// <inheritdoc />
        public IExchangeSharedRestClient Rest => _exchangeRestClient;
        /// <inheritdoc />
        public IExchangeSharedSocketClient Socket => _exchangeSocketClient;

        /// <summary>
        /// Create a new client instance
        /// </summary>
        /// <param name="configuration">Client configuration</param>
        /// <param name="httpClient">Optional HttpClient instance</param>
        /// <param name="loggerFactory">Optional ILoggerFactory instance</param>
        public ExchangeSharedApiClient(
            CryptoClientsConfiguration? configuration = null,
            HttpClient? httpClient = null,
            ILoggerFactory? loggerFactory = null)
            : this(
                new ExchangeRestClient(configuration ?? new CryptoClientsConfiguration(), httpClient, loggerFactory),
                new ExchangeSocketClient(configuration ?? new CryptoClientsConfiguration(), loggerFactory),
                configuration ?? new CryptoClientsConfiguration())
        {
        }

        /// <summary>
        /// Create a new client instance
        /// </summary>
        /// <param name="exchangeRestClient">The exchange REST client</param>
        /// <param name="exchangeSocketClient">The exchange socket client</param>
        /// <param name="configuration">Configuration</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ExchangeSharedApiClient(
            IExchangeRestClient exchangeRestClient,
            IExchangeSocketClient exchangeSocketClient,
            CryptoClientsConfiguration configuration)
            : this(exchangeRestClient,
                exchangeSocketClient,
                configuration.GlobalOptions.EnabledExchanges,
                new ConfigurationOptionsProvider(configuration))
        {
        }

        internal ExchangeSharedApiClient(
            IExchangeRestClient exchangeRestClient,
            IExchangeSocketClient exchangeSocketClient,
            IEnumerable<string>? enabledExchanges,
            IServiceProvider serviceProvider)
            : this(exchangeRestClient,
                exchangeSocketClient,
                enabledExchanges,
                new ServiceProviderOptionsProvider(serviceProvider))
        {
        }

        private ExchangeSharedApiClient(
            IExchangeRestClient exchangeRestClient,
            IExchangeSocketClient exchangeSocketClient,
            IEnumerable<string>? enabledExchanges,
            ISharedClientOptionsProvider optionsProvider)
        {
            if (optionsProvider == null)
                throw new ArgumentNullException(nameof(optionsProvider));

            _exchangeRestClient = exchangeRestClient;
            _exchangeSocketClient = exchangeSocketClient;

            _enabledExchanges = enabledExchanges == null ? null : new HashSet<string>(enabledExchanges, StringComparer.OrdinalIgnoreCase);

            _clients = new Dictionary<string, Lazy<ISharedApiClientBase>>(
                StringComparer.OrdinalIgnoreCase)
            {
                [Exchange.Aster] = Create(() =>
                    new AsterSharedApiClient(_exchangeRestClient.Aster, _exchangeSocketClient.Aster, optionsProvider.Get<AsterOptions>())),

                [Exchange.Binance] = Create(() =>
                    new BinanceSharedApiClient(_exchangeRestClient.Binance, _exchangeSocketClient.Binance, optionsProvider.Get<BinanceOptions>())),

                [Exchange.BingX] = Create(() =>
                    new BingXSharedApiClient(_exchangeRestClient.BingX, _exchangeSocketClient.BingX, optionsProvider.Get<BingXOptions>())),

                [Exchange.Bitfinex] = Create(() =>
                    new BitfinexSharedApiClient(_exchangeRestClient.Bitfinex, _exchangeSocketClient.Bitfinex, optionsProvider.Get<BitfinexOptions>())),

                [Exchange.Bitget] = Create(() =>
                    new BitgetSharedApiClient(_exchangeRestClient.Bitget, _exchangeSocketClient.Bitget, optionsProvider.Get<BitgetOptions>())),

                [Exchange.Bitstamp] = Create(() =>
                    new BitstampSharedApiClient(_exchangeRestClient.Bitstamp, _exchangeSocketClient.Bitstamp, optionsProvider.Get<BitstampOptions>())),

                [Exchange.Bitunix] = Create(() =>
                    new BitunixSharedApiClient(_exchangeRestClient.Bitunix, _exchangeSocketClient.Bitunix, optionsProvider.Get<BitunixOptions>())),

                [Exchange.BloFin] = Create(() =>
                    new BloFinSharedApiClient(_exchangeRestClient.BloFin, _exchangeSocketClient.BloFin, optionsProvider.Get<BloFinOptions>())),

                [Exchange.Bybit] = Create(() =>
                    new BybitSharedApiClient(_exchangeRestClient.Bybit, _exchangeSocketClient.Bybit, optionsProvider.Get<BybitOptions>())),

                [Exchange.Coinbase] = Create(() =>
                    new CoinbaseSharedApiClient(_exchangeRestClient.Coinbase, _exchangeSocketClient.Coinbase, optionsProvider.Get<CoinbaseOptions>())),

                [Exchange.CoinW] = Create(() =>
                    new CoinWSharedApiClient(_exchangeRestClient.CoinW, _exchangeSocketClient.CoinW, optionsProvider.Get<CoinWOptions>())),

                [Exchange.CryptoCom] = Create(() =>
                    new CryptoComSharedApiClient(_exchangeRestClient.CryptoCom, _exchangeSocketClient.CryptoCom, optionsProvider.Get<CryptoComOptions>())),

                [Exchange.DeepCoin] = Create(() =>
                    new DeepCoinSharedApiClient(_exchangeRestClient.DeepCoin, _exchangeSocketClient.DeepCoin, optionsProvider.Get<DeepCoinOptions>())),

                [Exchange.GateIo] = Create(() =>
                    new GateIoSharedApiClient(_exchangeRestClient.GateIo, _exchangeSocketClient.GateIo, optionsProvider.Get<GateIoOptions>())),

                [Exchange.HTX] = Create(() =>
                    new HTXSharedApiClient(_exchangeRestClient.HTX, _exchangeSocketClient.HTX, optionsProvider.Get<HTXOptions>())),

                [Exchange.HyperLiquid] = Create(() =>
                    new HyperLiquidSharedApiClient(_exchangeRestClient.HyperLiquid, _exchangeSocketClient.HyperLiquid, optionsProvider.Get<HyperLiquidOptions>())),

                [Exchange.Kraken] = Create(() =>
                    new KrakenSharedApiClient(_exchangeRestClient.Kraken, _exchangeSocketClient.Kraken, optionsProvider.Get<KrakenOptions>())),

                [Exchange.Kucoin] = Create(() =>
                    new KucoinSharedApiClient(_exchangeRestClient.Kucoin, _exchangeSocketClient.Kucoin, optionsProvider.Get<KucoinOptions>())),

                [Exchange.LBank] = Create(() =>
                    new LBankSharedApiClient(_exchangeRestClient.LBank, _exchangeSocketClient.LBank, optionsProvider.Get<LBankOptions>())),

                [Exchange.Lighter] = Create(() =>
                    new LighterSharedApiClient(_exchangeRestClient.Lighter, _exchangeSocketClient.Lighter, optionsProvider.Get<LighterOptions>())),

                [Exchange.Mexc] = Create(() =>
                    new MexcSharedApiClient(_exchangeRestClient.Mexc, _exchangeSocketClient.Mexc, optionsProvider.Get<MexcOptions>())),

                [Exchange.OKX] = Create(() =>
                    new OKXSharedApiClient(_exchangeRestClient.OKX, _exchangeSocketClient.OKX, optionsProvider.Get<OKXOptions>())),

                [Exchange.Pionex] = Create(() =>
                    new PionexSharedApiClient(_exchangeRestClient.Pionex, _exchangeSocketClient.Pionex, optionsProvider.Get<PionexOptions>())),

                [Exchange.Tapbit] = Create(() =>
                    new TapbitSharedApiClient(_exchangeRestClient.Tapbit, optionsProvider.Get<TapbitOptions>())),

                [Exchange.Toobit] = Create(() =>
                    new ToobitSharedApiClient(_exchangeRestClient.Toobit, _exchangeSocketClient.Toobit, optionsProvider.Get<ToobitOptions>())),

                [Exchange.Upbit] = Create(() =>
                    new UpbitSharedApiClient(_exchangeRestClient.Upbit, _exchangeSocketClient.Upbit, optionsProvider.Get<UpbitOptions>())),

                [Exchange.Weex] = Create(() =>
                    new WeexSharedApiClient(_exchangeRestClient.Weex, _exchangeSocketClient.Weex, optionsProvider.Get<WeexOptions>())),

                [Exchange.WhiteBit] = Create(() =>
                    new WhiteBitSharedApiClient(_exchangeRestClient.WhiteBit, _exchangeSocketClient.WhiteBit, optionsProvider.Get<WhiteBitOptions>())),

                [Exchange.XT] = Create(() =>
                    new XTSharedApiClient(_exchangeRestClient.XT, _exchangeSocketClient.XT, optionsProvider.Get<XTOptions>()))
            };

            Lazy<ISharedApiClientBase> Create(Func<ISharedApiClientBase> factory)
            {
                return new Lazy<ISharedApiClientBase>(
                    factory,
                    LazyThreadSafetyMode.ExecutionAndPublication);
            }
        }

        private interface ISharedClientOptionsProvider
        {
            IOptions<TOptions> Get<TOptions>()
                where TOptions : class, new();
        }

        private sealed class ConfigurationOptionsProvider(
            CryptoClientsConfiguration configuration)
            : ISharedClientOptionsProvider
        {
            public IOptions<TOptions> Get<TOptions>()
                where TOptions : class, new()
                => configuration.CreateOptions<TOptions>();
        }

        private sealed class ServiceProviderOptionsProvider(
            IServiceProvider serviceProvider)
            : ISharedClientOptionsProvider
        {
            public IOptions<TOptions> Get<TOptions>()
                where TOptions : class, new()
                => serviceProvider.GetRequiredService<IOptions<TOptions>>();
        }

        /// <inheritdoc />
        public ISharedApiClientBase? GetClient(string exchange)
        {
            if (!IsEnabled(exchange) || !_clients.TryGetValue(exchange, out var registration))            
                return null;

            return registration.Value;
        }

        /// <inheritdoc />
        public SharedCapabilityResolution<T>? GetCapability<T>(
            string exchange,
            SharedCapabilityReference<T> capability,
            TradingMode? tradingMode = null)
            where T : ISharedApiCapability
        {
            var client = GetClient(exchange);
            if (client == null)
                return null;

            return tradingMode == null
                ? client.GetCapability(capability)
                : client.GetCapability(capability, tradingMode.Value);
        }

        /// <inheritdoc />
        public SharedCapabilityResolution<T>? GetCapability<T>(
            string exchange,
            TradingMode? tradingMode = null)
            where T : ISharedApiCapability
        {
            var client = GetClient(exchange);
            if (client == null)
                return null;

            return tradingMode == null
                ? client.GetCapability<T>()
                : client.GetCapability<T>(tradingMode.Value);
        }

        /// <inheritdoc />
        public SharedCapabilityResolution<T>[] GetCapabilities<T>(
            SharedCapabilityReference<T> capability,
            TradingMode? tradingMode = null,
            IEnumerable<string>? exchanges = null)
            where T : ISharedApiCapability
        {
            return GetClients(exchanges)
                .Select(client => tradingMode == null
                    ? client.GetCapability(capability)
                    : client.GetCapability(capability, tradingMode.Value))
                .Where(result => result != null)
                .Cast<SharedCapabilityResolution<T>>()
                .ToArray();
        }

        /// <inheritdoc />
        public SharedCapabilityResolution<T>[] GetCapabilities<T>(
            TradingMode? tradingMode = null,
            SharedTransport? transport = null,
            IEnumerable<string>? exchanges = null)
            where T : ISharedApiCapability
        {
            return GetClients(exchanges)
                .Select(client => tradingMode == null
                    ? client.GetCapability<T>(transport)
                    : client.GetCapability<T>(tradingMode.Value, transport))
                .Where(result => result != null)
                .Cast<SharedCapabilityResolution<T>>()
                .ToArray();
        }

        /// <inheritdoc />
        public SharedCapabilityResolution<T>[] GetImplementations<T>(
            SharedCapabilityReference<T> capability,
            TradingMode? tradingMode = null,
            IEnumerable<string>? exchanges = null)
            where T : ISharedApiCapability
        {
            return GetClients(exchanges)
                .SelectMany(client =>
                    client.GetCapabilities(capability, tradingMode))
                .ToArray();
        }

        /// <inheritdoc />
        public SharedCapabilityResolution<T>[] GetImplementations<T>(
            TradingMode? tradingMode = null,
            SharedTransport? transport = null,
            IEnumerable<string>? exchanges = null)
            where T : ISharedApiCapability
        {
            return GetClients(exchanges)
                .SelectMany(client =>
                    client.GetCapabilities<T>(tradingMode, transport))
                .ToArray();
        }

        /// <inheritdoc />
        public IAsterSharedApiClient Aster =>
            GetRequiredClient<IAsterSharedApiClient>(Exchange.Aster);

        /// <inheritdoc />
        public IBinanceSharedApiClient Binance =>
            GetRequiredClient<IBinanceSharedApiClient>(Exchange.Binance);

        /// <inheritdoc />
        public IBingXSharedApiClient BingX =>
            GetRequiredClient<IBingXSharedApiClient>(Exchange.BingX);

        /// <inheritdoc />
        public IBitfinexSharedApiClient Bitfinex =>
            GetRequiredClient<IBitfinexSharedApiClient>(Exchange.Bitfinex);

        /// <inheritdoc />
        public IBitgetSharedApiClient Bitget =>
            GetRequiredClient<IBitgetSharedApiClient>(Exchange.Bitget);

        /// <inheritdoc />
        public IBitstampSharedApiClient Bitstamp =>
            GetRequiredClient<IBitstampSharedApiClient>(Exchange.Bitstamp);

        /// <inheritdoc />
        public IBitunixSharedApiClient Bitunix =>
            GetRequiredClient<IBitunixSharedApiClient>(Exchange.Bitunix);

        /// <inheritdoc />
        public IBloFinSharedApiClient BloFin =>
            GetRequiredClient<IBloFinSharedApiClient>(Exchange.BloFin);

        /// <inheritdoc />
        public IBybitSharedApiClient Bybit =>
            GetRequiredClient<IBybitSharedApiClient>(Exchange.Bybit);

        /// <inheritdoc />
        public ICoinbaseSharedApiClient Coinbase =>
            GetRequiredClient<ICoinbaseSharedApiClient>(Exchange.Coinbase);

        /// <inheritdoc />
        public ICoinWSharedApiClient CoinW =>
            GetRequiredClient<ICoinWSharedApiClient>(Exchange.CoinW);

        /// <inheritdoc />
        public ICryptoComSharedApiClient CryptoCom =>
            GetRequiredClient<ICryptoComSharedApiClient>(Exchange.CryptoCom);

        /// <inheritdoc />
        public IDeepCoinSharedApiClient DeepCoin =>
            GetRequiredClient<IDeepCoinSharedApiClient>(Exchange.DeepCoin);

        /// <inheritdoc />
        public IGateIoSharedApiClient GateIo =>
            GetRequiredClient<IGateIoSharedApiClient>(Exchange.GateIo);

        /// <inheritdoc />
        public IHTXSharedApiClient HTX =>
            GetRequiredClient<IHTXSharedApiClient>(Exchange.HTX);

        /// <inheritdoc />
        public IHyperLiquidSharedApiClient HyperLiquid =>
            GetRequiredClient<IHyperLiquidSharedApiClient>(Exchange.HyperLiquid);

        /// <inheritdoc />
        public IKrakenSharedApiClient Kraken =>
            GetRequiredClient<IKrakenSharedApiClient>(Exchange.Kraken);

        /// <inheritdoc />
        public IKucoinSharedApiClient Kucoin =>
            GetRequiredClient<IKucoinSharedApiClient>(Exchange.Kucoin);

        /// <inheritdoc />
        public ILBankSharedApiClient LBank =>
            GetRequiredClient<ILBankSharedApiClient>(Exchange.LBank);

        /// <inheritdoc />
        public ILighterSharedApiClient Lighter =>
            GetRequiredClient<ILighterSharedApiClient>(Exchange.Lighter);

        /// <inheritdoc />
        public IMexcSharedApiClient Mexc =>
            GetRequiredClient<IMexcSharedApiClient>(Exchange.Mexc);

        /// <inheritdoc />
        public IOKXSharedApiClient OKX =>
            GetRequiredClient<IOKXSharedApiClient>(Exchange.OKX);

        /// <inheritdoc />
        public IPionexSharedApiClient Pionex =>
            GetRequiredClient<IPionexSharedApiClient>(Exchange.Pionex);

        /// <inheritdoc />
        public ITapbitSharedApiClient Tapbit =>
            GetRequiredClient<ITapbitSharedApiClient>(Exchange.Tapbit);

        /// <inheritdoc />
        public IToobitSharedApiClient Toobit =>
            GetRequiredClient<IToobitSharedApiClient>(Exchange.Toobit);

        /// <inheritdoc />
        public IUpbitSharedApiClient Upbit =>
            GetRequiredClient<IUpbitSharedApiClient>(Exchange.Upbit);

        /// <inheritdoc />
        public IWeexSharedApiClient Weex =>
            GetRequiredClient<IWeexSharedApiClient>(Exchange.Weex);

        /// <inheritdoc />
        public IWhiteBitSharedApiClient WhiteBit =>
            GetRequiredClient<IWhiteBitSharedApiClient>(Exchange.WhiteBit);

        /// <inheritdoc />
        public IXTSharedApiClient XT =>
            GetRequiredClient<IXTSharedApiClient>(Exchange.XT);

        private T GetRequiredClient<T>(string exchange)
            where T : ISharedApiClientBase
        {
            if (!IsEnabled(exchange))
            {
                throw new InvalidOperationException($"The {exchange} client is disabled. Add it to " +
                    $"{nameof(GlobalExchangeOptions.EnabledExchanges)} before accessing it.");
            }

            if (!_clients.TryGetValue(exchange, out var registration))
                throw new InvalidOperationException($"No Shared API client is registered for {exchange}.");
            
            return (T)registration.Value;
        }

        private IEnumerable<ISharedApiClientBase> GetClients(IEnumerable<string>? exchanges)
        {
            if (exchanges == null)
                return _clients.Where(x => IsEnabled(x.Key)).Select(x => x.Value.Value);
            
            var requested = new HashSet<string>(exchanges, StringComparer.OrdinalIgnoreCase);
            return _clients
                .Where(x => IsEnabled(x.Key) && requested.Contains(x.Key))
                .Select(x => x.Value.Value);
        }

        private bool IsEnabled(string exchange)
            => _enabledExchanges == null || _enabledExchanges.Contains(exchange);


        /// <inheritdoc />
        public Task UnsubscribeAllAsync()
        {
            return _exchangeSocketClient.UnsubscribeAllAsync();
        }

    }
}
