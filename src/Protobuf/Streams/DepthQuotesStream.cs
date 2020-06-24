namespace Connect.Protobuf.Streams
{
    public class DepthQuotesStream : StreamBase<ProtoOADepthEvent>
    {
        public DepthQuotesStream(EventsContainer events) : base()
        {
            events.DepthQuotesEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoOADepthEvent e)
        {
            OnNext(e);
        }
    }
}