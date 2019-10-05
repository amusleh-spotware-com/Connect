using System.ComponentModel;

namespace Connect.Common.Enums
{
    public enum ErrorCode
    {
        None,

        [Description("The access token provided is invalid")]
        CH_ACCESS_TOKEN_INVALID,

        [Description("Server internal error")]
        UNKNOWN_ERROR,

        [Description("Client invalid request (request validation failure)")]
        INVALID_REQUEST,

        [Description("The request requires higher privileges than provided by the access token")]
        CH_INSUFFICIENT_PERMISSIONS,

        [Description("Invalid cursor")]
        CH_CURSOR_INVALID,

        [Description("cTID for the given access token or with the given userId or login(email or nickname) was not found")]
        CH_CTID_NOT_FOUND,

        [Description("Trading account with the given id was not found")]
        CH_CTID_TRADER_ACCOUNT_NOT_FOUND,

        [Description("Symbol with the given id was not found")]
        CH_SYMBOL_NOT_FOUND,

        [Description("Deposit currency with the given name is invalid")]
        CH_DEPOSIT_CURRENCY_INVALID,

        [Description("Linked trader account is not found on trading server. (e.g. it may be deleted by broker)")]
        CH_TRADER_ACCOUNT_NOT_FOUND,

        UNSUPPORTED_MESSAGE,

        WRONG_PASSWORD,

        TIMEOUT_ERROR,

        ENTITY_NOT_FOUND,

        CANT_ROUTE_REQUEST,

        FRAME_TOO_LONG,

        MARKET_CLOSED,

        CONCURRENT_MODIFICATION,

        TRADING_BAD_VOLUME,

        ACCESS_DENIED
    }
}