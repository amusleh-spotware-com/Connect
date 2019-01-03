namespace Connect.Trading
{
    public static class ExceptionMessages
    {
        public const string ClientNotConnected = "The client isn't connected to the server, please re-connect and then retry";

        public const string ClientNotAuthorized = "The client isn't authorized yet, please first send authorization request and wait until your client is fully authorized then send messages";
    }
}