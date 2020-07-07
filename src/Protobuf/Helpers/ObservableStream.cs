using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Connect.Protobuf.Helpers
{
    public class ObservableStream<T> : IObservable<T>
    {
        #region Fields

        private readonly IObservable<T> _stream;

        private readonly List<IObserver<T>> _observers = new List<IObserver<T>>();

        #endregion Fields

        public ObservableStream()
        {
            _stream = Observable.Create<T>(OnSubscribe);
        }

        public IEnumerable<IObserver<T>> Observers => _observers;

        #region OnNext, OnError, OnCompleted

        internal void OnNext(T value)
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

        internal void OnError(Exception exception)
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

        internal void OnCompleted()
        {
            var observersCopy = _observers.ToArray();

            foreach (var observer in observersCopy)
            {
                if (_observers.Contains(observer))
                {
                    observer.OnCompleted();
                }
            }
        }

        #endregion OnNext, OnError, OnCompleted

        #region Other methods

        public IDisposable Subscribe(IObserver<T> observer) => _stream.Subscribe(observer);

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

        #endregion Other methods
    }
}