using System.ComponentModel;

namespace Connect.RESTful.Enums
{
    public enum OrderType
    {
        [Description("Unknown")]
        None,

        [Description("Market")]
        Market,

        [Description("Limit")]
        Limit,

        [Description("Stop")]
        Stop,

        [Description("Stop Limit")]
        StopLimit,
    }
}