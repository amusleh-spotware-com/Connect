using System.ComponentModel;

namespace Connect.Common.Enums
{
    public enum ErrorCode
    {
        None,

        [Description("Generic error")]
        UNKNOWN_ERROR,

        [Description("Generic error, usually used when input value is not correct")]
        INVALID_REQUEST,

        [Description("Message is not supported. Wrong message")]
        UNSUPPORTED_MESSAGE,

        [Description("Deal execution is reached timeout and rejected")]
        TIMEOUT_ERROR,

        [Description("Generic error for requests by id")]
        ENTITY_NOT_FOUND,

        [Description("Connection to Server is lost or not supported")]
        CANT_ROUTE_REQUEST,

        [Description("Message is too large")]
        FRAME_TOO_LONG,

        [Description("Market is closed")]
        MARKET_CLOSED,

        [Description("Order is blocked (e.g. under execution) and change cannot be applied")]
        CONCURRENT_MODIFICATION,

        [Description("Message is blocked by server")]
        BLOCKED_PAYLOAD_TYPE,

        [Description("Access token is invalid")]
        CH_ACCESS_TOKEN_INVALID,

        [Description("Open API client is not activated or wrong client credentials")]
        CH_CLIENT_AUTH_FAILURE,

        [Description("When a command is sent for not authorized Open API client")]
        CH_CLIENT_NOT_AUTHENTICATED,

        [Description("Client is trying to authenticate twice")]
        CH_CLIENT_ALREADY_AUTHENTICATED,

        [Description("Trading service is not available")]
        CH_SERVER_NOT_REACHABLE,

        [Description("Trading account is not found")]
        CH_CTID_TRADER_ACCOUNT_NOT_FOUND,

        [Description("Could not find this client id")]
        CH_OA_CLIENT_NOT_FOUND,

        [Description("Request frequency is reached")]
        REQUEST_FREQUENCY_EXCEEDED,

        [Description("Server is under maintenance")]
        SERVER_IS_UNDER_MAINTENANCE,

        [Description("Operations are not allowed for this account")]
        CHANNEL_IS_BLOCKED,

        [Description("Limit of connections is reached for this Open API client")]
        CONNECTIONS_LIMIT_EXCEEDED,
    }
}