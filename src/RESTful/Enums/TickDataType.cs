using System.ComponentModel;

namespace Connect.RESTful
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