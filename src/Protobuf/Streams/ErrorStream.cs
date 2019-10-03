namespace Connect.Protobuf.Streams
{
    public class ErrorStream : StreamBase<ProtoOAErrorRes>
    {
        public ErrorStream(Events events) : base()
        {
            events.ErrorEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoOAErrorRes e)
        {
            OnNext(e);
        }
    }
}