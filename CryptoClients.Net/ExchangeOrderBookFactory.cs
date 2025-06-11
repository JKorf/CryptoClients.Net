using Binance.Net.Interfaces;
using BingX.Net.Interfaces;
using Bitfinex.Net.Interfaces;
using Bitget.Net.Enums;
using Bitget.Net.Interfaces;
using BitMart.Net.Interfaces;
using BitMEX.Net.Interfaces;
using Bybit.Net.Interfaces;
using Coinbase.Net.Interfaces;
using CoinEx.Net.Interfaces;
using CryptoClients.Net.Interfaces;
using CryptoCom.Net.Interfaces;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using DeepCoin.Net.Interfaces;
using GateIo.Net.Interfaces;
using HTX.Net.Interfaces;
using HyperLiquid.Net.Interfaces;
using Kraken.Net.Interfaces;
using Kucoin.Net.Interfaces;
using Mexc.Net.Interfaces;
using OKX.Net.Interfaces;
using System.Linq;
using Toobit.Net.Interfaces;
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
        public IBitMEXOrderBookFactory BitMEX { get; }
        /// <inheritdoc />
        public IBybitOrderBookFactory Bybit { get; }
        /// <inheritdoc />
        public ICoinbaseOrderBookFactory Coinbase { get; }
        /// <inheritdoc />
        public ICoinExOrderBookFactory CoinEx { get; }
        /// <inheritdoc />
        public ICryptoComOrderBookFactory CryptoCom { get; }
        /// <inheritdoc />
        public IDeepCoinOrderBookFactory DeepCoin { get; }
        /// <inheritdoc />
        public IGateIoOrderBookFactory GateIo { get; }
        /// <inheritdoc />
        public IHTXOrderBookFactory HTX { get; }
        /// <inheritdoc />
        public IHyperLiquidOrderBookFactory HyperLiquid { get; }
        /// <inheritdoc />
        public IKrakenOrderBookFactory Kraken { get; }
        /// <inheritdoc />
        public IKucoinOrderBookFactory Kucoin { get; }
        /// <inheritdoc />
        public IMexcOrderBookFactory Mexc { get; }
        /// <inheritdoc />
        public IOKXOrderBookFactory OKX { get; }
        /// <inheritdoc />
        public IToobitOrderBookFactory Toobit { get; }
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
            IBitMEXOrderBookFactory bitMEX,
            IBybitOrderBookFactory bybit,
            ICoinbaseOrderBookFactory coinbase,
            ICoinExOrderBookFactory coinEx,
            ICryptoComOrderBookFactory cryptoCom,
            IDeepCoinOrderBookFactory deepCoin,
            IGateIoOrderBookFactory gateIo,
            IHTXOrderBookFactory htx,
            IHyperLiquidOrderBookFactory hyperLiquid,
            IKrakenOrderBookFactory kraken,
            IKucoinOrderBookFactory kucoin,
            IMexcOrderBookFactory mexc,
            IOKXOrderBookFactory okx,
            IToobitOrderBookFactory toobit,
            IWhiteBitOrderBookFactory whiteBit,
            IXTOrderBookFactory xt)
        {
            Binance = binance;
            BingX = bingx;
            Bitfinex = bitfinex;
            Bitget = bitget;
            BitMart = bitMart;
            BitMEX = bitMEX;
            Bybit = bybit;
            Coinbase = coinbase;
            CoinEx = coinEx;
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
        }

        /// <inheritdoc />
        public ISymbolOrderBook? Create(string exchange, SharedSymbol symbol, int? minimalDepth = null,  ExchangeParameters? exchangeParameters = null)
        {
            switch (exchange)
            {
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
                case "DeepCoin":
                    return DeepCoin.Create(symbol);
                case "GateIo":
                    var gateIoLimit = GetBookDepth(minimalDepth, true, 20, 50, 100);
                    return GateIo.Create(symbol, symbol.QuoteAsset, opts => 
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
                case "Mexc":
                    var mexcLimit = GetBookDepth(minimalDepth, true, 5, 10, 20);
                    return Mexc.Create(symbol, opts => { opts.Limit = mexcLimit; });
                case "OKX":
                    var okxLimit = GetBookDepth(minimalDepth, true, 1, 5, 400);
                    return OKX.Create(symbol, opts => { opts.Limit = okxLimit; });
                case "Toobit":
                    return Toobit.Create(symbol);
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
