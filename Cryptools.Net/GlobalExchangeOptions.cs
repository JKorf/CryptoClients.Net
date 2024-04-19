using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptools.Net
{
    public record GlobalExchangeOptions
    {
        /// <summary>
        /// Proxy settings
        /// </summary>
        public ApiProxy? Proxy { get; set; }

        public ApiCredentials BinanceApiCredentials { get; set; }

        public ApiCredentials BingXApiCredentials { get; set; }
    }
}
