using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Connect.Protobuf.Helpers
{
    public class ObservableStream<T> : IObservable<T>, IDisposable
    {
        #region Fields

        private readonly IObservable<T> _stream;

        private readonly List<IObserver<T>> _observers = new List<IObserver<T>>();

        #endregion Fields

        public ObservableStream(List<IObserver<T>> observers)
        {
            _observers = observers;

            _stream = Observable.Create<T>(OnSubscribe);
        }

        #region Methods

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return _stream.Subscribe(observer);
        }

        public void Next(T value, List<IObserver<T>> observers)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(value);
            }
        }

        public void Error(Exception exception, List<IObserver<T>> observers)
        {
            foreach (var observer in observers)
            {
                observer.OnError(exception);
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

        public void Dispose()
        {
            foreach (var observer in _observers)
            {
                OnDispose(observer);
            }
        }

        #endregion Methods
    }
}