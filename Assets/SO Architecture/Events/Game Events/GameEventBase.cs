using UnityEngine;
using System.Collections.Generic;

public abstract class GameEventBase<T> : SOArchitectureBaseObject, IGameEvent<T>, IStackTraceObject
{
    private readonly List<IGameEventListener<T>> _listeners = new List<IGameEventListener<T>>();

    public List<StackTraceEntry> StackTraces { get { return _stackTraces; } }
    private List<StackTraceEntry> _stackTraces = new List<StackTraceEntry>();

#if UNITY_EDITOR
    [SerializeField]
    protected T _debugValue;

    public void AddStackTrace()
    {
        _stackTraces.Insert(0, StackTraceEntry.Create());
    }
    public void AddStackTrace(object value)
    {
        _stackTraces.Insert(0, StackTraceEntry.Create(value));
    }
#endif
    public void Raise(T value)
    {
        AddStackTrace(value);

        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised(value);
    }
    public void RegisterListener(IGameEventListener<T> listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    public void UnregisterListener(IGameEventListener<T> listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }
}
public abstract class GameEventBase : SOArchitectureBaseObject, IGameEvent, IStackTraceObject
{
    private readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();

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
    public void RegisterListener(IGameEventListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    public void UnregisterListener(IGameEventListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }
}