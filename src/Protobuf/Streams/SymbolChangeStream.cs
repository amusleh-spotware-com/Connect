namespace Connect.Protobuf.Streams
{
    public class SymbolChangeStream : StreamBase<ProtoOASymbolChangedEvent>
    {
        public SymbolChangeStream(Events events) : base()
        {
            events.SymbolChangedEvent += EventHandler;
        }

        private void EventHandler(object sender, ProtoOASymbolChangedEvent e)
        {
            OnNext(e);
        }
    }
}