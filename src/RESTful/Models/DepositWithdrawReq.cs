using Newtonsoft.Json;

namespace Connect.RESTful
{
    public class DepositWithdrawReq
    {
        #region Constructor

        public DepositWithdrawReq(long amount)
        {
            Amount = amount;
        }

        #endregion Constructor

        #region Properties

        [JsonProperty("amount")]
        public long Amount { get; set; }

        #endregion Properties
    }
}