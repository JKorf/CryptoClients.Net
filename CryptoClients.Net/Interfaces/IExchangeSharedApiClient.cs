using Aster.Net.Interfaces.Clients;
using Binance.Net.Interfaces.Clients;
using BingX.Net.Interfaces.Clients;
using Bitfinex.Net.Interfaces.Clients;
using Bitget.Net.Interfaces.Clients;
using BitMart.Net.Interfaces.Clients;
using Bitstamp.Net.Interfaces.Clients;
using BloFin.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients;
using Coinbase.Net.Interfaces.Clients;
using CoinEx.Net.Interfaces.Clients;
using CoinW.Net.Interfaces.Clients;
using CryptoCom.Net.Interfaces.Clients;
using CryptoExchange.Net.SharedApis;
using DeepCoin.Net.Interfaces.Clients;
using GateIo.Net.Interfaces.Clients;
using HTX.Net.Interfaces.Clients;
using HyperLiquid.Net.Interfaces.Clients;
using Kraken.Net.Interfaces.Clients;
using Kucoin.Net.Interfaces.Clients;
using LBank.Net.Interfaces.Clients;
using Lighter.Net.Interfaces.Clients;
using Mexc.Net.Interfaces.Clients;
using OKX.Net.Interfaces.Clients;
using Pionex.Net.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Text;
using Tapbit.Net.Interfaces.Clients;
using Toobit.Net.Interfaces.Clients;
using Upbit.Net.Interfaces.Clients;
using Weex.Net.Interfaces.Clients;
using WhiteBit.Net.Interfaces.Clients;
using XT.Net.Interfaces.Clients;

namespace CryptoClients.Net.Interfaces
{
    /// <summary>
    /// Shared API client for exchanges. This interface provides methods to access shared capabilities across different exchange API's.
    /// </summary>
    public interface IExchangeSharedApiClient
    {
        /// <summary>
        /// Get the Shared API client for an exchange.
        /// </summary>
        ISharedApiClientBase? GetClient(string exchange);

        /// <summary>
        /// Get one preferred capability implementation for an exchange.
        /// </summary>
        SharedCapabilityResolution<T>? GetCapability<T>(
            string exchange,
            SharedCapabilityReference<T> capability,
            TradingMode? tradingMode = null)
            where T : ISharedApiCapability;

        /// <summary>
        /// Get one preferred capability implementation for an exchange.
        /// </summary>
        SharedCapabilityResolution<T>? GetCapability<T>(
            string exchange,
            TradingMode? tradingMode = null)
            where T : ISharedApiCapability;

        /// <summary>
        /// Get one matching preferred capability implementation per exchange.
        /// </summary>
        SharedCapabilityResolution<T>[] GetCapabilities<T>(
            TradingMode? tradingMode = null,
            SharedTransport? transport = null,
            IEnumerable<string>? exchanges = null)
            where T : ISharedApiCapability;

        /// <summary>
        /// Get one matching preferred capability implementation per exchange.
        /// </summary>
        SharedCapabilityResolution<T>[] GetCapabilities<T>(
            SharedCapabilityReference<T> capability,
            TradingMode? tradingMode = null,
            IEnumerable<string>? exchanges = null)
            where T : ISharedApiCapability;

        /// <summary>
        /// Get every matching implementation, including multiple transports or API surfaces belonging to the same exchange.
        /// </summary>
        SharedCapabilityResolution<T>[] GetImplementations<T>(
            SharedCapabilityReference<T> capability,
            TradingMode? tradingMode = null,
            IEnumerable<string>? exchanges = null)
            where T : ISharedApiCapability;

        /// <summary>
        /// Get every matching implementation, including multiple transports or API surfaces belonging to the same exchange.
        /// </summary>
        SharedCapabilityResolution<T>[] GetImplementations<T>(
            TradingMode? tradingMode = null,
            SharedTransport? transport = null,
            IEnumerable<string>? exchanges = null)
            where T : ISharedApiCapability;

        /// <summary>
        /// Aster Shared API client.
        /// </summary>
        IAsterSharedApiClient Aster { get; }
        /// <summary>
        /// Binance Shared API client.
        /// </summary>
        IBinanceSharedApiClient Binance { get; }
        /// <summary>
        /// BingX Shared API client.
        /// </summary>
        IBingXSharedApiClient BingX { get; }
        /// <summary>
        /// Bitfinex Shared API client.
        /// </summary>
        IBitfinexSharedApiClient Bitfinex { get; }
        /// <summary>
        /// Bitget Shared API client.
        /// </summary>
        IBitgetSharedApiClient Bitget { get; }
        /// <summary>
        /// BitMart Shared API client.
        /// </summary>
        IBitMartSharedApiClient BitMart { get; }
        /// <summary>
        /// Bitstamp Shared API client.
        /// </summary>
        IBitstampSharedApiClient Bitstamp { get; }
        /// <summary>
        /// BloFin Shared API client.
        /// </summary>
        IBloFinSharedApiClient BloFin { get; }
        /// <summary>
        /// Bybit Shared API client.
        /// </summary>
        IBybitSharedApiClient Bybit { get; }
        /// <summary>
        /// Coinbase Shared API client.
        /// </summary>
        ICoinbaseSharedApiClient Coinbase { get; }
        /// <summary>
        /// CoinEx Shared API client.
        /// </summary>
        ICoinExSharedApiClient CoinEx { get; }
        /// <summary>
        /// CoinW Shared API client.
        /// </summary>
        ICoinWSharedApiClient CoinW { get; }
        /// <summary>
        /// CryptoCom Shared API client.
        /// </summary>
        ICryptoComSharedApiClient CryptoCom { get; }
        /// <summary>
        /// DeepCoin Shared API client.
        /// </summary>
        IDeepCoinSharedApiClient DeepCoin { get; }
        /// <summary>
        /// GateIo Shared API client.
        /// </summary>
        IGateIoSharedApiClient GateIo { get; }
        /// <summary>
        /// HTX Shared API client.
        /// </summary>
        IHTXSharedApiClient HTX { get; }
        /// <summary>
        /// HyperLiquid Shared API client.
        /// </summary>
        IHyperLiquidSharedApiClient HyperLiquid { get; }
        /// <summary>
        /// Kraken Shared API client.
        /// </summary>
        IKrakenSharedApiClient Kraken { get; }
        /// <summary>
        /// Kucoin Shared API client.
        /// </summary>
        IKucoinSharedApiClient Kucoin { get; }
        /// <summary>
        /// LBank Shared API client.
        /// </summary>
        ILBankSharedApiClient LBank { get; }
        /// <summary>
        /// Lighter Shared API client.
        /// </summary>
        ILighterSharedApiClient Lighter { get; }
        /// <summary>
        /// Mexc Shared API client.
        /// </summary>
        IMexcSharedApiClient Mexc { get; }
        /// <summary>
        /// OKX Shared API client.
        /// </summary>
        IOKXSharedApiClient OKX { get; }
        /// <summary>
        /// Pionex Shared API client.
        /// </summary>
        IPionexSharedApiClient Pionex { get; }
        /// <summary>
        /// Tapbit Shared API client.
        /// </summary>
        ITapbitSharedApiClient Tapbit { get; }
        /// <summary>
        /// Toobit Shared API client.
        /// </summary>
        IToobitSharedApiClient Toobit { get; }
        /// <summary>
        /// Upbit Shared API client.
        /// </summary>
        IUpbitSharedApiClient Upbit { get; }
        /// <summary>
        /// Weex Shared API client.
        /// </summary>
        IWeexSharedApiClient Weex { get; }
        /// <summary>
        /// WhiteBit Shared API client.
        /// </summary>
        IWhiteBitSharedApiClient WhiteBit { get; }
        /// <summary>
        /// XT Shared API client.
        /// </summary>
        IXTSharedApiClient XT { get; }
    }
}
