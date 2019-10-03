namespace Connect.Protobuf.Streams
{
    public class MarginChangeStream : StreamBase<ProtoOAMarginChangedEvent>
    {
        public MarginChangeStream(Events events) : base()
        {
            events.MarginChangedEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoOAMarginChangedEvent e)
        {
            OnNext(e);
        }
    }
}