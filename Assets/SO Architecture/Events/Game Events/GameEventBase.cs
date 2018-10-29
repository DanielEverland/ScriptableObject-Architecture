using UnityEngine;
using System.Collections.Generic;

public abstract class GameEventBase<T> : GameEventBase, IGameEvent<T>, IStackTraceObject
{
    private readonly List<IGameEventListener<T>> _typedListeners = new List<IGameEventListener<T>>();

#if UNITY_EDITOR
    [SerializeField]
    protected T _debugValue;
#endif
    public void Raise(T value)
    {
        AddStackTrace(value);

        for (int i = _typedListeners.Count - 1; i >= 0; i--)
            _typedListeners[i].OnEventRaised(value);

        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised();
    }
    public void AddListener(IGameEventListener<T> listener)
    {
        if (!_typedListeners.Contains(listener))
            _typedListeners.Add(listener);
    }
    public void RemoveListener(IGameEventListener<T> listener)
    {
        if (_typedListeners.Contains(listener))
            _typedListeners.Remove(listener);
    }
    public override string ToString()
    {
        return "GameEventBase<" + typeof(T) + ">";
    }
}
public abstract class GameEventBase : SOArchitectureBaseObject, IGameEvent, IStackTraceObject
{
    protected readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();

    public List<StackTraceEntry> StackTraces { get { return _stackTraces; } }
    private List<StackTraceEntry> _stackTraces = new List<StackTraceEntry>();

#if UNITY_EDITOR
    public void AddStackTrace()
    {
        _stackTraces.Insert(0, StackTraceEntry.Create());
    }
    public void AddStackTrace(object value)
    {
        _stackTraces.Insert(0, StackTraceEntry.Create(value));
    }
#endif

    public void Raise()
    {
        AddStackTrace();

        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised();
    }
    public void AddListener(IGameEventListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    public void RemoveListener(IGameEventListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }
}