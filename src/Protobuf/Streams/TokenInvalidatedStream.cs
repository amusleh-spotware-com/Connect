﻿namespace Connect.Protobuf.Streams
{
    public class TokenInvalidatedStream : StreamBase<ProtoOAAccountsTokenInvalidatedEvent>
    {
        public TokenInvalidatedStream(EventsContainer events) : base()
        {
            events.AccountsTokenInvalidatedEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoOAAccountsTokenInvalidatedEvent e)
        {
            OnNext(e);
        }
    }
}