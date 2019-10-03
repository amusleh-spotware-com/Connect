namespace Connect.Protobuf.Streams
{
    public class MessageStream : StreamBase<ProtoMessage>
    {
        public MessageStream(Events events) : base()
        {
            events.MessageReceivedEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoMessage e)
        {
            OnNext(e);
        }
    }
}