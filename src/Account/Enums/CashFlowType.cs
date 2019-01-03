﻿using System.ComponentModel;

namespace Connect.Account
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