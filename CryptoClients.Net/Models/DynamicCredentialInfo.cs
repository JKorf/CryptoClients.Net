namespace CryptoClients.Net.Models
{
    /// <summary>
    /// Dynamic credentials info for an exchange. This is used to dynamically create credentials for an exchange
    /// </summary>
    public class DynamicCredentialInfo
    {
        /// <summary>
        /// Exchange name
        /// </summary>
        public string Exchange { get; set; } = string.Empty;

        /// <summary>
        /// The description of what the API key should be
        /// </summary>
        public string KeyDescription { get; set; } = string.Empty;

        /// <summary>
        /// Whether Param1 is required
        /// </summary>
        public bool Param1Required { get; set; }
        /// <summary>
        /// The description of what Param1 should be, generally the API secret or private key
        /// </summary>
        public string? Param1Description { get; set; }
        /// <summary>
        /// Whether Param2 is required
        /// </summary>
        public bool Param2Required { get; set; }
        /// <summary>
        /// The description of what Param2 should be, generally the passphrase
        /// </summary>
        public string? Param2Description { get; set; }
        /// <summary>
        /// Whether Param3 is required
        /// </summary>
        public bool Param3Required { get; set; }
        /// <summary>
        /// The description of what Param3 should be
        /// </summary>
        public string? Param3Description { get; set; }
    }

}
