using Newtonsoft.Json;
using System;

namespace Connect.RESTful
{
    public class TradingAccount
    {
        #region Properties

        [JsonProperty("accountID")]
        public long Id { get; set; }

        [JsonProperty("accountNumber")]
        public long Number { get; set; }

        [JsonProperty("live")]
        public bool IsLive { get; set; }

        [JsonProperty("brokerNameId")]
        public string BrokerNameId { get; set; }

        [JsonProperty("brokerTitle")]
        public string BrokerTitle { get; set; }

        [JsonProperty("depositCurrency")]
        public string Currency { get; set; }

        [JsonProperty("traderRegistrationTimestamp")]
        public long RegistrationTimestamp { get; set; }

        [JsonProperty("leverage")]
        public int Leverage { get; set; }

        [JsonProperty("leverageInCents")]
        public int LeverageInCents { get; set; }

        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("isSwapFree")]
        public bool IsSwapFree { get; set; }

        public TradingAccountType Type => IsLive ? TradingAccountType.Live : TradingAccountType.Demo;

        public DateTimeOffset RegistrationTime => DateTimeOffset.FromUnixTimeMilliseconds(RegistrationTimestamp);

        #endregion Properties

        #region Methods

        public static bool operator !=(TradingAccount obj1, TradingAccount obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return !object.ReferenceEquals(obj2, null);
            }

            return !obj1.Equals(obj2);
        }

        public static bool operator ==(TradingAccount obj1, TradingAccount obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return object.ReferenceEquals(obj2, null);
            }

            return obj1.Equals(obj2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is TradingAccount))
            {
                return false;
            }

            return Equals((TradingAccount)obj);
        }

        public bool Equals(TradingAccount other) => other?.Id == Id && other.Number == Number;

        public override int GetHashCode()
        {
            int hash = 17;

            hash = (hash * 31) + Id.GetHashCode();
            hash = (hash * 31) + Number.GetHashCode();

            return hash;
        }

        #endregion Methods
    }
}