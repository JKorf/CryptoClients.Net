using Binance.Net.Interfaces;
using BingX.Net.Interfaces;
using Bitfinex.Net.Interfaces;
using Bitget.Net.Interfaces;
using Bybit.Net.Interfaces;
using CoinEx.Net.Interfaces;
using CryptoClients.Net.Interfaces;
using GateIo.Net.Interfaces;
using Huobi.Net.Interfaces;
using Kraken.Net.Interfaces;
using Kucoin.Net.Interfaces;
using Mexc.Net.Interfaces;
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
        public IBybitOrderBookFactory Bybit { get; }
        /// <inheritdoc />
        public ICoinExOrderBookFactory CoinEx { get; }
        /// <inheritdoc />
        public IGateIoOrderBookFactory GateIo { get; }
        /// <inheritdoc />
        public IHuobiOrderBookFactory Huobi { get; }
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
            IBybitOrderBookFactory bybit,
            ICoinExOrderBookFactory coinEx,
            IGateIoOrderBookFactory gateIo,
            IHuobiOrderBookFactory huobi,
            IKrakenOrderBookFactory kraken,
            IKucoinOrderBookFactory kucoin,
            IMexcOrderBookFactory mexc,
            IOKXOrderBookFactory okx)
        {
            Binance = binance;
            BingX = bingx;
            Bitfinex = bitfinex;
            Bitget = bitget;
            Bybit = bybit;
            CoinEx = coinEx;
            GateIo = gateIo;
            Huobi = huobi;
            Kraken = kraken;
            Kucoin = kucoin;
            Mexc = mexc;
            OKX = okx;
        }

    }
}
