namespace Connect.Protobuf.Streams
{
    public class OrderErrorStream : StreamBase<ProtoOAOrderErrorEvent>
    {
        public OrderErrorStream(Events events) : base()
        {
            events.OrderErrorEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoOAOrderErrorEvent e)
        {
            OnNext(e);
        }
    }
}