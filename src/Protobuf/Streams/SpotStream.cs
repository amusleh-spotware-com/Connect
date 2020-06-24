namespace Connect.Protobuf.Streams
{
    public class SpotStream : StreamBase<ProtoOASpotEvent>
    {
        public SpotStream(EventsContainer events) : base()
        {
            events.SpotEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoOASpotEvent e)
        {
            OnNext(e);
        }
    }
}