using System.ComponentModel;

namespace Connect.Account
{
    public enum TickDataType
    {
        None,

        [Description("Ask")]
        ask,

        [Description("Bid")]
        bid
    }
}