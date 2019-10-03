namespace Connect.Protobuf.Streams
{
    public class HeartbeatStream : StreamBase<ProtoHeartbeatEvent>
    {
        public HeartbeatStream(Events events) : base()
        {
            events.HeartbeatEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoHeartbeatEvent e)
        {
            OnNext(e);
        }
    }
}