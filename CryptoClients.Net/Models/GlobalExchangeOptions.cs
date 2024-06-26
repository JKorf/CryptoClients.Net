﻿using CryptoExchange.Net.Objects;
using System;

namespace CryptoClients.Net.Models
{
    /// <summary>
    /// Options to apply to any exchange client (if not overridden)
    /// </summary>
    public record GlobalExchangeOptions
    {
        /// <summary>
        /// Default global options
        /// </summary>
        public static GlobalExchangeOptions Default { get; set; } = new GlobalExchangeOptions();

        /// <summary>
        /// API credentials configuration for exchanges
        /// </summary>
        public ExchangeCredentials? ApiCredentials { get; set; }

        // --- General options ---
        /// <summary>
        /// Proxy settings
        /// </summary>
        public ApiProxy? Proxy { get; set; }

        /// <summary>
        /// If true, the CallResult and DataEvent objects will also include the originally received json data in the OriginalData property
        /// </summary>
        public bool OutputOriginalData { get; set; } = false;

        /// <summary>
        /// The max time a request is allowed to take
        /// </summary>
        public TimeSpan RequestTimeout { get; set; } = TimeSpan.FromSeconds(20);

        /// <summary>
        /// Whether or not client side rate limiting should be applied
        /// </summary>
        public bool RateLimiterEnabled { get; set; } = true;

        /// <summary>
        /// What should happen when a rate limit is reached
        /// </summary>
        public RateLimitingBehaviour RateLimitingBehaviour { get; set; } = RateLimitingBehaviour.Wait;

        /// <summary>
        /// Whether or not client side caching is enabled for Rest GET requests
        /// </summary>
        public bool CachingEnabled { get; set; } = true;

        // --- Socket options ---

        /// <summary>
        /// The reconnect policy for websocket connections
        /// </summary>
        public ReconnectPolicy ReconnectPolicy { get; set; } = ReconnectPolicy.ExponentialBackoff;

        /// <summary>
        /// Time to wait between socket reconnect attempts
        /// </summary>
        public TimeSpan ReconnectInterval { get; set; } = TimeSpan.FromSeconds(5);

        internal GlobalExchangeOptions Copy()
        {
            var options = new GlobalExchangeOptions
            {
                Proxy = Proxy,
                OutputOriginalData = OutputOriginalData,
                RequestTimeout = RequestTimeout,
                RateLimiterEnabled = RateLimiterEnabled,
                RateLimitingBehaviour = RateLimitingBehaviour,
                ReconnectPolicy = ReconnectPolicy,
                ReconnectInterval = ReconnectInterval,
                CachingEnabled = CachingEnabled
            };
            return options;
        }
    }
}
