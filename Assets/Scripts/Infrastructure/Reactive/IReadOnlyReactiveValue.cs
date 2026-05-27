using System;

public interface IReadOnlyReactiveValue<out T>
{
    T Value { get; }

    IDisposable Subscribe(Action<T> callback, bool invokeImmediately = true);
}