using System;
using System.Collections.Generic;

namespace Connect.Protobuf.Streams
{
    public interface IObservableStream<T> : IObservable<T>
    {
        IEnumerable<IObserver<T>> Observers { get; }
    }
}