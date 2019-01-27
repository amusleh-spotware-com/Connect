using System.ComponentModel;

namespace Connect.RESTful.Enums
{
    public enum CashFlowType
    {
        [Description("Unknown")]
        None,

        [Description("Deposit")]
        DEPOSIT,

        [Description("Dividends")]
        DEPOSIT_DIVIDENDS,

        [Description("Withdraw")]
        WITHDRAW,
    }
}