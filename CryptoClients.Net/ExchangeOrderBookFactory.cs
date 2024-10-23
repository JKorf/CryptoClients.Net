using Binance.Net.Clients;
using Binance.Net.Interfaces;
using BingX.Net.Clients;
using BingX.Net.Interfaces;
using Bitfinex.Net.Clients;
using Bitfinex.Net.Interfaces;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces;
using BitMart.Net.Clients;
using BitMart.Net.Interfaces;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces;
using Coinbase.Net.Clients;
using Coinbase.Net.Interfaces;
using CoinEx.Net.Clients;
using CoinEx.Net.Interfaces;
using CryptoClients.Net.Enums;
using CryptoClients.Net.Interfaces;
using CryptoCom.Net.Clients;
using CryptoCom.Net.Interfaces;
using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using GateIo.Net.Clients;
using GateIo.Net.Interfaces;
using HTX.Net.Clients;
using HTX.Net.Interfaces;
using Kraken.Net.Clients;
using Kraken.Net.Interfaces;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces;
using Mexc.Net.Clients;
using Mexc.Net.Interfaces;
using OKX.Net.Clients;
using OKX.Net.Interfaces;
using System.Linq;

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
            IOKXOrderBookFactory okx)
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
        }

        /// <inheritdoc />
        public ISymbolOrderBook? Create(string exchange, SharedSymbol symbol, int? minimalDepth = null,  ExchangeParameters? exchangeParameters = null)
        {
            // Might want to make this more generic, don't want to create a client just to format symbol
            switch (exchange)
            {
                case "Binance":
                    var binanceClient = new BinanceRestClient();
                    var binanceLimit = GetBookDepth(minimalDepth, true, 5, 10, 20); 
                    return symbol.TradingMode == TradingMode.Spot ? Binance.Spot.Create(symbol.GetSymbol(binanceClient.SpotApi.FormatSymbol), opts => { opts.Limit = binanceLimit; })
                        : symbol.TradingMode.IsLinear() ? Binance.UsdFutures.Create(symbol.GetSymbol(binanceClient.UsdFuturesApi.FormatSymbol), opts => { opts.Limit = binanceLimit; })
                        : Binance.CoinFutures.Create(symbol.GetSymbol(binanceClient.CoinFuturesApi.FormatSymbol), opts => { opts.Limit = binanceLimit; });
                case "BingX":
                    var bingXClient = new BingXRestClient();
                    var bingXLimit = GetBookDepth(minimalDepth, false, 5, 10, 20, 50, 100);
                    return symbol.TradingMode == TradingMode.Spot ? BingX.Spot.Create(symbol.GetSymbol(bingXClient.SpotApi.FormatSymbol), opts => { opts.Limit = bingXLimit; })
                        : BingX.PerpetualFutures.Create(symbol.GetSymbol(bingXClient.PerpetualFuturesApi.FormatSymbol), opts => { opts.Limit = bingXLimit; });
                case "Bitfinex":
                    var bitfinexClient = new BitfinexRestClient();
                    var bitfinexLimit = GetBookDepth(minimalDepth, false, 1, 25, 100, 250);
                    return Bitfinex.Spot.Create(symbol.GetSymbol(bitfinexClient.SpotApi.FormatSymbol), opts => { opts.Limit = bitfinexLimit; });
                case "Bitget":
                    var bitgetClient = new BitgetRestClient();
                    var bitgetLimit = GetBookDepth(minimalDepth, true, 5, 15);
                    return symbol.TradingMode == TradingMode.Spot ? Bitget.Spot.Create(symbol.GetSymbol(bitgetClient.SpotApiV2.FormatSymbol), opts => { opts.Limit = bitgetLimit; })
                        : symbol.TradingMode.IsInverse() ? Bitget.CoinFutures.Create(symbol.GetSymbol(bitgetClient.FuturesApiV2.FormatSymbol), opts => { opts.Limit = bitgetLimit; })
                        : ExchangeParameters.GetValue<string?>(exchangeParameters, "Bitget", "ProductType") == "UsdtFutures" ? Bitget.UsdtFutures.Create(symbol.GetSymbol(bitgetClient.FuturesApiV2.FormatSymbol), opts => { opts.Limit = bitgetLimit; })
                        : Bitget.UsdcFutures.Create(symbol.GetSymbol(bitgetClient.FuturesApiV2.FormatSymbol), opts => { opts.Limit = bitgetLimit; });
                case "BitMart":
                    var bitmartClient = new BitMartRestClient();
                    var bitmartLimit = GetBookDepth(minimalDepth, true, 5, 20, 50);
                    return symbol.TradingMode == TradingMode.Spot ? BitMart.Spot.Create(symbol.GetSymbol(bitmartClient.SpotApi.FormatSymbol), opts => { opts.Limit = bitmartLimit; })
                        : BitMart.UsdFutures.Create(symbol.GetSymbol(bitmartClient.UsdFuturesApi.FormatSymbol), opts => { opts.Limit = bitmartLimit; });
                case "Bybit":
                    var bybitClient = new BybitRestClient();
                    var bybitLimit = GetBookDepth(minimalDepth, false, 1, 50, 200);
                    return symbol.TradingMode == TradingMode.Spot ? Bybit.Spot.Create(symbol.GetSymbol(bybitClient.V5Api.FormatSymbol), opts => { opts.Limit = bybitLimit; })
                        : Bybit.LinearInverse.Create(symbol.GetSymbol(bybitClient.V5Api.FormatSymbol), opts => { opts.Limit = bybitLimit; });
                case "Coinbase":
                    var coinbaseClient = new CoinbaseRestClient();
                    return Coinbase.AdvancedTrade.Create(symbol.GetSymbol(coinbaseClient.AdvancedTradeApi.FormatSymbol));
                case "CoinEx":
                    var coinexClient = new CoinExRestClient();
                    var coinexLimit = GetBookDepth(minimalDepth, false, 5, 10, 20, 50);
                    return symbol.TradingMode == TradingMode.Spot ? CoinEx.Spot.Create(symbol.GetSymbol(coinexClient.SpotApiV2.FormatSymbol), opts => { opts.Limit = coinexLimit; })
                        : CoinEx.Futures.Create(symbol.GetSymbol(coinexClient.FuturesApi.FormatSymbol), opts => { opts.Limit = coinexLimit; });
                case "CryptoCom":
                    var cryptoComClient = new CryptoComSocketClient();
                    var cryptoComLimit = GetBookDepth(minimalDepth, false, 10, 50);
                    return CryptoCom.Exchange.Create(symbol.GetSymbol(cryptoComClient.ExchangeApi.FormatSymbol), opts => { opts.Limit = cryptoComLimit; });
                case "GateIo":
                    var gateClient = new GateIoRestClient();
                    var gateIoLimit = GetBookDepth(minimalDepth, true, 5, 10, 20, 50, 100);
                    return symbol.TradingMode == TradingMode.Spot ? GateIo.Spot.Create(symbol.GetSymbol(gateClient.SpotApi.FormatSymbol), opts => { opts.Limit = gateIoLimit; })
                        : symbol.QuoteAsset == "USDT" ? GateIo.PerpetualFuturesUsdt.Create(symbol.GetSymbol(gateClient.PerpetualFuturesApi.FormatSymbol), opts => { opts.Limit = gateIoLimit; })
                        : symbol.QuoteAsset == "USD" ? GateIo.PerpetualFuturesUsd.Create(symbol.GetSymbol(gateClient.PerpetualFuturesApi.FormatSymbol), opts => { opts.Limit = gateIoLimit; })
                        : GateIo.PerpetualFuturesBtc.Create(symbol.GetSymbol(gateClient.PerpetualFuturesApi.FormatSymbol), opts => { opts.Limit = gateIoLimit; });
                case "HTX":
                    var htxClient = new HTXRestClient();
                    var htxLimit = GetBookDepth(minimalDepth, true, 5, 20, 150, 400);
                    var htxUsdLimit = GetBookDepth(minimalDepth, true, 20, 150);
                    return symbol.TradingMode == TradingMode.Spot ? HTX.Spot.Create(symbol.GetSymbol(htxClient.SpotApi.FormatSymbol), opts => { opts.Levels = htxLimit; })
                        : HTX.UsdtFutures.Create(symbol.GetSymbol(htxClient.UsdtFuturesApi.FormatSymbol), opts => { opts.Levels = htxUsdLimit; });
                case "Kraken":
                    var krakenClient = new KrakenSocketClient();
                    var krakenLimit = GetBookDepth(minimalDepth, false, 10, 25, 100, 500, 1000);
                    return symbol.TradingMode == TradingMode.Spot ? Kraken.Spot.Create(symbol.GetSymbol(krakenClient.SpotApi.FormatSymbol), opts => { opts.Limit = krakenLimit; })
                        : Kraken.Futures.Create(symbol.GetSymbol(krakenClient.FuturesApi.FormatSymbol));
                case "Kucoin":
                    var kucoinClient = new KucoinRestClient();
                    var kucoinLimit = GetBookDepth(minimalDepth, true, 5, 50);
                    return symbol.TradingMode == TradingMode.Spot ? Kucoin.Spot.Create(symbol.GetSymbol(kucoinClient.SpotApi.FormatSymbol), opts => { opts.Limit = kucoinLimit; })
                        : Kucoin.Futures.Create(symbol.GetSymbol(kucoinClient.FuturesApi.FormatSymbol), opts => { opts.Limit = kucoinLimit; });
                case "Mexc":
                    var mexcClient = new MexcRestClient();
                    var mexcLimit = GetBookDepth(minimalDepth, true, 5, 10, 20);
                    return Mexc.Spot.Create(symbol.GetSymbol(mexcClient.SpotApi.FormatSymbol), opts => { opts.Limit = mexcLimit; });
                case "OKX":
                    var okxClient = new OKXRestClient();
                    var okxLimit = GetBookDepth(minimalDepth, true, 1, 5, 50, 400);
                    return OKX.Unified.Create(symbol.GetSymbol(okxClient.UnifiedApi.FormatSymbol)); // Apply limit when order book implementation supports it
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
