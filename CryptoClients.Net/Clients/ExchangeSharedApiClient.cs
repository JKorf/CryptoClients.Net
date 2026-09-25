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
using BitMart.Net.Clients;
using BitMart.Net.Interfaces.Clients;
using BitMart.Net.Objects.Options;
using Bitstamp.Net.Clients;
using Bitstamp.Net.Interfaces.Clients;
using Bitstamp.Net.Objects.Options;
using BloFin.Net.Clients;
using BloFin.Net.Interfaces.Clients;
using BloFin.Net.Objects.Options;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using Coinbase.Net.Clients;
using Coinbase.Net.Interfaces.Clients;
using Coinbase.Net.Objects.Options;
using CoinEx.Net.Clients;
using CoinEx.Net.Interfaces.Clients;
using CoinEx.Net.Objects.Options;
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
        private readonly IExchangeSocketClient _exchangeSocketClient;
        private readonly Dictionary<string, Lazy<ISharedApiClientBase>> _clients;
        private readonly HashSet<string>? _enabledExchanges;

        /// <summary>
        /// Create a new client instance
        /// </summary>
        /// <param name="configuration">Client configuration</param>
        /// <param name="httpClient">Optional HttpClient instance</param>
        /// <param name="loggerFactory">Optional ILoggerFactory instance</param>
        public ExchangeSharedApiClient(
            CryptoClientsConfiguration? configuration,
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
        /// <param name="configuration">Client configuration</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ExchangeSharedApiClient(
            IExchangeRestClient? exchangeRestClient,
            IExchangeSocketClient? exchangeSocketClient,
            CryptoClientsConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            exchangeRestClient ??= new ExchangeRestClient(configuration);
            exchangeSocketClient ??= new ExchangeSocketClient(configuration);

            _exchangeSocketClient = exchangeSocketClient;

            _enabledExchanges = configuration.GlobalOptions.EnabledExchanges == null
                ? null
                : new HashSet<string>(
                    configuration.GlobalOptions.EnabledExchanges,
                    StringComparer.OrdinalIgnoreCase);

            _clients = new Dictionary<string, Lazy<ISharedApiClientBase>>(
                StringComparer.OrdinalIgnoreCase)
            {
                [Exchange.Aster] = Create(() =>
                    new AsterSharedApiClient(exchangeRestClient.Aster, exchangeSocketClient.Aster, GetOptions<AsterOptions>())),

                [Exchange.Binance] = Create(() =>
                    new BinanceSharedApiClient(exchangeRestClient.Binance, exchangeSocketClient.Binance, GetOptions<BinanceOptions>())),

                [Exchange.BingX] = Create(() =>
                    new BingXSharedApiClient(exchangeRestClient.BingX, exchangeSocketClient.BingX, GetOptions<BingXOptions>())),

                [Exchange.Bitfinex] = Create(() =>
                    new BitfinexSharedApiClient(exchangeRestClient.Bitfinex, exchangeSocketClient.Bitfinex, GetOptions<BitfinexOptions>())),

                [Exchange.Bitget] = Create(() =>
                    new BitgetSharedApiClient(exchangeRestClient.Bitget, exchangeSocketClient.Bitget, GetOptions<BitgetOptions>())),

                [Exchange.BitMart] = Create(() =>
                    new BitMartSharedApiClient(exchangeRestClient.BitMart, exchangeSocketClient.BitMart, GetOptions<BitMartOptions>())),

                [Exchange.Bitstamp] = Create(() =>
                    new BitstampSharedApiClient(exchangeRestClient.Bitstamp, exchangeSocketClient.Bitstamp, GetOptions<BitstampOptions>())),

                [Exchange.BloFin] = Create(() =>
                    new BloFinSharedApiClient(exchangeRestClient.BloFin, exchangeSocketClient.BloFin, GetOptions<BloFinOptions>())),

                [Exchange.Bybit] = Create(() =>
                    new BybitSharedApiClient(exchangeRestClient.Bybit, exchangeSocketClient.Bybit, GetOptions<BybitOptions>())),

                [Exchange.Coinbase] = Create(() =>
                    new CoinbaseSharedApiClient(exchangeRestClient.Coinbase, exchangeSocketClient.Coinbase, GetOptions<CoinbaseOptions>())),

                [Exchange.CoinEx] = Create(() =>
                    new CoinExSharedApiClient(exchangeRestClient.CoinEx, exchangeSocketClient.CoinEx, GetOptions<CoinExOptions>())),

                [Exchange.CoinW] = Create(() =>
                    new CoinWSharedApiClient(exchangeRestClient.CoinW, exchangeSocketClient.CoinW, GetOptions<CoinWOptions>())),

                [Exchange.CryptoCom] = Create(() =>
                    new CryptoComSharedApiClient(exchangeRestClient.CryptoCom, exchangeSocketClient.CryptoCom, GetOptions<CryptoComOptions>())),

                [Exchange.DeepCoin] = Create(() =>
                    new DeepCoinSharedApiClient(exchangeRestClient.DeepCoin, exchangeSocketClient.DeepCoin, GetOptions<DeepCoinOptions>())),

                [Exchange.GateIo] = Create(() =>
                    new GateIoSharedApiClient(exchangeRestClient.GateIo, exchangeSocketClient.GateIo, GetOptions<GateIoOptions>())),

                [Exchange.HTX] = Create(() =>
                    new HTXSharedApiClient(exchangeRestClient.HTX, exchangeSocketClient.HTX, GetOptions<HTXOptions>())),

                [Exchange.HyperLiquid] = Create(() =>
                    new HyperLiquidSharedApiClient(exchangeRestClient.HyperLiquid, exchangeSocketClient.HyperLiquid, GetOptions<HyperLiquidOptions>())),

                [Exchange.Kraken] = Create(() =>
                    new KrakenSharedApiClient(exchangeRestClient.Kraken, exchangeSocketClient.Kraken, GetOptions<KrakenOptions>())),

                [Exchange.Kucoin] = Create(() =>
                    new KucoinSharedApiClient(exchangeRestClient.Kucoin, exchangeSocketClient.Kucoin, GetOptions<KucoinOptions>())),

                [Exchange.LBank] = Create(() =>
                    new LBankSharedApiClient(exchangeRestClient.LBank, exchangeSocketClient.LBank, GetOptions<LBankOptions>())),

                [Exchange.Lighter] = Create(() =>
                    new LighterSharedApiClient(exchangeRestClient.Lighter, exchangeSocketClient.Lighter, GetOptions<LighterOptions>())),

                [Exchange.Mexc] = Create(() =>
                    new MexcSharedApiClient(exchangeRestClient.Mexc, exchangeSocketClient.Mexc, GetOptions<MexcOptions>())),

                [Exchange.OKX] = Create(() =>
                    new OKXSharedApiClient(exchangeRestClient.OKX, exchangeSocketClient.OKX, GetOptions<OKXOptions>())),

                [Exchange.Pionex] = Create(() =>
                    new PionexSharedApiClient(exchangeRestClient.Pionex, exchangeSocketClient.Pionex, GetOptions<PionexOptions>())),

                [Exchange.Tapbit] = Create(() =>
                    new TapbitSharedApiClient(exchangeRestClient.Tapbit, GetOptions<TapbitOptions>())),

                [Exchange.Toobit] = Create(() =>
                    new ToobitSharedApiClient(exchangeRestClient.Toobit, exchangeSocketClient.Toobit, GetOptions<ToobitOptions>())),

                [Exchange.Upbit] = Create(() =>
                    new UpbitSharedApiClient(exchangeRestClient.Upbit, exchangeSocketClient.Upbit, GetOptions<UpbitOptions>())),

                [Exchange.Weex] = Create(() =>
                    new WeexSharedApiClient(exchangeRestClient.Weex, exchangeSocketClient.Weex, GetOptions<WeexOptions>())),

                [Exchange.WhiteBit] = Create(() =>
                    new WhiteBitSharedApiClient(exchangeRestClient.WhiteBit, exchangeSocketClient.WhiteBit, GetOptions<WhiteBitOptions>())),

                [Exchange.XT] = Create(() =>
                    new XTSharedApiClient(exchangeRestClient.XT, exchangeSocketClient.XT, GetOptions<XTOptions>()))
            };

            Lazy<ISharedApiClientBase> Create(Func<ISharedApiClientBase> factory)
            {
                return new Lazy<ISharedApiClientBase>(
                    factory,
                    LazyThreadSafetyMode.ExecutionAndPublication);
            }

            IOptions<TOptions> GetOptions<TOptions>()
                where TOptions : class, new()
            {
                return configuration.CreateOptions<TOptions>();
            }
        }

        internal ExchangeSharedApiClient(
            IEnumerable<string>? enabledExchanges,
            IServiceProvider serviceProvider)
        {
            _enabledExchanges = enabledExchanges == null
                ? null
                : new HashSet<string>(
                    enabledExchanges,
                    StringComparer.OrdinalIgnoreCase);

            _exchangeSocketClient = serviceProvider.GetRequiredService<IExchangeSocketClient>();

            _clients = new Dictionary<string, Lazy<ISharedApiClientBase>>(StringComparer.OrdinalIgnoreCase)
            {
                [Exchange.Aster] = Create<IAsterSharedApiClient>(),
                [Exchange.Binance] = Create<IBinanceSharedApiClient>(),
                [Exchange.BingX] = Create<IBingXSharedApiClient>(),
                [Exchange.Bitfinex] = Create<IBitfinexSharedApiClient>(),
                [Exchange.Bitget] = Create<IBitgetSharedApiClient>(),
                [Exchange.BitMart] = Create<IBitMartSharedApiClient>(),
                [Exchange.Bitstamp] = Create<IBitstampSharedApiClient>(),
                [Exchange.BloFin] = Create<IBloFinSharedApiClient>(),
                [Exchange.Bybit] = Create<IBybitSharedApiClient>(),
                [Exchange.Coinbase] = Create<ICoinbaseSharedApiClient>(),
                [Exchange.CoinEx] = Create<ICoinExSharedApiClient>(),
                [Exchange.CoinW] = Create<ICoinWSharedApiClient>(),
                [Exchange.CryptoCom] = Create<ICryptoComSharedApiClient>(),
                [Exchange.DeepCoin] = Create<IDeepCoinSharedApiClient>(),
                [Exchange.GateIo] = Create<IGateIoSharedApiClient>(),
                [Exchange.HTX] = Create<IHTXSharedApiClient>(),
                [Exchange.HyperLiquid] = Create<IHyperLiquidSharedApiClient>(),
                [Exchange.Kraken] = Create<IKrakenSharedApiClient>(),
                [Exchange.Kucoin] = Create<IKucoinSharedApiClient>(),
                [Exchange.LBank] = Create<ILBankSharedApiClient>(),
                [Exchange.Lighter] = Create<ILighterSharedApiClient>(),
                [Exchange.Mexc] = Create<IMexcSharedApiClient>(),
                [Exchange.OKX] = Create<IOKXSharedApiClient>(),
                [Exchange.Pionex] = Create<IPionexSharedApiClient>(),
                [Exchange.Tapbit] = Create<ITapbitSharedApiClient>(),
                [Exchange.Toobit] = Create<IToobitSharedApiClient>(),
                [Exchange.Upbit] = Create<IUpbitSharedApiClient>(),
                [Exchange.Weex] = Create<IWeexSharedApiClient>(),
                [Exchange.WhiteBit] = Create<IWhiteBitSharedApiClient>(),
                [Exchange.XT] = Create<IXTSharedApiClient>()
            };

            Lazy<ISharedApiClientBase> Create<T>()
                where T : ISharedApiClientBase
            {
                return new Lazy<ISharedApiClientBase>(
                    () => serviceProvider.GetRequiredService<T>(),
                    LazyThreadSafetyMode.ExecutionAndPublication);
            }
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
        public IBitMartSharedApiClient BitMart =>
            GetRequiredClient<IBitMartSharedApiClient>(Exchange.BitMart);

        /// <inheritdoc />
        public IBitstampSharedApiClient Bitstamp =>
            GetRequiredClient<IBitstampSharedApiClient>(Exchange.Bitstamp);

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
        public ICoinExSharedApiClient CoinEx =>
            GetRequiredClient<ICoinExSharedApiClient>(Exchange.CoinEx);

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
        public async Task UnsubscribeAllAsync()
        {
#warning should be using ISharedSubscription for unsubscribing all
            await _exchangeSocketClient.UnsubscribeAllAsync().ConfigureAwait(false);
        }

    }
}
