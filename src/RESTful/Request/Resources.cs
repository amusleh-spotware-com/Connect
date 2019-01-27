using Connect.RESTful.Enums;

namespace Connect.RESTful.Request
{
    public static class Resources
    {
        #region Fields

        public const string Profile = "profile";

        public const string TradingAccounts = "tradingaccounts";

        public const string Deals = "deals";

        public const string CashFlowHistory = "cashflowhistory";

        public const string PendingOrders = "pendingorders";

        public const string Positions = "positions";

        public const string Symbols = "symbols";

        public const string Trendbars = "trendbars";

        public const string Createdemo = "createdemo";

        public const string Deposit = "deposit";

        public const string Withdraw = "withdraw";

        #endregion Fields

        #region Methods

        public static string GetTradingAccountResource(long accountId, string resource) => $"{TradingAccounts}/{accountId}/{resource}";

        public static string GetSymbolTickResource(long accountId, string symbolName, TickDataType type)
        {
            return $"{TradingAccounts}/{accountId}/{Symbols}/{symbolName}/{type}";
        }

        public static string GetSymbolTrendbarResource(long accountId, string symbolName, TrendbarType type)
        {
            return $"{TradingAccounts}/{accountId}/{Symbols}/{symbolName}/{Trendbars}/{type}";
        }

        #endregion Methods
    }
}