using System.ComponentModel;

namespace Connect.Common
{
    public enum Proxy
    {
        None,

        [Description("de")]
        Germany,

        [Description("fr")]
        France,

        [Description("hk")]
        HongKong,

        [Description("us")]
        USA,

        [Description("uk")]
        UK
    }
}