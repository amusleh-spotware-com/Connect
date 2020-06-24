namespace Connect.Protobuf.Streams
{
    public class TraderUpdateStream : StreamBase<ProtoOATraderUpdatedEvent>
    {
        public TraderUpdateStream(EventsContainer events) : base()
        {
            events.TraderUpdatedEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoOATraderUpdatedEvent e)
        {
            OnNext(e);
        }
    }
}