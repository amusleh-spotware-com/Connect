using System.ComponentModel;

namespace Connect.RESTful.Enums
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