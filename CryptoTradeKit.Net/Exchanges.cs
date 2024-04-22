using Binance.Net;
using CryptoExchange.Net.RateLimiting;
using Kucoin.Net;
using System;

namespace CryptoTradeKit.Net
{
    /// <summary>
    /// 
    /// </summary>
    public static class Exchanges
    {
        /// <summary>
        /// Event for when a rate limit is triggered in any of the exchange clients
        /// </summary>
        public static event Action<RateLimitEvent> RateLimitTriggered
        {
            add
            {
                BinanceExchange.RateLimiter.RateLimitTriggered += value;
                //BingXExchange.RateLimiter.RateLimitTriggered += value;
                KucoinExchange.RateLimiter.RateLimitTriggered += value;
            }
            remove
            {
                BinanceExchange.RateLimiter.RateLimitTriggered -= value;
                //BingXExchange.RateLimiter.RateLimitTriggered -= value;
                KucoinExchange.RateLimiter.RateLimitTriggered -= value;
            }
        }
    }
}
