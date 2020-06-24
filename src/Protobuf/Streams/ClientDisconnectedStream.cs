namespace Connect.Protobuf.Streams
{
    public class ClientDisconnectedStream : StreamBase<ProtoOAClientDisconnectEvent>
    {
        public ClientDisconnectedStream(EventsContainer events) : base()
        {
            events.ClientDisconnectedEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoOAClientDisconnectEvent e)
        {
            OnNext(e);
        }
    }
}