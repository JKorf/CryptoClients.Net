using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis.Interfaces;
using CryptoExchange.Net.SharedApis.Interfaces.Rest;
using CryptoExchange.Net.SharedApis.Interfaces.Rest.Futures;
using CryptoExchange.Net.SharedApis.Interfaces.Rest.Spot;
using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using CryptoExchange.Net.SharedApis.Interfaces.Socket.Futures;
using CryptoExchange.Net.SharedApis.Interfaces.Socket.Spot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClients.Net.ExtensionMethods
{
    /// <summary>
    /// Extension methods
    /// </summary>
    public static class CryptoClientsExtensions
    {
        /// <summary>
        /// Return the task results in the form of an IAsyncEnumerable, returning the first completed task first
        /// </summary>
        /// <typeparam name="T">Type of task result</typeparam>
        /// <param name="tasks">Task list</param>
        public static async IAsyncEnumerable<T> ParallelEnumerateAsync<T>(this IEnumerable<Task<T>> tasks)
        {
            var remaining = new List<Task<T>>(tasks);

            while (remaining.Count != 0)
            {
                var task = await Task.WhenAny(remaining);
                remaining.Remove(task);
                yield return (await task);
            }
        }

        public static IAssetsRestClient? AssetsRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IAssetsRestClient>().SingleOrDefault();
        public static IBalanceRestClient? BalanceRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IBalanceRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IDepositRestClient? DepositRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IDepositRestClient>().SingleOrDefault();
        public static IKlineRestClient? KlineRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IKlineRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IListenKeyRestClient? ListenKeyRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IListenKeyRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IOrderBookRestClient? OrderBookRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IOrderBookRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IRecentTradeRestClient? RecentTradesRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IRecentTradeRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static ITradeHistoryRestClient? TradeHistoryRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<ITradeHistoryRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IWithdrawalRestClient? WithdrawalRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IWithdrawalRestClient>().SingleOrDefault();
        public static IWithdrawRestClient? WithdrawRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IWithdrawRestClient>().SingleOrDefault();
        
        public static ISpotTickerRestClient? SpotTickerRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<ISpotTickerRestClient>().SingleOrDefault();
        public static ISpotTickerRestClient? SpotSymbolRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<ISpotTickerRestClient>().SingleOrDefault();
        public static ISpotOrderRestClient? SpotOrderRestClient(this IEnumerable<ISharedClient> clients) => clients.OfType<ISpotOrderRestClient>().SingleOrDefault();
        
        public static IFundingRateRestClient? FundingRateRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IFundingRateRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IFuturesOrderRestClient? FuturesOrderRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IFuturesOrderRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IFuturesSymbolRestClient? FuturesSymbolRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IFuturesSymbolRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IFuturesTickerRestClient? FuturesTickerRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IFuturesTickerRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IIndexPriceKlineRestClient? IndexPriceKlineRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IIndexPriceKlineRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static ILeverageRestClient? LeverageRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<ILeverageRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IMarkPriceKlineRestClient? MarkPriceKlineRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IMarkPriceKlineRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IOpenInterestRestClient? OpenInterestRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IOpenInterestRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IPositionHistoryRestClient? PositionHistoryRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IPositionHistoryRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IPositionModeRestClient? PositionModeRestClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IPositionModeRestClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
    
        public static IBalanceSocketClient? BalanceSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IBalanceSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IBookTickerSocketClient? BookTickerSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IBookTickerSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IKlineSocketClient? KlineSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IKlineSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IOrderBookSocketClient? OrderBookSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IOrderBookSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static ITickerSocketClient? TickerSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<ITickerSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static ITickersSocketClient? TickersSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<ITickersSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static ITradeSocketClient? TradeSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<ITradeSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));
        public static IUserTradeSocketClient? UserTradeSocketClient(this IEnumerable<ISharedClient> clients, TradingMode tradingMode) => clients.OfType<IUserTradeSocketClient>().SingleOrDefault(x => x.SupportedTradingModes.Contains(tradingMode));

        public static ISpotOrderSocketClient? SpotOrderSocketClient(this IEnumerable<ISharedClient> clients) => clients.OfType<ISpotOrderSocketClient>().SingleOrDefault();

        public static IPositionSocketClient? PositionSocketClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IPositionSocketClient>().SingleOrDefault();
        public static IFuturesOrderSocketClient? FuturesOrderSocketClient(this IEnumerable<ISharedClient> clients) => clients.OfType<IFuturesOrderSocketClient>().SingleOrDefault();

    }
}