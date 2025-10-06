using Aster.Net.Interfaces;
using Binance.Net.Interfaces;
using BingX.Net.Interfaces;
using Bitfinex.Net.Interfaces;
using Bitget.Net.Interfaces;
using BitMart.Net.Interfaces;
using BitMEX.Net.Interfaces;
using BloFin.Net.Interfaces;
using Bybit.Net.Interfaces;
using Coinbase.Net.Interfaces;
using CoinEx.Net.Interfaces;
using CoinW.Net.Interfaces;
using CryptoClients.Net.Interfaces;
using CryptoCom.Net.Interfaces;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.Klines;
using CryptoExchange.Net.Trackers.Trades;
using DeepCoin.Net.Interfaces;
using GateIo.Net.Interfaces;
using HTX.Net.Interfaces;
using HyperLiquid.Net.Interfaces;
using Kraken.Net.Interfaces;
using Kucoin.Net.Interfaces;
using Mexc.Net.Interfaces;
using OKX.Net.Interfaces;
using System;
using Toobit.Net.Interfaces;
using WhiteBit.Net.Interfaces;
using XT.Net.Interfaces;

namespace CryptoClients.Net
{
    /// <inheritdoc />
    public class ExchangeTrackerFactory : IExchangeTrackerFactory
    {
        /// <inheritdoc />
        public IAsterTrackerFactory Aster { get; }
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
        public IBitMEXTrackerFactory BitMEX { get; }
        /// <inheritdoc />
        public IBloFinTrackerFactory BloFin { get; }
        /// <inheritdoc />
        public IBybitTrackerFactory Bybit { get; }
        /// <inheritdoc />
        public ICoinbaseTrackerFactory Coinbase { get; }
        /// <inheritdoc />
        public ICoinExTrackerFactory CoinEx { get; }
        /// <inheritdoc />
        public ICoinWTrackerFactory CoinW { get; }
        /// <inheritdoc />
        public ICryptoComTrackerFactory CryptoCom { get; }
        /// <inheritdoc />
        public IDeepCoinTrackerFactory DeepCoin { get; }
        /// <inheritdoc />
        public IGateIoTrackerFactory GateIo { get; }
        /// <inheritdoc />
        public IHTXTrackerFactory HTX { get; }
        /// <inheritdoc />
        public IHyperLiquidTrackerFactory HyperLiquid { get; }
        /// <inheritdoc />
        public IKrakenTrackerFactory Kraken { get; }
        /// <inheritdoc />
        public IKucoinTrackerFactory Kucoin { get; }
        /// <inheritdoc />
        public IMexcTrackerFactory Mexc { get; }
        /// <inheritdoc />
        public IOKXTrackerFactory OKX { get; }
        /// <inheritdoc />
        public IToobitTrackerFactory Toobit { get; }
        /// <inheritdoc />
        public IWhiteBitTrackerFactory WhiteBit { get; }
        /// <inheritdoc />
        public IXTTrackerFactory XT { get; }

        /// <summary>
        /// DI constructor
        /// </summary>
        public ExchangeTrackerFactory(
            IAsterTrackerFactory aster,
            IBinanceTrackerFactory binance,
            IBingXTrackerFactory bingx,
            IBitfinexTrackerFactory bitfinex,
            IBitgetTrackerFactory bitget,
            IBitMartTrackerFactory bitMart,
            IBitMEXTrackerFactory bitMEX,
            IBloFinTrackerFactory bloFin,
            IBybitTrackerFactory bybit,
            ICoinbaseTrackerFactory coinbase,
            ICoinExTrackerFactory coinEx,
            ICoinWTrackerFactory coinW,
            ICryptoComTrackerFactory cryptoCom,
            IDeepCoinTrackerFactory deepCoin,
            IGateIoTrackerFactory gateIo,
            IHTXTrackerFactory htx,
            IHyperLiquidTrackerFactory hyperLiquid,
            IKrakenTrackerFactory kraken,
            IKucoinTrackerFactory kucoin,
            IMexcTrackerFactory mexc,
            IOKXTrackerFactory okx,
            IToobitTrackerFactory toobit,
            IWhiteBitTrackerFactory whiteBit,
            IXTTrackerFactory xt)
        {
            Aster = aster;
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
        }

        private ITrackerFactory? GetTrackerFactoryForExchange(string exchange)
        {
            return exchange switch
            {
                "Aster" => Aster,
                "Binance" => Binance,
                "BingX" => BingX,
                "Bitfinex" => Bitfinex,
                "Bitget" => Bitget,
                "BitMart" => BitMart,
                "BitMEX" => BitMEX,
                "BloFin" => BloFin,
                "Bybit" => Bybit,
                "Coinbase" => Coinbase,
                "CoinEx" => CoinEx,
                "CoinW" => CoinW,
                "CryptoCom" => CryptoCom,
                "DeepCoin" => DeepCoin,
                "GateIo" => GateIo,
                "HTX" => HTX,
                "HyperLiquid" => HyperLiquid,
                "Kraken" => Kraken,
                "Kucoin" => Kucoin,
                "Mexc" => Mexc,
                "OKX" => OKX,
                "Toobit" => Toobit,
                "WhiteBit" => WhiteBit,
                "XT" => XT,
                _ => null
            };
        }

        /// <inheritdoc />
        public IKlineTracker? CreateKlineTracker(string exchange, SharedSymbol symbol, SharedKlineInterval interval, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null)
        {
            var factory = GetTrackerFactoryForExchange(exchange);
            if (factory == null)
                return null;

            if (!factory.CanCreateKlineTracker(symbol, interval))
                return null;

            return factory.CreateKlineTracker(symbol, interval);
        }

        /// <inheritdoc />
        public ITradeTracker? CreateTradeTracker(string exchange, SharedSymbol symbol, int? limit = null, TimeSpan? period = null, ExchangeParameters? exchangeParameters = null)
        {
            var factory = GetTrackerFactoryForExchange(exchange);
            if (factory == null)
                return null;

            if (!factory.CanCreateTradeTracker(symbol))
                return null;

            return factory.CreateTradeTracker(symbol);
        }
    }
}
