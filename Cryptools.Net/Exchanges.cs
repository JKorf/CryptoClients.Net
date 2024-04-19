using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptools.Net
{
    public static class Exchanges
    {
        public const string Binance = "Binance";
        public const string BingX = "BingX";

        public static IEnumerable<string> All { get; } = new[] { Binance, BingX }; 
    }
}
