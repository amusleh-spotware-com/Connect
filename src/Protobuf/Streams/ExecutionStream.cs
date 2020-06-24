namespace Connect.Protobuf.Streams
{
    public class ExecutionStream : StreamBase<ProtoOAExecutionEvent>
    {
        public ExecutionStream(EventsContainer events) : base()
        {
            events.ExecutionEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoOAExecutionEvent e)
        {
            OnNext(e);
        }
    }
}