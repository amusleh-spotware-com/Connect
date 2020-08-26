namespace Connect.Protobuf.Helpers
{
    internal static class ExceptionMessages
    {
        public const string ClientNotConnected = "The client isn't connected to the server, please re-connect and then retry";

        public const string SemaphoreEnteryTimedOut = "Semaphore entery request timed out, message send attempt failed";
    }
}