using System;

public sealed class ReactiveValue<T> : IReadOnlyReactiveValue<T>
{
    private event Action<T> Changed;

    private T _value;

    public T Value
    {
        get => _value;
        set
        {
            if (Equals(_value, value))
            {
                return;
            }

            _value = value;
            Changed?.Invoke(_value);
        }
    }

    public ReactiveValue(T initialValue)
    {
        _value = initialValue;
    }

    public IDisposable Subscribe(Action<T> callback, bool invokeImmediately = true)
    {
        Changed += callback;

        if (invokeImmediately)
        {
            callback.Invoke(_value);
        }

        return new Subscription(() =>
        {
            Changed -= callback;
        });
    }

    private sealed class Subscription : IDisposable
    {
        private Action _dispose;

        public Subscription(Action dispose)
        {
            _dispose = dispose;
        }

        public void Dispose()
        {
            _dispose?.Invoke();
            _dispose = null;
        }
    }
}