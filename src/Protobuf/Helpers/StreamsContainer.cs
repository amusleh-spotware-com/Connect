using Connect.Protobuf.Streams;

namespace Connect.Protobuf.Helpers
{
    public class StreamsContainer
    {
        public StreamsContainer(EventsContainer eventsContainer)
        {
            SpotStream = new SpotStream(eventsContainer);

            HeartbeatStream = new HeartbeatStream(eventsContainer);

            ExecutionStream = new ExecutionStream(eventsContainer);

            MessageStream = new MessageStream(eventsContainer);

            DepthQuotesStream = new DepthQuotesStream(eventsContainer);

            TrailingSLChangedStream = new TrailingSLChangedStream(eventsContainer);

            TraderUpdateStream = new TraderUpdateStream(eventsContainer);

            SymbolChangeStream = new SymbolChangeStream(eventsContainer);

            OrderErrorStream = new OrderErrorStream(eventsContainer);

            MarginChangeStream = new MarginChangeStream(eventsContainer);

            TokenInvalidatedStream = new TokenInvalidatedStream(eventsContainer);

            ClientDisconnectedStream = new ClientDisconnectedStream(eventsContainer);

            ErrorStream = new ErrorStream(eventsContainer);
        }

        public SpotStream SpotStream { get; }

        public HeartbeatStream HeartbeatStream { get; }

        public ExecutionStream ExecutionStream { get; }

        public MessageStream MessageStream { get; }

        public DepthQuotesStream DepthQuotesStream { get; }

        public TrailingSLChangedStream TrailingSLChangedStream { get; }

        public TraderUpdateStream TraderUpdateStream { get; }

        public SymbolChangeStream SymbolChangeStream { get; }

        public OrderErrorStream OrderErrorStream { get; }

        public MarginChangeStream MarginChangeStream { get; }

        public TokenInvalidatedStream TokenInvalidatedStream { get; }

        public ClientDisconnectedStream ClientDisconnectedStream { get; }

        public ErrorStream ErrorStream { get; }
    }
}