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
using CryptoExchange.Net.Trackers.Klines;
using CryptoExchange.Net.Trackers.Trades;
using GateIo.Net.Interfaces;
using HTX.Net.Interfaces;
using Kraken.Net.Interfaces;
using Kucoin.Net.Interfaces;
using Mexc.Net.Interfaces;
using OKX.Net.Interfaces;
using System;
using System.Linq;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public class ExchangeTrackerFactory : IExchangeTrackerFactory
    {
        /// <inheritdoc />
        public IBinanceTrackerFactory Binance { get; }
        /// <inheritdoc />
        public IBingXTrackerFactory BingX { get; }
        /// <inheritdoc />
        public IBitfinexTrackerFactory Bitfinex { get; }
        /// <inheritdoc />
        public IBitgetTrackerFactory Bitget { get; }
        /// <inheritdoc />
        public IBitMartTrackerFactory BitMart { get; }
        /// <inheritdoc />
        public IBybitTrackerFactory Bybit { get; }
        /// <inheritdoc />
        public ICoinbaseTrackerFactory Coinbase { get; }
        /// <inheritdoc />
        public ICoinExTrackerFactory CoinEx { get; }
        /// <inheritdoc />
        public ICryptoComTrackerFactory CryptoCom { get; }
        /// <inheritdoc />
        public IGateIoTrackerFactory GateIo { get; }
        /// <inheritdoc />
        public IHTXTrackerFactory HTX { get; }
        /// <inheritdoc />
        public IKrakenTrackerFactory Kraken { get; }
        /// <inheritdoc />
        public IKucoinTrackerFactory Kucoin { get; }
        /// <inheritdoc />
        public IMexcTrackerFactory Mexc { get; }
        /// <inheritdoc />
        public IOKXTrackerFactory OKX { get; }

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeTrackerFactory(
            IBinanceTrackerFactory binance,
            IBingXTrackerFactory bingx,
            IBitfinexTrackerFactory bitfinex,
            IBitgetTrackerFactory bitget,
            IBitMartTrackerFactory bitMart,
            IBybitTrackerFactory bybit,
            ICoinbaseTrackerFactory coinbase,
            ICoinExTrackerFactory coinEx,
            ICryptoComTrackerFactory cryptoCom,
            IGateIoTrackerFactory gateIo,
            IHTXTrackerFactory htx,
            IKrakenTrackerFactory kraken,
            IKucoinTrackerFactory kucoin,
            IMexcTrackerFactory mexc,
            IOKXTrackerFactory okx)
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
        public IKlineTracker? CreateKlineTracker(string exchange, SharedSymbol symbol, SharedKlineInterval interval, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null)
        {
            switch (exchange)
            {
                case "Binance":
                    return Binance.CreateKlineTracker(symbol, interval, limit, period);
                case "BingX":
                    return BingX.CreateKlineTracker(symbol, interval, limit, period);
                case "Bitfinex":
                    return Bitfinex.CreateKlineTracker(symbol, interval, limit, period);
                case "Bitget":
                    var type = ExchangeParameters.GetValue<string?>(exchangeParameters, "Bitget", "ProductType") == "UsdtFutures" ? BitgetProductTypeV2.UsdtFutures : BitgetProductTypeV2.UsdcFutures;
                    return Bitget.CreateKlineTracker(symbol, interval, limit, period);
                case "BitMart":
                    return BitMart.CreateKlineTracker(symbol, interval, limit, period);
                case "Bybit":
                    return Bybit.CreateKlineTracker(symbol, interval, limit, period);
                case "Coinbase":
                    return Coinbase.CreateKlineTracker(symbol, interval, limit, period);
                case "CoinEx":
                    // No tracker available because there is no websocket kline stream
                    return null;
                case "CryptoCom":
                    return CryptoCom.CreateKlineTracker(symbol, interval, limit, period);
                case "GateIo":
                    return GateIo.CreateKlineTracker(symbol, interval, limit, period);
                case "HTX":
                    return HTX.CreateKlineTracker(symbol, interval, limit, period);
                case "Kraken":
                    return Kraken.CreateKlineTracker(symbol, interval, limit, period);
                case "Kucoin":
                    return Kucoin.CreateKlineTracker(symbol, interval, limit, period);
                case "Mexc":
                    return Mexc.CreateKlineTracker(symbol, interval, limit, period);
                case "OKX":
                    return OKX.CreateKlineTracker(symbol, interval, limit, period);
            }

            return null;
        }

        /// <inheritdoc />
        public ITradeTracker? CreateTradeTracker(string exchange, SharedSymbol symbol, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null)
        {
            switch (exchange)
            {
                case "Binance":
                    return Binance.CreateTradeTracker(symbol, limit, period);
                case "BingX":
                    return BingX.CreateTradeTracker(symbol, limit, period);
                case "Bitfinex":
                    return Bitfinex.CreateTradeTracker(symbol, limit, period);
                case "Bitget":
                    var type = ExchangeParameters.GetValue<string?>(exchangeParameters, "Bitget", "ProductType") == "UsdtFutures" ? BitgetProductTypeV2.UsdtFutures : BitgetProductTypeV2.UsdcFutures;
                    return Bitget.CreateTradeTracker(symbol, limit, period);
                case "BitMart":
                    return BitMart.CreateTradeTracker(symbol, limit, period);
                case "Bybit":
                    return Bybit.CreateTradeTracker(symbol, limit, period);
                case "Coinbase":
                    return Coinbase.CreateTradeTracker(symbol, limit, period);
                case "CoinEx":
                    return CoinEx.CreateTradeTracker(symbol, limit, period);
                case "CryptoCom":
                    return CryptoCom.CreateTradeTracker(symbol, limit, period);
                case "GateIo":
                    return GateIo.CreateTradeTracker(symbol, limit, period);
                case "HTX":
                    return HTX.CreateTradeTracker(symbol, limit, period);
                case "Kraken":
                    return Kraken.CreateTradeTracker(symbol, limit, period);
                case "Kucoin":
                    return Kucoin.CreateTradeTracker(symbol, limit, period);
                case "Mexc":
                    return Mexc.CreateTradeTracker(symbol, limit, period);
                case "OKX":
                    return OKX.CreateTradeTracker(symbol, limit, period);
            }

            return null;
        }
    }
}
