using System.ComponentModel;

namespace Connect.RESTful.Enums
{
    public enum TrendbarType
    {
        [Description("1 minute")]
        m1,

        [Description("2 minutes")]
        m2,

        [Description("3 minutes")]
        m3,

        [Description("4 minutes")]
        m4,

        [Description("5 minutes")]
        m5,

        [Description("10 minutes")]
        m10,

        [Description("15 minutes")]
        m15,

        [Description("30 minutes")]
        m30,

        [Description("1 hour")]
        h1,

        [Description("4 hours")]
        h4,

        [Description("12 hours")]
        h12,

        [Description("Daily")]
        D1,

        [Description("Weekly")]
        W1,

        [Description("Monthly")]
        M1,
    }
}