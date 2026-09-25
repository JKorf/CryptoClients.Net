using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClients.Net
{
    /// <summary>
    /// Extension methods
    /// </summary>
    public static class CryptoClientsExtensions
    {
        /// <summary>
        /// Get the <see cref="IAssetsRestClient"/> if available
        /// </summary>
        public static IAssetsRestClient? AssetsRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IAssetsRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="IBalanceRestClient"/> if available
        /// </summary>
        public static IBalanceRestClient? BalanceRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IBalanceRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IDepositRestClient"/> if available
        /// </summary>
        public static IDepositRestClient? DepositRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IDepositRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="IKlineRestClient"/> if available
        /// </summary>
        public static IKlineRestClient? KlineRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IKlineRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IOrderBookRestClient"/> if available
        /// </summary>
        public static IOrderBookRestClient? OrderBookRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IOrderBookRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IRecentTradeRestClient"/> if available
        /// </summary>
        public static IRecentTradeRestClient? RecentTradesRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IRecentTradeRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="ITradeHistoryRestClient"/> if available
        /// </summary>
        public static ITradeHistoryRestClient? TradeHistoryRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<ITradeHistoryRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IWithdrawalRestClient"/> if available
        /// </summary>
        public static IWithdrawalRestClient? WithdrawalRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IWithdrawalRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="IWithdrawRestClient"/> if available
        /// </summary>
        public static IWithdrawRestClient? WithdrawRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IWithdrawRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="ISpotTickerRestClient"/> if available
        /// </summary>
        public static ISpotTickerRestClient? SpotTickerRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<ISpotTickerRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="ISpotTickerRestClient"/> if available
        /// </summary>
        public static ISpotSymbolRestClient? SpotSymbolRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<ISpotSymbolRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="ISpotOrderRestClient"/> if available
        /// </summary>
        public static ISpotOrderRestClient? SpotOrderRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<ISpotOrderRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="IFundingRateRestClient"/> if available
        /// </summary>
        public static IFundingRateRestClient? FundingRateRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IFundingRateRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IFuturesOrderRestClient"/> if available
        /// </summary>
        public static IFuturesOrderRestClient? FuturesOrderRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IFuturesOrderRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IFuturesSymbolRestClient"/> if available
        /// </summary>
        public static IFuturesSymbolRestClient? FuturesSymbolRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IFuturesSymbolRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IFuturesTickerRestClient"/> if available
        /// </summary>
        public static IFuturesTickerRestClient? FuturesTickerRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IFuturesTickerRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IIndexPriceKlineRestClient"/> if available
        /// </summary>
        public static IIndexPriceKlineRestClient? IndexPriceKlineRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IIndexPriceKlineRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="ILeverageRestClient"/> if available
        /// </summary>
        public static ILeverageRestClient? LeverageRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<ILeverageRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IMarkPriceKlineRestClient"/> if available
        /// </summary>
        public static IMarkPriceKlineRestClient? MarkPriceKlineRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IMarkPriceKlineRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IOpenInterestRestClient"/> if available
        /// </summary>
        public static IOpenInterestRestClient? OpenInterestRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IOpenInterestRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IPositionHistoryRestClient"/> if available
        /// </summary>
        public static IPositionHistoryRestClient? PositionHistoryRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IPositionHistoryRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IPositionModeRestClient"/> if available
        /// </summary>
        public static IPositionModeRestClient? PositionModeRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IPositionModeRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IBalanceSocketClient"/> if available
        /// </summary>
        public static IBalanceSocketClient? BalanceSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IBalanceSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IBookTickerSocketClient"/> if available
        /// </summary>
        public static IBookTickerSocketClient? BookTickerSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IBookTickerSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IKlineSocketClient"/> if available
        /// </summary>
        public static IKlineSocketClient? KlineSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IKlineSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IOrderBookSocketClient"/> if available
        /// </summary>
        public static IOrderBookSocketClient? OrderBookSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IOrderBookSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="ITickerSocketClient"/> if available
        /// </summary>
        public static ITickerSocketClient? TickerSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<ITickerSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="ITickersSocketClient"/> if available
        /// </summary>
        public static ITickersSocketClient? TickersSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<ITickersSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="ITradeSocketClient"/> if available
        /// </summary>
        public static ITradeSocketClient? TradeSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<ITradeSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="IUserTradeSocketClient"/> if available
        /// </summary>
        public static IUserTradeSocketClient? UserTradeSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IUserTradeSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        /// <summary>
        /// Get the <see cref="ISpotOrderSocketClient"/> if available
        /// </summary>
        public static ISpotOrderSocketClient? SpotOrderSocketClient(this IEnumerable<ISharedClient> clients) => clients.OfType<ISpotOrderSocketClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="ISpotOrderManagementSocketClient"/> if available
        /// </summary>
        public static ISpotOrderManagementSocketClient? SpotOrderManagementSocketClient(this IEnumerable<ISharedClient> clients) => clients.OfType<ISpotOrderManagementSocketClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="IPositionSocketClient"/> if available
        /// </summary>
        public static IPositionSocketClient? PositionSocketClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IPositionSocketClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="IFuturesOrderSocketClient"/> if available
        /// </summary>
        public static IFuturesOrderSocketClient? FuturesOrderSocketClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IFuturesOrderSocketClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="IFuturesOrderManagementSocketClient"/> if available
        /// </summary>
        public static IFuturesOrderManagementSocketClient? FuturesOrderManagementSocketClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IFuturesOrderManagementSocketClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="IBookTickerRestClient"/> if available
        /// </summary>
        public static IBookTickerRestClient? BookTickerRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IBookTickerRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="ISpotTriggerOrderRestClient"/> if available
        /// </summary>
        public static ISpotTriggerOrderRestClient? SpotTriggerOrderRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<ISpotTriggerOrderRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="ISpotOrderClientIdRestClient"/> if available
        /// </summary>
        public static ISpotOrderClientIdRestClient? SpotOrderClientIdRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<ISpotOrderClientIdRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="IFuturesTriggerOrderRestClient"/> if available
        /// </summary>
        public static IFuturesTriggerOrderRestClient? FuturesTriggerOrderRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IFuturesTriggerOrderRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="IFuturesOrderClientIdRestClient"/> if available
        /// </summary>
        public static IFuturesOrderClientIdRestClient? FuturesOrderClientIdRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IFuturesOrderClientIdRestClient>().SingleOrDefault();

        /// <summary>
        /// Get the <see cref="IFuturesTpSlRestClient"/> if available
        /// </summary>
        public static IFuturesTpSlRestClient? FuturesTpSlRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IFuturesTpSlRestClient>().SingleOrDefault();




#warning Remove with next CryptoExchange.Net version
        /// <summary>
        /// Subscribe to trade updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeTradesSocket>> capabilities,
            SubscribeTradeRequest request,
            Action<DataEvent<SharedTrade[]>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToTradeUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to balance updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeBalancesSocket>> capabilities,
            SubscribeBalancesRequest request,
            Action<DataEvent<SharedBalance[]>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToBalanceUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to index price updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeIndexPriceSocket>> capabilities,
            SubscribeIndexPriceRequest request,
            Action<DataEvent<SharedIndexPrice>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToIndexPriceUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to kline updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeKlinesSocket>> capabilities,
            SubscribeKlineRequest request,
            Action<DataEvent<SharedKline>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToKlineUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to mark price updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeMarkPriceSocket>> capabilities,
            SubscribeMarkPriceRequest request,
            Action<DataEvent<SharedMarkPrice>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToMarkPriceUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to order book updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeOrderBookSocket>> capabilities,
            SubscribeOrderBookRequest request,
            Action<DataEvent<SharedOrderBook>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToOrderBookUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to incremental order book updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeIncrementalOrderBookSocket>> capabilities,
            SubscribeOrderBookRequest request,
            Action<DataEvent<SharedOrderBook>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToOrderBookUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to futures order updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeFuturesOrdersSocket>> capabilities,
            SubscribeFuturesOrderRequest request,
            Action<DataEvent<SharedFuturesOrderUpdate[]>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToFuturesOrderUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to spot order updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeSpotOrdersSocket>> capabilities,
            SubscribeSpotOrderRequest request,
            Action<DataEvent<SharedSpotOrderUpdate[]>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToSpotOrderUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to position updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribePositionsSocket>> capabilities,
            SubscribePositionRequest request,
            Action<DataEvent<SharedPosition[]>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToPositionUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to ticker updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeTickerSocket>> capabilities,
            SubscribeTickerRequest request,
            Action<DataEvent<SharedTicker>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToTickerUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to all ticker updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeAllTickersSocket>> capabilities,
            SubscribeAllTickersRequest request,
            Action<DataEvent<SharedTicker[]>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToAllTickersUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Subscribe to user trade updates for all capabilities in parallel and return results as they arrive
        /// </summary>
        public static IAsyncEnumerable<WebSocketResult<UpdateSubscription>> SubscribeAllAsync(
            this IEnumerable<SharedCapabilityResolution<ISubscribeUserTradesSocket>> capabilities,
            SubscribeUserTradeRequest request,
            Action<DataEvent<SharedUserTrade[]>> onData,
            CancellationToken ct = default)
        {
            return capabilities
                .Select(x => x.Capability.SubscribeToUserTradeUpdatesAsync(request, onData, ct))
                .ParallelEnumerateAsync();
        }

        /// <summary>
        /// Wait for all results from an IAsyncEnumerable and return them as an array
        /// </summary>
        public static async Task<T[]> WaitAllAsync<T>(this IAsyncEnumerable<T> enumerable)
        {
            var result = new List<T>();
            await foreach (var itemResult in enumerable.ConfigureAwait(false))
                result.Add(itemResult);

            return result.ToArray();
        }
    }
}