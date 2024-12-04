using Binance.Net.Interfaces;
using BingX.Net.Interfaces;
using Bitfinex.Net.Interfaces;
using Bitget.Net.Enums;
using Bitget.Net.Interfaces;
using BitMart.Net.Interfaces;
using Bybit.Net.Interfaces;
using Coinbase.Net.Interfaces;
using CoinEx.Net.Interfaces;
using CryptoClients.Net.Interfaces;
using CryptoCom.Net.Interfaces;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using GateIo.Net.Interfaces;
using HTX.Net.Interfaces;
using Kraken.Net.Interfaces;
using Kucoin.Net.Interfaces;
using Mexc.Net.Interfaces;
using OKX.Net.Interfaces;
using System.Linq;
using WhiteBit.Net.Interfaces;
using XT.Net.Interfaces;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public class ExchangeOrderBookFactory : IExchangeOrderBookFactory
    {
        /// <inheritdoc />
        public IBinanceOrderBookFactory Binance { get; }
        /// <inheritdoc />
        public IBingXOrderBookFactory BingX { get; }
        /// <inheritdoc />
        public IBitfinexOrderBookFactory Bitfinex { get; }
        /// <inheritdoc />
        public IBitgetOrderBookFactory Bitget { get; }
        /// <inheritdoc />
        public IBitMartOrderBookFactory BitMart { get; }
        /// <inheritdoc />
        public IBybitOrderBookFactory Bybit { get; }
        /// <inheritdoc />
        public ICoinbaseOrderBookFactory Coinbase { get; }
        /// <inheritdoc />
        public ICoinExOrderBookFactory CoinEx { get; }
        /// <inheritdoc />
        public ICryptoComOrderBookFactory CryptoCom { get; }
        /// <inheritdoc />
        public IGateIoOrderBookFactory GateIo { get; }
        /// <inheritdoc />
        public IHTXOrderBookFactory HTX { get; }
        /// <inheritdoc />
        public IKrakenOrderBookFactory Kraken { get; }
        /// <inheritdoc />
        public IKucoinOrderBookFactory Kucoin { get; }
        /// <inheritdoc />
        public IMexcOrderBookFactory Mexc { get; }
        /// <inheritdoc />
        public IOKXOrderBookFactory OKX { get; }
        /// <inheritdoc />
        public IWhiteBitOrderBookFactory WhiteBit { get; }
        /// <inheritdoc />
        public IXTOrderBookFactory XT { get; }

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeOrderBookFactory(
            IBinanceOrderBookFactory binance,
            IBingXOrderBookFactory bingx,
            IBitfinexOrderBookFactory bitfinex,
            IBitgetOrderBookFactory bitget,
            IBitMartOrderBookFactory bitMart,
            IBybitOrderBookFactory bybit,
            ICoinbaseOrderBookFactory coinbase,
            ICoinExOrderBookFactory coinEx,
            ICryptoComOrderBookFactory cryptoCom,
            IGateIoOrderBookFactory gateIo,
            IHTXOrderBookFactory htx,
            IKrakenOrderBookFactory kraken,
            IKucoinOrderBookFactory kucoin,
            IMexcOrderBookFactory mexc,
            IOKXOrderBookFactory okx,
            IWhiteBitOrderBookFactory whiteBit,
            IXTOrderBookFactory xt)
        {
            Binance = binance;
            BingX = bingx;
            Bitfinex = bitfinex;
            Bitget = bitget;
            BitMart = bitMart;
            Bybit = bybit;
            Coinbase = coinbase;
            CoinEx = coinEx;
            CryptoCom = cryptoCom;
            GateIo = gateIo;
            HTX = htx;
            Kraken = kraken;
            Kucoin = kucoin;
            Mexc = mexc;
            OKX = okx;
            WhiteBit = whiteBit;
            XT = xt;
        }

        /// <inheritdoc />
        public ISymbolOrderBook? Create(string exchange, SharedSymbol symbol, int? minimalDepth = null,  ExchangeParameters? exchangeParameters = null)
        {
            switch (exchange)
            {
                case "Binance":
                    var binanceLimit = GetBookDepth(minimalDepth, true, 5, 10, 20);
                    return Binance.Create(symbol, opts => { opts.Limit = binanceLimit; });
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
                case "Bybit":
                    var bybitLimit = GetBookDepth(minimalDepth, false, 1, 50, 200);
                    return Bybit.Create(symbol, opts => { opts.Limit = bybitLimit; });
                case "Coinbase":
                    return Coinbase.Create(symbol);
                case "CoinEx":
                    var coinexLimit = GetBookDepth(minimalDepth, false, 5, 10, 20, 50);
                    return CoinEx.Create(symbol, opts => { opts.Limit = coinexLimit; });
                case "CryptoCom":
                    var cryptoComLimit = GetBookDepth(minimalDepth, false, 10, 50);
                    return CryptoCom.Create(symbol, opts => { opts.Limit = cryptoComLimit; });
                case "GateIo":
                    var gateIoLimit = GetBookDepth(minimalDepth, true, 20, 50, 100);
                    return GateIo.Create(symbol, symbol.QuoteAsset, opts => { opts.Limit = gateIoLimit; });
                case "HTX":
                    var htxLimit = GetBookDepth(minimalDepth, true, 5, 20, 150, 400);
                    var htxUsdLimit = GetBookDepth(minimalDepth, true, 20, 150);
                    return HTX.Create(symbol, opts => { opts.Levels = symbol.TradingMode == TradingMode.Spot ? htxLimit : htxUsdLimit; });
                case "Kraken":
                    var krakenLimit = GetBookDepth(minimalDepth, false, 10, 25, 100, 500, 1000);
                    return Kraken.Create(symbol, opts => { opts.Limit = krakenLimit; });
                case "Kucoin":
                    var kucoinLimit = GetBookDepth(minimalDepth, true, 5, 50);
                    return Kucoin.Create(symbol, opts => { opts.Limit = kucoinLimit; });
                case "Mexc":
                    var mexcLimit = GetBookDepth(minimalDepth, true, 5, 10, 20);
                    return Mexc.Create(symbol, opts => { opts.Limit = mexcLimit; });
                case "OKX":
                    var okxLimit = GetBookDepth(minimalDepth, true, 1, 5, 400);
                    return OKX.Create(symbol, opts => { opts.Limit = okxLimit; });
                case "WhiteBit":
                    var whiteBitLimit = GetBookDepth(minimalDepth, true, 1, 5, 10, 20, 30, 50, 100);
                    return WhiteBit.Create(symbol, opts => { opts.Limit = whiteBitLimit; });
                case "XT":
                    var xtLimit = GetBookDepth(minimalDepth, true, 5, 10, 20, 50);
                    return XT.Create(symbol, opts => { opts.Limit = xtLimit; });
            }

            return null;
        }

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
