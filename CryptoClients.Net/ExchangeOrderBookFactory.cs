using Aster.Net.Interfaces;
using Binance.Net.Interfaces;
using BingX.Net.Interfaces;
using Bitfinex.Net.Interfaces;
using Bitget.Net.Enums;
using Bitget.Net.Interfaces;
using BitMart.Net.Interfaces;
using BitMEX.Net.Interfaces;
using Bitstamp.Net.Interfaces;
using BloFin.Net.Interfaces;
using Bybit.Net.Interfaces;
using Coinbase.Net.Interfaces;
using CoinEx.Net.Interfaces;
using CoinW.Net.Interfaces;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoClients.Net.OrderBook;
using CryptoCom.Net.Interfaces;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using DeepCoin.Net.Interfaces;
using GateIo.Net.Interfaces;
using HTX.Net.Interfaces;
using HyperLiquid.Net.Interfaces;
using Kraken.Net.Interfaces;
using Kucoin.Net.Interfaces;
using LBank.Net.Interfaces;
using Lighter.Net.Interfaces;
using Mexc.Net.Interfaces;
using OKX.Net.Interfaces;
using Pionex.Net.Interfaces;
using Polymarket.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Toobit.Net.Interfaces;
using Upbit.Net.Interfaces;
using Weex.Net.Interfaces;
using WhiteBit.Net.Interfaces;
using XT.Net.Interfaces;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public class ExchangeOrderBookFactory : IExchangeOrderBookFactory
    {
        /// <inheritdoc />
        public IAsterOrderBookFactory Aster => GetFactory(Exchange.Aster, _aster);
        /// <inheritdoc />
        public IBinanceOrderBookFactory Binance => GetFactory(Exchange.Binance, _binance);
        /// <inheritdoc />
        public IBingXOrderBookFactory BingX => GetFactory(Exchange.BingX, _bingX);
        /// <inheritdoc />
        public IBitfinexOrderBookFactory Bitfinex => GetFactory(Exchange.Bitfinex, _bitfinex);
        /// <inheritdoc />
        public IBitgetOrderBookFactory Bitget => GetFactory(Exchange.Bitget, _bitget);
        /// <inheritdoc />
        public IBitMartOrderBookFactory BitMart => GetFactory(Exchange.BitMart, _bitMart);
        /// <inheritdoc />
        public IBitMEXOrderBookFactory BitMEX => GetFactory(Exchange.BitMEX, _bitMEX);
        /// <inheritdoc />
        public IBitstampOrderBookFactory Bitstamp => GetFactory(Exchange.Bitstamp, _bitstamp);
        /// <inheritdoc />
        public IBloFinOrderBookFactory BloFin => GetFactory(Exchange.BloFin, _bloFin);
        /// <inheritdoc />
        public IBybitOrderBookFactory Bybit => GetFactory(Exchange.Bybit, _bybit);
        /// <inheritdoc />
        public ICoinbaseOrderBookFactory Coinbase => GetFactory(Exchange.Coinbase, _coinbase);
        /// <inheritdoc />
        public ICoinExOrderBookFactory CoinEx => GetFactory(Exchange.CoinEx, _coinEx);
        /// <inheritdoc />
        public ICoinWOrderBookFactory CoinW => GetFactory(Exchange.CoinW, _coinW);
        /// <inheritdoc />
        public ICryptoComOrderBookFactory CryptoCom => GetFactory(Exchange.CryptoCom, _cryptoCom);
        /// <inheritdoc />
        public IDeepCoinOrderBookFactory DeepCoin => GetFactory(Exchange.DeepCoin, _deepCoin);
        /// <inheritdoc />
        public IGateIoOrderBookFactory GateIo => GetFactory(Exchange.GateIo, _gateIo);
        /// <inheritdoc />
        public IHTXOrderBookFactory HTX => GetFactory(Exchange.HTX, _htx);
        /// <inheritdoc />
        public IHyperLiquidOrderBookFactory HyperLiquid => GetFactory(Exchange.HyperLiquid, _hyperLiquid);
        /// <inheritdoc />
        public IKrakenOrderBookFactory Kraken => GetFactory(Exchange.Kraken, _kraken);
        /// <inheritdoc />
        public IKucoinOrderBookFactory Kucoin => GetFactory(Exchange.Kucoin, _kucoin);
        /// <inheritdoc />
        public ILBankOrderBookFactory LBank => GetFactory(Exchange.LBank, _lBank);
        /// <inheritdoc />
        public ILighterOrderBookFactory Lighter => GetFactory(Exchange.Lighter, _lighter);
        /// <inheritdoc />
        public IMexcOrderBookFactory Mexc => GetFactory(Exchange.Mexc, _mexc);
        /// <inheritdoc />
        public IOKXOrderBookFactory OKX => GetFactory(Exchange.OKX, _okx);
        /// <inheritdoc />
        public IPionexOrderBookFactory Pionex => GetFactory(Exchange.Pionex, _pionex);
        /// <inheritdoc />
        public IPolymarketOrderBookFactory Polymarket => GetFactory(Platform.Polymarket, _polymarket);
        /// <inheritdoc />
        public IToobitOrderBookFactory Toobit => GetFactory(Exchange.Toobit, _toobit);
        /// <inheritdoc />
        public IUpbitOrderBookFactory Upbit => GetFactory(Exchange.Upbit, _upbit);
        /// <inheritdoc />
        public IWeexOrderBookFactory Weex => GetFactory(Exchange.Weex, _weex);
        /// <inheritdoc />
        public IWhiteBitOrderBookFactory WhiteBit => GetFactory(Exchange.WhiteBit, _whiteBit);
        /// <inheritdoc />
        public IXTOrderBookFactory XT => GetFactory(Exchange.XT, _xt);

        private HashSet<string>? _enabledExchanges;
        private Lazy<IAsterOrderBookFactory> _aster = null!;
        private Lazy<IBinanceOrderBookFactory> _binance = null!;
        private Lazy<IBingXOrderBookFactory> _bingX = null!;
        private Lazy<IBitfinexOrderBookFactory> _bitfinex = null!;
        private Lazy<IBitgetOrderBookFactory> _bitget = null!;
        private Lazy<IBitMartOrderBookFactory> _bitMart = null!;
        private Lazy<IBitMEXOrderBookFactory> _bitMEX = null!;
        private Lazy<IBitstampOrderBookFactory> _bitstamp = null!;
        private Lazy<IBloFinOrderBookFactory> _bloFin = null!;
        private Lazy<IBybitOrderBookFactory> _bybit = null!;
        private Lazy<ICoinbaseOrderBookFactory> _coinbase = null!;
        private Lazy<ICoinExOrderBookFactory> _coinEx = null!;
        private Lazy<ICoinWOrderBookFactory> _coinW = null!;
        private Lazy<ICryptoComOrderBookFactory> _cryptoCom = null!;
        private Lazy<IDeepCoinOrderBookFactory> _deepCoin = null!;
        private Lazy<IGateIoOrderBookFactory> _gateIo = null!;
        private Lazy<IHTXOrderBookFactory> _htx = null!;
        private Lazy<IHyperLiquidOrderBookFactory> _hyperLiquid = null!;
        private Lazy<IKrakenOrderBookFactory> _kraken = null!;
        private Lazy<IKucoinOrderBookFactory> _kucoin = null!;
        private Lazy<ILBankOrderBookFactory> _lBank = null!;
        private Lazy<ILighterOrderBookFactory> _lighter = null!;
        private Lazy<IMexcOrderBookFactory> _mexc = null!;
        private Lazy<IOKXOrderBookFactory> _okx = null!;
        private Lazy<IPionexOrderBookFactory> _pionex = null!;
        private Lazy<IPolymarketOrderBookFactory> _polymarket = null!;
        private Lazy<IToobitOrderBookFactory> _toobit = null!;
        private Lazy<IUpbitOrderBookFactory> _upbit = null!;
        private Lazy<IWeexOrderBookFactory> _weex = null!;
        private Lazy<IWhiteBitOrderBookFactory> _whiteBit = null!;
        private Lazy<IXTOrderBookFactory> _xt = null!;

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeOrderBookFactory(
            IAsterOrderBookFactory aster,
            IBinanceOrderBookFactory binance,
            IBingXOrderBookFactory bingx,
            IBitfinexOrderBookFactory bitfinex,
            IBitgetOrderBookFactory bitget,
            IBitMartOrderBookFactory bitMart,
            IBitMEXOrderBookFactory bitMEX,
            IBitstampOrderBookFactory bitstamp,
            IBloFinOrderBookFactory bloFin,
            IBybitOrderBookFactory bybit,
            ICoinbaseOrderBookFactory coinbase,
            ICoinExOrderBookFactory coinEx,
            ICoinWOrderBookFactory coinW,
            ICryptoComOrderBookFactory cryptoCom,
            IDeepCoinOrderBookFactory deepCoin,
            IGateIoOrderBookFactory gateIo,
            IHTXOrderBookFactory htx,
            IHyperLiquidOrderBookFactory hyperLiquid,
            IKrakenOrderBookFactory kraken,
            IKucoinOrderBookFactory kucoin,
            ILBankOrderBookFactory lBank,
            ILighterOrderBookFactory lighter,
            IMexcOrderBookFactory mexc,
            IOKXOrderBookFactory okx,
            IPionexOrderBookFactory pionex,
            IPolymarketOrderBookFactory polymarket,
            IToobitOrderBookFactory toobit,
            IUpbitOrderBookFactory upbit,
            IWeexOrderBookFactory weex,
            IWhiteBitOrderBookFactory whiteBit,
            IXTOrderBookFactory xt)
        {
            InitializeFactories(null,
                () => aster, () => binance, () => bingx, () => bitfinex, () => bitget, () => bitMart, () => bitMEX, () => bitstamp,
                () => bloFin, () => bybit, () => coinbase, () => coinEx, () => coinW, () => cryptoCom, () => deepCoin, () => gateIo,
                () => htx, () => hyperLiquid, () => kraken, () => kucoin, () => lBank, () => lighter, () => mexc, () => okx,
                () => pionex, () => polymarket, () => toobit, () => upbit, () => weex, () => whiteBit, () => xt);
        }

        internal ExchangeOrderBookFactory(IEnumerable<string>? enabledExchanges, IServiceProvider serviceProvider)
        {
            InitializeFactories(enabledExchanges,
                () => serviceProvider.GetRequiredService<IAsterOrderBookFactory>(), () => serviceProvider.GetRequiredService<IBinanceOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IBingXOrderBookFactory>(), () => serviceProvider.GetRequiredService<IBitfinexOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IBitgetOrderBookFactory>(), () => serviceProvider.GetRequiredService<IBitMartOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IBitMEXOrderBookFactory>(), () => serviceProvider.GetRequiredService<IBitstampOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IBloFinOrderBookFactory>(), () => serviceProvider.GetRequiredService<IBybitOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<ICoinbaseOrderBookFactory>(), () => serviceProvider.GetRequiredService<ICoinExOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<ICoinWOrderBookFactory>(), () => serviceProvider.GetRequiredService<ICryptoComOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IDeepCoinOrderBookFactory>(), () => serviceProvider.GetRequiredService<IGateIoOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IHTXOrderBookFactory>(), () => serviceProvider.GetRequiredService<IHyperLiquidOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IKrakenOrderBookFactory>(), () => serviceProvider.GetRequiredService<IKucoinOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<ILBankOrderBookFactory>(), () => serviceProvider.GetRequiredService<ILighterOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IMexcOrderBookFactory>(), () => serviceProvider.GetRequiredService<IOKXOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IPionexOrderBookFactory>(), () => serviceProvider.GetRequiredService<IPolymarketOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IToobitOrderBookFactory>(), () => serviceProvider.GetRequiredService<IUpbitOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IWeexOrderBookFactory>(), () => serviceProvider.GetRequiredService<IWhiteBitOrderBookFactory>(),
                () => serviceProvider.GetRequiredService<IXTOrderBookFactory>());
        }

        /// <inheritdoc />
        public ICrossExchangeBook CreateCrossExchange(SharedSymbol symbol, int? minimalDepth = null, IEnumerable<string>? exchanges = null, ExchangeParameters? exchangeParameters = null)
        {
            var book = new CrossExchangeBook(this, symbol, minimalDepth, exchanges, exchangeParameters);
            return book;
        }

        /// <inheritdoc />
        public ISymbolOrderBook[] Create(SharedSymbol symbol, int? minimalDepth = null, IEnumerable<string>? exchanges = null, ExchangeParameters? exchangeParameters = null)
        {
            var result = new List<ISymbolOrderBook>();
            foreach(var exchange in exchanges ?? Exchange.All)
            {
                var book = Create(exchange, symbol, minimalDepth, exchangeParameters);
                if (book != null)
                    result.Add(book);
            }

            return result.ToArray();
        }

        /// <inheritdoc />
        public ISymbolOrderBook? Create(string exchange, SharedSymbol symbol, int? minimalDepth = null,  ExchangeParameters? exchangeParameters = null)
        {
            if (!IsEnabled(exchange))
                return null;

            switch (exchange)
            {
                case "Aster":
                    var asterLimit = GetBookDepth(minimalDepth, true, 5, 10, 20);
                    return Aster.Create(symbol, opts =>
                    {
                        opts.Limit = asterLimit;
                        opts.UpdateInterval = 100;
                    });
                case "Binance":
                    var binanceLimit = GetBookDepth(minimalDepth, true, 5, 10, 20);
                    return Binance.Create(symbol, opts => 
                    { 
                        opts.Limit = binanceLimit;
                        opts.UpdateInterval = 100;
                    });
                case "BingX":
                    var bingXLimit = GetBookDepth(minimalDepth, false, 5, 10, 20, 50, 100);
                    return BingX.Create(symbol, opts => { opts.Limit = bingXLimit; });
                case "Bitfinex":
                    var bitfinexLimit = GetBookDepth(minimalDepth, false, 1, 25, 100, 250);
                    return Bitfinex.Create(symbol, opts => { opts.Limit = bitfinexLimit; });
                case "Bitget":
                    var bitgetLimit = GetBookDepth(minimalDepth, true, 5, 15);
                    var type = ExchangeParameters.GetValue<string?>(exchangeParameters, "Bitget", "ProductType") == "UsdtFutures" ? BitgetProductTypeV2.UsdtFutures : BitgetProductTypeV2.UsdcFutures;
                    return Bitget.Create(symbol, type, opts => { opts.Limit = bitgetLimit; });
                case "BitMart":
                    var bitmartLimit = GetBookDepth(minimalDepth, true, 5, 20, 50);
                    return BitMart.Create(symbol, opts => { opts.Limit = bitmartLimit; });
                case "BitMEX":
                    var bitMEXLimit = GetBookDepth(minimalDepth, true, 25);
                    return BitMEX.Create(symbol, opts => { opts.Limit = bitMEXLimit; });
                case "Bitstamp":
                    return Bitstamp.Create(symbol);
                case "BloFin":
                    var bloFinLimit = GetBookDepth(minimalDepth, false, 5, 400);
                    return BloFin.Create(symbol, opts => { opts.Limit = bloFinLimit; });
                case "Bybit":
                    var bybitLimit = GetBookDepth(minimalDepth, false, 1, 50, 200, 1000);
                    return Bybit.Create(symbol, opts => { opts.Limit = bybitLimit; });
                case "Coinbase":
                    return Coinbase.Create(symbol);
                case "CoinEx":
                    var coinexLimit = GetBookDepth(minimalDepth, false, 5, 10, 20, 50);
                    return CoinEx.Create(symbol, opts => { opts.Limit = coinexLimit; });
                case "CoinW":
                    return CoinW.Create(symbol);
                case "CryptoCom":
                    var cryptoComLimit = GetBookDepth(minimalDepth, false, 10, 50);
                    return CryptoCom.Create(symbol, opts => { opts.Limit = cryptoComLimit; });
                case "DeepCoin":
                    return DeepCoin.Create(symbol);
                case "GateIo":
                    var gateIoLimit = GetBookDepth(minimalDepth, true, 20, 50, 100);
                    return GateIo.Create(symbol, symbol.QuoteAsset == SharedSymbol.UsdOrStable ? null : symbol.QuoteAsset, opts => 
                    { 
                        opts.Limit = gateIoLimit;
                        opts.UpdateInterval = 100;
                    });
                case "HTX":
                    var htxLimit = GetBookDepth(minimalDepth, true, 5, 20, 150, 400);
                    var htxUsdLimit = GetBookDepth(minimalDepth, true, 20, 150);
                    return HTX.Create(symbol, opts => { opts.Levels = symbol.TradingMode == TradingMode.Spot ? htxLimit : htxUsdLimit; });
                case "HyperLiquid":
                    return HyperLiquid.Create(symbol);
                case "Kraken":
                    var krakenLimit = GetBookDepth(minimalDepth, false, 10, 25, 100, 500, 1000);
                    return Kraken.Create(symbol, opts => { opts.Limit = krakenLimit; });
                case "Kucoin":
                    var kucoinLimit = GetBookDepth(minimalDepth, true, 5, 50);
                    return Kucoin.Create(symbol, opts => { opts.Limit = kucoinLimit; });
                case "LBank":
                    var lBankLimit = GetBookDepth(minimalDepth, false, 10, 50, 100);
                    return LBank.Create(symbol, opts => { opts.Limit = lBankLimit; });
                case "Lighter":
                    return Lighter.Create(symbol);
                case "Mexc":
                    var mexcLimit = GetBookDepth(minimalDepth, true, 5, 10, 20);
                    return Mexc.Create(symbol, opts => { opts.Limit = mexcLimit; });
                case "OKX":
                    var okxLimit = GetBookDepth(minimalDepth, true, 1, 5, 400);
                    return OKX.Create(symbol, opts => { opts.Limit = okxLimit; });
                case "Pionex":
                    var pionexLimit = GetBookDepth(minimalDepth, false, 1, 5, 10, 20, 50, 100);
                    return Pionex.Create(symbol, opts => { opts.Limit = pionexLimit; });
                case "Toobit":
                    return Toobit.Create(symbol);
                case "Upbit":
                    var upbitLimit = GetBookDepth(minimalDepth, false, 1, 5, 15, 30);
                    return Upbit.Create(symbol, opts => { opts.Limit = upbitLimit; });
                case "Weex":
                    var weexLimit = GetBookDepth(minimalDepth, false, 15, 200);
                    return Weex.Create(symbol, opts => { opts.Limit = weexLimit; });
                case "WhiteBit":
                    var whiteBitLimit = GetBookDepth(minimalDepth, true, 1, 5, 10, 20, 30, 50, 100);
                    return WhiteBit.Create(symbol, opts => { opts.Limit = whiteBitLimit; });
                case "XT":
                    var xtLimit = GetBookDepth(minimalDepth, true, 5, 10, 20, 50);
                    return XT.Create(symbol, opts => { opts.Limit = xtLimit; });
            }

            return null;
        }

        private void InitializeFactories(
            IEnumerable<string>? enabledExchanges,
            Func<IAsterOrderBookFactory> aster, Func<IBinanceOrderBookFactory> binance, Func<IBingXOrderBookFactory> bingX, Func<IBitfinexOrderBookFactory> bitfinex,
            Func<IBitgetOrderBookFactory> bitget, Func<IBitMartOrderBookFactory> bitMart, Func<IBitMEXOrderBookFactory> bitMEX, Func<IBitstampOrderBookFactory> bitstamp,
            Func<IBloFinOrderBookFactory> bloFin, Func<IBybitOrderBookFactory> bybit, Func<ICoinbaseOrderBookFactory> coinbase, Func<ICoinExOrderBookFactory> coinEx,
            Func<ICoinWOrderBookFactory> coinW, Func<ICryptoComOrderBookFactory> cryptoCom, Func<IDeepCoinOrderBookFactory> deepCoin, Func<IGateIoOrderBookFactory> gateIo,
            Func<IHTXOrderBookFactory> htx, Func<IHyperLiquidOrderBookFactory> hyperLiquid, Func<IKrakenOrderBookFactory> kraken, Func<IKucoinOrderBookFactory> kucoin,
            Func<ILBankOrderBookFactory> lBank, Func<ILighterOrderBookFactory> lighter, Func<IMexcOrderBookFactory> mexc, Func<IOKXOrderBookFactory> okx,
            Func<IPionexOrderBookFactory> pionex, Func<IPolymarketOrderBookFactory> polymarket, Func<IToobitOrderBookFactory> toobit, Func<IUpbitOrderBookFactory> upbit,
            Func<IWeexOrderBookFactory> weex, Func<IWhiteBitOrderBookFactory> whiteBit, Func<IXTOrderBookFactory> xt)
        {
            _enabledExchanges = enabledExchanges == null ? null : new HashSet<string>(enabledExchanges, StringComparer.OrdinalIgnoreCase);
            _aster = new Lazy<IAsterOrderBookFactory>(aster, LazyThreadSafetyMode.ExecutionAndPublication);
            _binance = new Lazy<IBinanceOrderBookFactory>(binance, LazyThreadSafetyMode.ExecutionAndPublication);
            _bingX = new Lazy<IBingXOrderBookFactory>(bingX, LazyThreadSafetyMode.ExecutionAndPublication);
            _bitfinex = new Lazy<IBitfinexOrderBookFactory>(bitfinex, LazyThreadSafetyMode.ExecutionAndPublication);
            _bitget = new Lazy<IBitgetOrderBookFactory>(bitget, LazyThreadSafetyMode.ExecutionAndPublication);
            _bitMart = new Lazy<IBitMartOrderBookFactory>(bitMart, LazyThreadSafetyMode.ExecutionAndPublication);
            _bitMEX = new Lazy<IBitMEXOrderBookFactory>(bitMEX, LazyThreadSafetyMode.ExecutionAndPublication);
            _bitstamp = new Lazy<IBitstampOrderBookFactory>(bitstamp, LazyThreadSafetyMode.ExecutionAndPublication);
            _bloFin = new Lazy<IBloFinOrderBookFactory>(bloFin, LazyThreadSafetyMode.ExecutionAndPublication);
            _bybit = new Lazy<IBybitOrderBookFactory>(bybit, LazyThreadSafetyMode.ExecutionAndPublication);
            _coinbase = new Lazy<ICoinbaseOrderBookFactory>(coinbase, LazyThreadSafetyMode.ExecutionAndPublication);
            _coinEx = new Lazy<ICoinExOrderBookFactory>(coinEx, LazyThreadSafetyMode.ExecutionAndPublication);
            _coinW = new Lazy<ICoinWOrderBookFactory>(coinW, LazyThreadSafetyMode.ExecutionAndPublication);
            _cryptoCom = new Lazy<ICryptoComOrderBookFactory>(cryptoCom, LazyThreadSafetyMode.ExecutionAndPublication);
            _deepCoin = new Lazy<IDeepCoinOrderBookFactory>(deepCoin, LazyThreadSafetyMode.ExecutionAndPublication);
            _gateIo = new Lazy<IGateIoOrderBookFactory>(gateIo, LazyThreadSafetyMode.ExecutionAndPublication);
            _htx = new Lazy<IHTXOrderBookFactory>(htx, LazyThreadSafetyMode.ExecutionAndPublication);
            _hyperLiquid = new Lazy<IHyperLiquidOrderBookFactory>(hyperLiquid, LazyThreadSafetyMode.ExecutionAndPublication);
            _kraken = new Lazy<IKrakenOrderBookFactory>(kraken, LazyThreadSafetyMode.ExecutionAndPublication);
            _kucoin = new Lazy<IKucoinOrderBookFactory>(kucoin, LazyThreadSafetyMode.ExecutionAndPublication);
            _lBank = new Lazy<ILBankOrderBookFactory>(lBank, LazyThreadSafetyMode.ExecutionAndPublication);
            _lighter = new Lazy<ILighterOrderBookFactory>(lighter, LazyThreadSafetyMode.ExecutionAndPublication);
            _mexc = new Lazy<IMexcOrderBookFactory>(mexc, LazyThreadSafetyMode.ExecutionAndPublication);
            _okx = new Lazy<IOKXOrderBookFactory>(okx, LazyThreadSafetyMode.ExecutionAndPublication);
            _pionex = new Lazy<IPionexOrderBookFactory>(pionex, LazyThreadSafetyMode.ExecutionAndPublication);
            _polymarket = new Lazy<IPolymarketOrderBookFactory>(polymarket, LazyThreadSafetyMode.ExecutionAndPublication);
            _toobit = new Lazy<IToobitOrderBookFactory>(toobit, LazyThreadSafetyMode.ExecutionAndPublication);
            _upbit = new Lazy<IUpbitOrderBookFactory>(upbit, LazyThreadSafetyMode.ExecutionAndPublication);
            _weex = new Lazy<IWeexOrderBookFactory>(weex, LazyThreadSafetyMode.ExecutionAndPublication);
            _whiteBit = new Lazy<IWhiteBitOrderBookFactory>(whiteBit, LazyThreadSafetyMode.ExecutionAndPublication);
            _xt = new Lazy<IXTOrderBookFactory>(xt, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        private bool IsEnabled(string name) => _enabledExchanges == null || _enabledExchanges.Contains(name);

#pragma warning disable IL2091
        private T GetFactory<T>(string name, Lazy<T> factory)
        {
            if (!IsEnabled(name))
                throw new InvalidOperationException($"The {name} order book factory is disabled. Add it to {nameof(Models.GlobalExchangeOptions.EnabledExchanges)} before accessing it.");

            return factory.Value;
        }
#pragma warning restore IL2091

        private int? GetBookDepth(int? minimal, bool supportsFull, params int[] supportedLevels)
        {
            if (minimal == null)
                return null;

            foreach (var level in supportedLevels)
            {
                if (minimal <= level)
                    return level;
            }

            return supportsFull ? null : supportedLevels.Last();
        }

    }
}
