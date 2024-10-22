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
        public ISymbolOrderBook? Create(string exchange, SharedSymbol symbol, ExchangeParameters? exchangeParameters = null)
        {
            // Might want to make this more generic, don't want to create a client just to format symbol
            switch (exchange)
            {
                case "Binance":
                    var binanceClient = new BinanceRestClient();
                    return symbol.TradingMode == TradingMode.Spot ? Binance.Spot.Create(symbol.GetSymbol(binanceClient.SpotApi.FormatSymbol))
                        : symbol.TradingMode.IsLinear() ? Binance.UsdFutures.Create(symbol.GetSymbol(binanceClient.UsdFuturesApi.FormatSymbol))
                        : Binance.CoinFutures.Create(symbol.GetSymbol(binanceClient.CoinFuturesApi.FormatSymbol));
                case "BingX":
                    var bingXClient = new BingXRestClient();
                    return symbol.TradingMode == TradingMode.Spot ? BingX.Spot.Create(symbol.GetSymbol(bingXClient.SpotApi.FormatSymbol))
                        : BingX.PerpetualFutures.Create(symbol.GetSymbol(bingXClient.PerpetualFuturesApi.FormatSymbol));
                case "Bitfinex":
                    var bitfinexClient = new BitfinexRestClient();
                    return Bitfinex.Spot.Create(symbol.GetSymbol(bitfinexClient.SpotApi.FormatSymbol));
                case "Bitget":
                    var bitgetClient = new BitgetRestClient();
                    return symbol.TradingMode == TradingMode.Spot ? Bitget.Spot.Create(symbol.GetSymbol(bitgetClient.SpotApiV2.FormatSymbol))
                        : symbol.TradingMode.IsInverse() ? Bitget.CoinFutures.Create(symbol.GetSymbol(bitgetClient.FuturesApiV2.FormatSymbol))
                        : ExchangeParameters.GetValue<string?>(exchangeParameters, "Bitget", "ProductType") == "UsdtFutures" ? Bitget.UsdtFutures.Create(symbol.GetSymbol(bitgetClient.FuturesApiV2.FormatSymbol))
                        : Bitget.UsdcFutures.Create(symbol.GetSymbol(bitgetClient.FuturesApiV2.FormatSymbol));
                case "BitMart":
                    var bitmartClient = new BitMartRestClient();
                    return symbol.TradingMode == TradingMode.Spot ? BitMart.Spot.Create(symbol.GetSymbol(bitmartClient.SpotApi.FormatSymbol))
                        : BitMart.UsdFutures.Create(symbol.GetSymbol(bitmartClient.UsdFuturesApi.FormatSymbol));
                case "Bybit":
                    var bybitClient = new BybitRestClient();
                    return symbol.TradingMode == TradingMode.Spot ? Bybit.Spot.Create(symbol.GetSymbol(bybitClient.V5Api.FormatSymbol))
                        : Bybit.LinearInverse.Create(symbol.GetSymbol(bybitClient.V5Api.FormatSymbol));
                case "Coinbase":
                    var coinbaseClient = new CoinbaseRestClient();
                    return Coinbase.AdvancedTrade.Create(symbol.GetSymbol(coinbaseClient.AdvancedTradeApi.FormatSymbol));
                case "CoinEx":
                    var coinexClient = new CoinExRestClient();
                    return symbol.TradingMode == TradingMode.Spot ? CoinEx.Spot.Create(symbol.GetSymbol(coinexClient.SpotApiV2.FormatSymbol))
                        : CoinEx.Futures.Create(symbol.GetSymbol(coinexClient.FuturesApi.FormatSymbol));
                case "CryptoCom":
                    var cryptoComClient = new CryptoComSocketClient();
                    return CryptoCom.Exchange.Create(symbol.GetSymbol(cryptoComClient.ExchangeApi.FormatSymbol));
                case "GateIo":
                    var gateClient = new GateIoRestClient();
                    return symbol.TradingMode == TradingMode.Spot ? GateIo.Spot.Create(symbol.GetSymbol(gateClient.SpotApi.FormatSymbol))
                        : symbol.QuoteAsset == "USDT" ? GateIo.PerpetualFuturesUsdt.Create(symbol.GetSymbol(gateClient.PerpetualFuturesApi.FormatSymbol))
                        : symbol.QuoteAsset == "USD" ? GateIo.PerpetualFuturesUsd.Create(symbol.GetSymbol(gateClient.PerpetualFuturesApi.FormatSymbol))
                        : GateIo.PerpetualFuturesBtc.Create(symbol.GetSymbol(gateClient.PerpetualFuturesApi.FormatSymbol));
                case "HTX":
                    var htxClient = new HTXRestClient();
                    return symbol.TradingMode == TradingMode.Spot ? HTX.Spot.Create(symbol.GetSymbol(htxClient.SpotApi.FormatSymbol))
                        : HTX.UsdtFutures.Create(symbol.GetSymbol(htxClient.UsdtFuturesApi.FormatSymbol));
                case "Kraken":
                    var krakenClient = new KrakenSocketClient();
                    return symbol.TradingMode == TradingMode.Spot ? Kraken.Spot.Create(symbol.GetSymbol(krakenClient.SpotApi.FormatSymbol))
                        : Kraken.Futures.Create(symbol.GetSymbol(krakenClient.FuturesApi.FormatSymbol));
                case "Kucoin":
                    var kucoinClient = new KucoinRestClient();
                    return symbol.TradingMode == TradingMode.Spot ? Kucoin.Spot.Create(symbol.GetSymbol(kucoinClient.SpotApi.FormatSymbol))
                        : Kucoin.Futures.Create(symbol.GetSymbol(kucoinClient.FuturesApi.FormatSymbol));
                case "Mexc":
                    var mexcClient = new MexcRestClient();
                    return Mexc.Spot.Create(symbol.GetSymbol(mexcClient.SpotApi.FormatSymbol));
                case "OKX":
                    var okxClient = new OKXRestClient();
                    return  OKX.Unified.Create(symbol.GetSymbol(okxClient.UnifiedApi.FormatSymbol));
            }

            return null;
        }
    }
}
