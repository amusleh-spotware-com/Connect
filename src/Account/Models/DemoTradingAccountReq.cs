using Newtonsoft.Json;

namespace Connect.Account
{
    public class DemoTradingAccountReq
    {
        [JsonProperty("countryId")]
        public long CountryId { get; set; }

        [JsonProperty("phoneNumber")]
        public long PhoneNumber { get; set; }

        [JsonProperty("leverage")]
        public int Leverage { get; set; }

        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("depositCurrency")]
        public string DepositCurrency { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }
    }
}