using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Connect.Protobuf.Streams
{
    public abstract class StreamBase<T> : IObservable<T>
    {
        #region Fields

        private readonly IObservable<T> _stream;

        private readonly List<IObserver<T>> _observers = new List<IObserver<T>>();

        #endregion Fields

        public StreamBase()
        {
            _stream = Observable.Create<T>(OnSubscribe);
        }

        #region Methods

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return _stream.Subscribe(observer);
        }

        protected void OnNext(T value)
        {
            var observersCopy = _observers.ToArray();

            foreach (var observer in observersCopy)
            {
                if (_observers.Contains(observer))
                {
                    observer.OnNext(value);
                }
            }
        }

        protected void OnError(Exception exception)
        {
            var observersCopy = _observers.ToArray();

            foreach (var observer in observersCopy)
            {
                if (_observers.Contains(observer))
                {
                    observer.OnError(exception);
                }
            }
        }

        private IDisposable OnSubscribe(IObserver<T> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }

            return Disposable.Create(() => OnDispose(observer));
        }

        private void OnDispose(IObserver<T> observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        #endregion Methods
    }
}