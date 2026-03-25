using CryptoExchange.Net.SharedApis;

namespace CryptoClients.Net.Models
{
    /// <summary>
    /// Dynamic credentials for an exchange. This is used to dynamically create credentials for an exchange 
    /// without having to know the specific type of credentials required for that exchange.
    /// </summary>
    public class DynamicCredentials
    {
        /// <summary>
        /// Trading mode
        /// </summary>
        public TradingMode TradingMode { get; set; }
        /// <summary>
        /// The key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// First param, generally the API secret or private key
        /// </summary>
        public string? Param1 { get; set; }
        /// <summary>
        /// Second param, generally the passphrase
        /// </summary>
        public string? Param2 { get; set; }
        /// <summary>
        /// Third param
        /// </summary>
        public string? Param3 { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="key">The key</param>
        /// <param name="param1">First param, generally the API secret or private key</param>
        /// <param name="param2">Second param, generally the passphrase</param>
        /// <param name="param3">Third param</param>
        public DynamicCredentials(TradingMode tradingMode, string key, string? param1 = null, string? param2 = null, string? param3 = null)
        {
            TradingMode = tradingMode;
            Key = key;
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }
    }
}
