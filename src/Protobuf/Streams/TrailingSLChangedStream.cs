namespace Connect.Protobuf.Streams
{
    public class TrailingSLChangedStream : StreamBase<ProtoOATrailingSLChangedEvent>
    {
        public TrailingSLChangedStream(Events events) : base()
        {
            events.TrailingSLChangedEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoOATrailingSLChangedEvent e)
        {
            OnNext(e);
        }
    }
}