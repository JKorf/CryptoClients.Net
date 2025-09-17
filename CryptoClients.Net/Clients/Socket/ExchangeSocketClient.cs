using Binance.Net;
using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Options;
using BingX.Net;
using BingX.Net.Clients;
using BingX.Net.Interfaces.Clients;
using BingX.Net.Objects.Options;
using Bitfinex.Net;
using Bitfinex.Net.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitfinex.Net.Objects.Options;
using Bitget.Net;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using BitMart.Net;
using BitMart.Net.Clients;
using BitMart.Net.Interfaces.Clients;
using BitMart.Net.Objects.Options;
using BitMEX.Net;
using BitMEX.Net.Clients;
using BitMEX.Net.Interfaces.Clients;
using BitMEX.Net.Objects.Options;
using BloFin.Net;
using BloFin.Net.Clients;
using BloFin.Net.Interfaces.Clients;
using BloFin.Net.Objects.Options;
using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using Coinbase.Net;
using Coinbase.Net.Clients;
using Coinbase.Net.Interfaces.Clients;
using Coinbase.Net.Objects.Options;
using CoinEx.Net;
using CoinEx.Net.Clients;
using CoinEx.Net.Interfaces.Clients;
using CoinEx.Net.Objects.Options;
using CoinW.Net;
using CoinW.Net.Clients;
using CoinW.Net.Interfaces.Clients;
using CoinW.Net.Objects.Options;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.Models;
using CryptoCom.Net;
using CryptoCom.Net.Clients;
using CryptoCom.Net.Interfaces.Clients;
using CryptoCom.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using DeepCoin.Net;
using DeepCoin.Net.Clients;
using DeepCoin.Net.Interfaces.Clients;
using DeepCoin.Net.Objects.Options;
using GateIo.Net;
using GateIo.Net.Clients;
using GateIo.Net.Interfaces.Clients;
using GateIo.Net.Objects.Options;
using HTX.Net;
using HTX.Net.Clients;
using HTX.Net.Interfaces.Clients;
using HTX.Net.Objects.Options;
using HyperLiquid.Net;
using HyperLiquid.Net.Clients;
using HyperLiquid.Net.Interfaces.Clients;
using HyperLiquid.Net.Objects.Options;
using Kraken.Net;
using Kraken.Net.Clients;
using Kraken.Net.Interfaces.Clients;
using Kraken.Net.Objects.Options;
using Kucoin.Net;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects.Options;
using Mexc.Net;
using Mexc.Net.Clients;
using Mexc.Net.Interfaces.Clients;
using Mexc.Net.Objects.Options;
using OKX.Net;
using OKX.Net.Clients;
using OKX.Net.Interfaces.Clients;
using OKX.Net.Objects.Options;
using Toobit.Net;
using Toobit.Net.Clients;
using Toobit.Net.Interfaces.Clients;
using Toobit.Net.Objects.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WhiteBit.Net;
using WhiteBit.Net.Clients;
using WhiteBit.Net.Interfaces.Clients;
using WhiteBit.Net.Objects.Options;
using XT.Net;
using XT.Net.Clients;
using XT.Net.Interfaces.Clients;
using XT.Net.Objects.Options;
using CryptoExchange.Net.Interfaces;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public partial class ExchangeSocketClient : IExchangeSocketClient
    {
        private IEnumerable<ISharedClient> _sharedClients = Array.Empty<ISharedClient>();
        private ISocketClient[] _socketClients = [];

        /// <inheritdoc />
        public double IncomingKbps => _socketClients.Sum(x => x.IncomingKbps);
        /// <inheritdoc />
        public int CurrentConnections => _socketClients.Sum(x => x.CurrentConnections);
        /// <inheritdoc />
        public int CurrentSubscriptions => _socketClients.Sum(x => x.CurrentSubscriptions);

        /// <inheritdoc />
        public IBinanceSocketClient Binance { get; }
        /// <inheritdoc />
        public IBingXSocketClient BingX { get; }
        /// <inheritdoc />
        public IBitfinexSocketClient Bitfinex { get; }
        /// <inheritdoc />
        public IBitgetSocketClient Bitget { get; }
        /// <inheritdoc />
        public IBitMartSocketClient BitMart { get; }
        /// <inheritdoc />
        public IBitMEXSocketClient BitMEX { get; }
        /// <inheritdoc />
        public IBloFinSocketClient BloFin { get; }
        /// <inheritdoc />
        public IBybitSocketClient Bybit { get; }
        /// <inheritdoc />
        public ICoinbaseSocketClient Coinbase { get; }
        /// <inheritdoc />
        public ICoinExSocketClient CoinEx { get; }
        /// <inheritdoc />
        public ICoinWSocketClient CoinW { get; }
        /// <inheritdoc />
        public ICryptoComSocketClient CryptoCom { get; }
        /// <inheritdoc />
        public IDeepCoinSocketClient DeepCoin { get; }
        /// <inheritdoc />
        public IGateIoSocketClient GateIo { get; }
        /// <inheritdoc />
        public IHTXSocketClient HTX { get; }
        /// <inheritdoc />
        public IHyperLiquidSocketClient HyperLiquid { get; }
        /// <inheritdoc />
        public IKrakenSocketClient Kraken { get; }
        /// <inheritdoc />
        public IKucoinSocketClient Kucoin { get; }
        /// <inheritdoc />
        public IMexcSocketClient Mexc { get; }
        /// <inheritdoc />
        public IOKXSocketClient OKX { get; }
        /// <inheritdoc />
        public IToobitSocketClient Toobit { get; }
        /// <inheritdoc />
        public IWhiteBitSocketClient WhiteBit { get; }
        /// <inheritdoc />
        public IXTSocketClient XT { get; }

        /// <summary>
        /// Create a new ExchangeSocketClient instance. Client instances will be created with default options.
        /// </summary>
        public ExchangeSocketClient()
        {
            Binance = new BinanceSocketClient();
            BingX = new BingXSocketClient();
            Bitfinex = new BitfinexSocketClient();
            Bitget = new BitgetSocketClient();
            BitMart = new BitMartSocketClient();
            BitMEX = new BitMEXSocketClient();
            BloFin = new BloFinSocketClient();
            Bybit = new BybitSocketClient();
            Coinbase = new CoinbaseSocketClient();
            CoinEx = new CoinExSocketClient();
            CoinW = new CoinWSocketClient();
            CryptoCom = new CryptoComSocketClient();
            DeepCoin = new DeepCoinSocketClient();
            GateIo = new GateIoSocketClient();
            HTX = new HTXSocketClient();
            HyperLiquid = new HyperLiquidSocketClient();
            Kraken = new KrakenSocketClient();
            Kucoin = new KucoinSocketClient();
            Mexc = new MexcSocketClient();
            OKX = new OKXSocketClient();
            Toobit = new ToobitSocketClient();
            WhiteBit = new WhiteBitSocketClient();
            XT = new XTSocketClient();

            InitSharedClients();
        }

        /// <summary>
        /// Create a new ExchangeSocketClient instance
        /// </summary>
        public ExchangeSocketClient(
            Action<GlobalExchangeOptions>? globalOptions = null,
            Action<BinanceSocketOptions>? binanceSocketOptions = null,
            Action<BingXSocketOptions>? bingxSocketOptions = null,
            Action<BitfinexSocketOptions>? bitfinexSocketOptions = null,
            Action<BitgetSocketOptions>? bitgetSocketOptions = null,
            Action<BitMartSocketOptions>? bitMartSocketOptions = null,
            Action<BitMEXSocketOptions>? bitMEXSocketOptions = null,
            Action<BloFinSocketOptions>? bloFinSocketOptions = null,
            Action<BybitSocketOptions>? bybitSocketOptions = null,
            Action<CoinExSocketOptions>? coinExSocketOptions = null,
            Action<CoinWSocketOptions>? coinWSocketOptions = null,
            Action<CoinbaseSocketOptions>? coinbaseSocketOptions = null,
            Action<CryptoComSocketOptions>? cryptoComSocketOptions = null,
            Action<DeepCoinSocketOptions>? deepCoinSocketOptions = null,
            Action<GateIoSocketOptions>? gateIoSocketOptions = null,
            Action<HTXSocketOptions>? htxSocketOptions = null,
            Action<HyperLiquidSocketOptions>? hyperLiquidSocketOptions = null,
            Action<KrakenSocketOptions>? krakenSocketOptions = null,
            Action<KucoinSocketOptions>? kucoinSocketOptions = null,
            Action<MexcSocketOptions>? mexcSocketOptions = null,
            Action<OKXSocketOptions>? okxSocketOptions = null,
            Action<ToobitSocketOptions>? toobitSocketOptions = null,
            Action<WhiteBitSocketOptions>? whiteBitSocketOptions = null,
            Action<XTSocketOptions>? xtSocketOptions = null)
        {
            Action<TOptions> SetGlobalSocketOptions<TOptions, TCredentials, TEnvironment>(GlobalExchangeOptions globalOptions, Action<TOptions>? exchangeDelegate, TCredentials? credentials, TEnvironment environment)
                where TOptions : SocketExchangeOptions<TEnvironment>
                where TCredentials : ApiCredentials
                where TEnvironment : TradeEnvironment
            {
                var socketDelegate = (TOptions socketOptions) =>
                {
                    socketOptions.Proxy = globalOptions.Proxy;
                    socketOptions.ApiCredentials = credentials;
                    socketOptions.Environment = environment;
                    socketOptions.OutputOriginalData = globalOptions.OutputOriginalData ?? socketOptions.OutputOriginalData;
                    socketOptions.RequestTimeout = globalOptions.RequestTimeout ?? socketOptions.RequestTimeout;
                    socketOptions.RateLimiterEnabled = globalOptions.RateLimiterEnabled ?? socketOptions.RateLimiterEnabled;
                    socketOptions.RateLimitingBehaviour = globalOptions.RateLimitingBehaviour ?? socketOptions.RateLimitingBehaviour;
                    socketOptions.ReconnectPolicy = globalOptions.ReconnectPolicy ?? socketOptions.ReconnectPolicy;
                    socketOptions.ReconnectInterval = globalOptions.ReconnectInterval ?? socketOptions.ReconnectInterval;
                    exchangeDelegate?.Invoke(socketOptions);
                };

                return socketDelegate;
            }

            if (globalOptions != null)
            {
                var global = new GlobalExchangeOptions();
                globalOptions.Invoke(global);

                ExchangeCredentials? credentials = global.ApiCredentials;
                Dictionary<string, string?>? environments = global.ApiEnvironments;
                binanceSocketOptions = SetGlobalSocketOptions(global, binanceSocketOptions, credentials?.Binance, environments?.TryGetValue(Exchange.Binance, out var binanceEnvName) == true ? BinanceEnvironment.GetEnvironmentByName(binanceEnvName)! : BinanceEnvironment.Live);
                bingxSocketOptions = SetGlobalSocketOptions(global, bingxSocketOptions, credentials?.BingX, environments?.TryGetValue(Exchange.BingX, out var bingXEnvName) == true ? BingXEnvironment.GetEnvironmentByName(bingXEnvName)! : BingXEnvironment.Live);
                bitfinexSocketOptions = SetGlobalSocketOptions(global, bitfinexSocketOptions, credentials?.Bitfinex, environments?.TryGetValue(Exchange.Bitfinex, out var bitfinexEnvName) == true ? BitfinexEnvironment.GetEnvironmentByName(bitfinexEnvName)! : BitfinexEnvironment.Live);
                bitgetSocketOptions = SetGlobalSocketOptions(global, bitgetSocketOptions, credentials?.Bitget, environments?.TryGetValue(Exchange.Bitget, out var bitgetEnvName) == true ? BitgetEnvironment.GetEnvironmentByName(bitgetEnvName)! : BitgetEnvironment.Live);
                bitMartSocketOptions = SetGlobalSocketOptions(global, bitMartSocketOptions, credentials?.BitMart, environments?.TryGetValue(Exchange.BitMart, out var bitMartEnvName) == true ? BitMartEnvironment.GetEnvironmentByName(bitMartEnvName)! : BitMartEnvironment.Live);
                bitMEXSocketOptions = SetGlobalSocketOptions(global, bitMEXSocketOptions, credentials?.BitMEX, environments?.TryGetValue(Exchange.BitMEX, out var bitMEXEnvName) == true ? BitMEXEnvironment.GetEnvironmentByName(bitMEXEnvName)! : BitMEXEnvironment.Live);
                bloFinSocketOptions = SetGlobalSocketOptions(global, bloFinSocketOptions, credentials?.BloFin, environments?.TryGetValue(Exchange.BloFin, out var bloFinEnvName) == true ? BloFinEnvironment.GetEnvironmentByName(bloFinEnvName)! : BloFinEnvironment.Live);
                bybitSocketOptions = SetGlobalSocketOptions(global, bybitSocketOptions, credentials?.Bybit, environments?.TryGetValue(Exchange.Bybit, out var bybitEnvName) == true ? BybitEnvironment.GetEnvironmentByName(bybitEnvName)! : BybitEnvironment.Live);
                coinbaseSocketOptions = SetGlobalSocketOptions(global, coinbaseSocketOptions, credentials?.Coinbase, environments?.TryGetValue(Exchange.Coinbase, out var coinbaseEnvName) == true ? CoinbaseEnvironment.GetEnvironmentByName(coinbaseEnvName)! : CoinbaseEnvironment.Live);
                coinExSocketOptions = SetGlobalSocketOptions(global, coinExSocketOptions, credentials?.CoinEx, environments?.TryGetValue(Exchange.CoinEx, out var coinExEnvName) == true ? CoinExEnvironment.GetEnvironmentByName(coinExEnvName)! : CoinExEnvironment.Live);
                coinWSocketOptions = SetGlobalSocketOptions(global, coinWSocketOptions, credentials?.CoinW, environments?.TryGetValue(Exchange.CoinW, out var coinWEnvName) == true ? CoinWEnvironment.GetEnvironmentByName(coinWEnvName)! : CoinWEnvironment.Live);
                cryptoComSocketOptions = SetGlobalSocketOptions(global, cryptoComSocketOptions, credentials?.CryptoCom, environments?.TryGetValue(Exchange.CryptoCom, out var cryptoComEnvName) == true ? CryptoComEnvironment.GetEnvironmentByName(cryptoComEnvName)! : CryptoComEnvironment.Live);
                deepCoinSocketOptions = SetGlobalSocketOptions(global, deepCoinSocketOptions, credentials?.DeepCoin, environments?.TryGetValue(Exchange.DeepCoin, out var deepCoinEnvName) == true ? DeepCoinEnvironment.GetEnvironmentByName(deepCoinEnvName)! : DeepCoinEnvironment.Live);
                gateIoSocketOptions = SetGlobalSocketOptions(global, gateIoSocketOptions, credentials?.GateIo, environments?.TryGetValue(Exchange.GateIo, out var gateIoEnvName) == true ? GateIoEnvironment.GetEnvironmentByName(gateIoEnvName)! : GateIoEnvironment.Live);
                htxSocketOptions = SetGlobalSocketOptions(global, htxSocketOptions, credentials?.HTX, environments?.TryGetValue(Exchange.HTX, out var htxEnvName) == true ? HTXEnvironment.GetEnvironmentByName(htxEnvName)! : HTXEnvironment.Live);
                hyperLiquidSocketOptions = SetGlobalSocketOptions(global, hyperLiquidSocketOptions, credentials?.HyperLiquid, environments?.TryGetValue(Exchange.HyperLiquid, out var hyperLiquidEnvName) == true ? HyperLiquidEnvironment.GetEnvironmentByName(hyperLiquidEnvName)! : HyperLiquidEnvironment.Live);
                krakenSocketOptions = SetGlobalSocketOptions(global, krakenSocketOptions, credentials?.Kraken, environments?.TryGetValue(Exchange.Kraken, out var krakenEnvName) == true ? KrakenEnvironment.GetEnvironmentByName(krakenEnvName)! : KrakenEnvironment.Live);
                kucoinSocketOptions = SetGlobalSocketOptions(global, kucoinSocketOptions, credentials?.Kucoin, environments?.TryGetValue(Exchange.Kucoin, out var kucoinEnvName) == true ? KucoinEnvironment.GetEnvironmentByName(kucoinEnvName)! : KucoinEnvironment.Live);
                mexcSocketOptions = SetGlobalSocketOptions(global, mexcSocketOptions, credentials?.Mexc, environments?.TryGetValue(Exchange.Mexc, out var mexcEnvName) == true ? MexcEnvironment.GetEnvironmentByName(mexcEnvName)! : MexcEnvironment.Live);
                okxSocketOptions = SetGlobalSocketOptions(global, okxSocketOptions, credentials?.OKX, environments?.TryGetValue(Exchange.OKX, out var okxEnvName) == true ? OKXEnvironment.GetEnvironmentByName(okxEnvName)! : OKXEnvironment.Live);
                toobitSocketOptions = SetGlobalSocketOptions(global, toobitSocketOptions, credentials?.Toobit, environments?.TryGetValue(Exchange.Toobit, out var toobitEnvName) == true ? ToobitEnvironment.GetEnvironmentByName(toobitEnvName)! : ToobitEnvironment.Live);
                whiteBitSocketOptions = SetGlobalSocketOptions(global, whiteBitSocketOptions, credentials?.WhiteBit, environments?.TryGetValue(Exchange.WhiteBit, out var whiteBitEnvName) == true ? WhiteBitEnvironment.GetEnvironmentByName(whiteBitEnvName)! : WhiteBitEnvironment.Live);
                xtSocketOptions = SetGlobalSocketOptions(global, xtSocketOptions, credentials?.XT, environments?.TryGetValue(Exchange.XT, out var xtEnvName) == true ? XTEnvironment.GetEnvironmentByName(xtEnvName)! : XTEnvironment.Live);
            }

            Binance = new BinanceSocketClient(binanceSocketOptions ?? new Action<BinanceSocketOptions>((x) => { }));
            BingX = new BingXSocketClient(bingxSocketOptions ?? new Action<BingXSocketOptions>((x) => { }));
            Bitfinex = new BitfinexSocketClient(bitfinexSocketOptions ?? new Action<BitfinexSocketOptions>((x) => { }));
            Bitget = new BitgetSocketClient(bitgetSocketOptions ?? new Action<BitgetSocketOptions>((x) => { }));
            BitMart = new BitMartSocketClient(bitMartSocketOptions ?? new Action<BitMartSocketOptions>((x) => { }));
            BitMEX = new BitMEXSocketClient(bitMEXSocketOptions ?? new Action<BitMEXSocketOptions>((x) => { }));
            BloFin = new BloFinSocketClient(bloFinSocketOptions ?? new Action<BloFinSocketOptions>((x) => { }));
            Bybit = new BybitSocketClient(bybitSocketOptions ?? new Action<BybitSocketOptions>((x) => { }));
            Coinbase = new CoinbaseSocketClient(coinbaseSocketOptions ?? new Action<CoinbaseSocketOptions>((x) => { }));
            CoinEx = new CoinExSocketClient(coinExSocketOptions ?? new Action<CoinExSocketOptions>((x) => { }));
            CoinW = new CoinWSocketClient(coinWSocketOptions ?? new Action<CoinWSocketOptions>((x) => { }));
            HTX = new HTXSocketClient(htxSocketOptions ?? new Action<HTXSocketOptions>((x) => { }));
            HyperLiquid = new HyperLiquidSocketClient(hyperLiquidSocketOptions ?? new Action<HyperLiquidSocketOptions>((x) => { }));
            CryptoCom = new CryptoComSocketClient(cryptoComSocketOptions ?? new Action<CryptoComSocketOptions>((x) => { }));
            DeepCoin = new DeepCoinSocketClient(deepCoinSocketOptions ?? new Action<DeepCoinSocketOptions>((x) => { }));
            GateIo = new GateIoSocketClient(gateIoSocketOptions ?? new Action<GateIoSocketOptions>((x) => { }));
            Kraken = new KrakenSocketClient(krakenSocketOptions ?? new Action<KrakenSocketOptions>((x) => { }));
            Kucoin = new KucoinSocketClient(kucoinSocketOptions ?? new Action<KucoinSocketOptions>((x) => { }));
            Mexc = new MexcSocketClient(mexcSocketOptions ?? new Action<MexcSocketOptions>((x) => { }));
            OKX = new OKXSocketClient(okxSocketOptions ?? new Action<OKXSocketOptions>((x) => { }));
            Toobit = new ToobitSocketClient(toobitSocketOptions ?? new Action<ToobitSocketOptions>((x) => { }));
            WhiteBit = new WhiteBitSocketClient(whiteBitSocketOptions ?? new Action<WhiteBitSocketOptions>((x) => { }));
            XT = new XTSocketClient(xtSocketOptions ?? new Action<XTSocketOptions>((x) => { }));

            InitSharedClients();
        }

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeSocketClient(
            IBinanceSocketClient binance,
            IBingXSocketClient bingx,
            IBitfinexSocketClient bitfinex,
            IBitgetSocketClient bitget,
            IBitMartSocketClient bitMart,
            IBitMEXSocketClient bitMEX,
            IBloFinSocketClient bloFin,
            IBybitSocketClient bybit,
            ICoinbaseSocketClient coinbase,
            ICoinExSocketClient coinEx,
            ICoinWSocketClient coinW,
            ICryptoComSocketClient cryptoCom,
            IDeepCoinSocketClient deepCoin,
            IGateIoSocketClient gateIo,
            IHTXSocketClient htx,
            IHyperLiquidSocketClient hyperLiquid,
            IKrakenSocketClient kraken,
            IKucoinSocketClient kucoin,
            IMexcSocketClient mexc,
            IOKXSocketClient okx,
            IToobitSocketClient toobit,
            IWhiteBitSocketClient whiteBit,
            IXTSocketClient xt)
        {
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
            WhiteBit = whiteBit;
            XT = xt;

            InitSharedClients();
        }

        private void InitSharedClients()
        {
            _socketClients = [Binance, BingX, Bitfinex, Bitget, BitMart, BitMEX, BloFin, Bybit, Coinbase, CoinEx, CoinW, CryptoCom,
                DeepCoin, GateIo, HTX, HyperLiquid, Kraken, Kucoin, Mexc, OKX, Toobit, WhiteBit, XT];

            _sharedClients = new ISharedClient[]
            {
                Binance.SpotApi.SharedClient,
                Binance.UsdFuturesApi.SharedClient,
                Binance.CoinFuturesApi.SharedClient,
                BingX.SpotApi.SharedClient,
                BingX.PerpetualFuturesApi.SharedClient,
                Bitfinex.SpotApi.SharedClient,
                Bitget.SpotApiV2.SharedClient,
                Bitget.FuturesApiV2.SharedClient,
                BitMart.SpotApi.SharedClient,
                BitMart.UsdFuturesApi.SharedClient,
                BitMEX.ExchangeApi.SharedClient,
                BloFin.FuturesApi.SharedClient,
                Bybit.V5InverseApi.SharedClient,
                Bybit.V5LinearApi.SharedClient,
                Bybit.V5PrivateApi.SharedClient,
                Bybit.V5SpotApi.SharedClient,
                Coinbase.AdvancedTradeApi.SharedClient,
                CoinEx.SpotApiV2.SharedClient,
                CoinEx.FuturesApi.SharedClient,
                CoinW.SpotApi.SharedClient,
                CoinW.FuturesApi.SharedClient,
                CryptoCom.ExchangeApi.SharedClient,
                DeepCoin.ExchangeApi.SharedClient,
                GateIo.SpotApi.SharedClient,
                GateIo.PerpetualFuturesApi.SharedClient,
                HTX.SpotApi.SharedClient,
                HTX.UsdtFuturesApi.SharedClient,
                HyperLiquid.SpotApi.SharedClient,
                HyperLiquid.FuturesApi.SharedClient,
                Kraken.SpotApi.SharedClient,
                Kraken.FuturesApi.SharedClient,
                Kucoin.SpotApi.SharedClient,
                Kucoin.FuturesApi.SharedClient,
                Mexc.SpotApi.SharedClient,
                OKX.UnifiedApi.SharedClient,
                Toobit.SpotApi.SharedClient,
                Toobit.UsdtFuturesApi.SharedClient,
                WhiteBit.V4Api.SharedClient,
                XT.SpotApi.SharedClient,
                XT.FuturesApi.SharedClient
            };
        }

        /// <inheritdoc />
        public IEnumerable<ISharedClient> GetExchangeSharedClients(string name, TradingMode? tradingMode = null)
        {
            var result = _sharedClients.Where(s => s.Exchange == name);
            if (tradingMode.HasValue)
                result = result.Where(x => x.SupportedTradingModes.Contains(tradingMode.Value));
            return result.ToList();
        }

        /// <inheritdoc />
        public void SetApiCredentials(ExchangeCredentials credentials)
        {
            void SetCredentialsIfNotNull(string exchange, ApiCredentials? credentials)
            {
                if (credentials == null)
                    return;

                SetApiCredentials(exchange, credentials.Key, credentials.Secret, credentials.Pass);
            }

            SetCredentialsIfNotNull(Exchange.Binance, credentials.Binance);
            SetCredentialsIfNotNull(Exchange.BingX, credentials.BingX);
            SetCredentialsIfNotNull(Exchange.Bitfinex, credentials.Bitfinex);
            SetCredentialsIfNotNull(Exchange.Bitget, credentials.Bitget);
            SetCredentialsIfNotNull(Exchange.BitMart, credentials.BitMart);
            SetCredentialsIfNotNull(Exchange.BitMEX, credentials.BitMEX);
            SetCredentialsIfNotNull(Exchange.BloFin, credentials.BloFin);
            SetCredentialsIfNotNull(Exchange.Bybit, credentials.Bybit);
            SetCredentialsIfNotNull(Exchange.Coinbase, credentials.Coinbase);
            SetCredentialsIfNotNull(Exchange.CoinEx, credentials.CoinEx);
            SetCredentialsIfNotNull(Exchange.CoinW, credentials.CoinW);
            SetCredentialsIfNotNull(Exchange.CryptoCom, credentials.CryptoCom);
            SetCredentialsIfNotNull(Exchange.DeepCoin, credentials.DeepCoin);
            SetCredentialsIfNotNull(Exchange.GateIo, credentials.GateIo);
            SetCredentialsIfNotNull(Exchange.HTX, credentials.HTX);
            SetCredentialsIfNotNull(Exchange.HyperLiquid, credentials.HyperLiquid);
            SetCredentialsIfNotNull(Exchange.Kraken, credentials.Kraken);
            SetCredentialsIfNotNull(Exchange.Kucoin, credentials.Kucoin);
            SetCredentialsIfNotNull(Exchange.Mexc, credentials.Mexc);
            SetCredentialsIfNotNull(Exchange.OKX, credentials.OKX);
            SetCredentialsIfNotNull(Exchange.Toobit, credentials.Toobit);
            SetCredentialsIfNotNull(Exchange.WhiteBit, credentials.WhiteBit);
            SetCredentialsIfNotNull(Exchange.XT, credentials.XT);
        }

        /// <inheritdoc />
        public void SetApiCredentials(string exchange, string apiKey, string apiSecret, string? apiPass = null)
        {
            switch (exchange)
            {
                case "Binance": Binance.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "BingX": BingX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Bitfinex": Bitfinex.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Bitget": Bitget.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for Bitget credentials", nameof(apiPass)))); break;
                case "BitMart": BitMart.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for BitMart credentials", nameof(apiPass)))); break;
                case "BitMEX": BitMEX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "BloFin": BloFin.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Bybit": Bybit.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Coinbase": Coinbase.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "CoinEx": CoinEx.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "CoinW": CoinW.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "CryptoCom": CryptoCom.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "DeepCoin": DeepCoin.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for DeepCoin credentials", nameof(apiPass)))); break;
                case "GateIo": GateIo.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "HTX": HTX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "HyperLiquid": HyperLiquid.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Kraken": Kraken.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "Kucoin": Kucoin.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for Kucoin credentials", nameof(apiPass)))); break;
                case "Mexc": Mexc.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "OKX": OKX.SetApiCredentials(new ApiCredentials(apiKey, apiSecret, apiPass ?? throw new ArgumentException("ApiPass required for OKX credentials", nameof(apiPass)))); break;
                case "Toobit": Toobit.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "WhiteBit": WhiteBit.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                case "XT": XT.SetApiCredentials(new ApiCredentials(apiKey, apiSecret)); break;
                default: throw new ArgumentException("Exchange not recognized", nameof(exchange));
            }
        }

        /// <inheritdoc />
        public string? GetSymbolName(string exchange, SharedSymbol symbol)
        {
            var client = _sharedClients.FirstOrDefault(x => x.Exchange == exchange && x.SupportedTradingModes.Contains(symbol.TradingMode));
            if (client == null)
                return null;

            return symbol.GetSymbol(client.FormatSymbol);
        }


        /// <inheritdoc />
        public async Task UnsubscribeAllAsync()
        {
            var tasks = new[]
            {
                Binance.UnsubscribeAllAsync(),
                BingX.UnsubscribeAllAsync(),
                Bitfinex.UnsubscribeAllAsync(),
                Bitget.UnsubscribeAllAsync(),
                BitMart.UnsubscribeAllAsync(),
                BitMEX.UnsubscribeAllAsync(),
                BloFin.UnsubscribeAllAsync(),
                Bybit.UnsubscribeAllAsync(),
                Coinbase.UnsubscribeAllAsync(),
                CoinEx.UnsubscribeAllAsync(),
                CoinW.UnsubscribeAllAsync(),
                CryptoCom.UnsubscribeAllAsync(),
                DeepCoin.UnsubscribeAllAsync(),
                GateIo.UnsubscribeAllAsync(),
                HTX.UnsubscribeAllAsync(),
                HyperLiquid.UnsubscribeAllAsync(),
                Kraken.UnsubscribeAllAsync(),
                Kucoin.UnsubscribeAllAsync(),
                Mexc.UnsubscribeAllAsync(),
                OKX.UnsubscribeAllAsync(),
                Toobit.UnsubscribeAllAsync(),
                WhiteBit.UnsubscribeAllAsync(),
                XT.UnsubscribeAllAsync()
            };
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
