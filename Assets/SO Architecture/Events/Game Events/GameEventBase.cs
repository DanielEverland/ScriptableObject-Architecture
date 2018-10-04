using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using System;
#endif

public abstract class GameEventBase<T> : GameEventStackTraceBase, IGameEvent<T>
{
    private readonly List<IGameEventListener<T>> _listeners = new List<IGameEventListener<T>>();

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
public abstract class GameEventBase : GameEventStackTraceBase, IGameEvent
{
    private readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();

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
public abstract class GameEventStackTraceBase : SOArchitectureBaseObject
{
#if UNITY_EDITOR
    public List<GameEventStackTrace> StackTraces = new List<GameEventStackTrace>();
#endif

    protected void AddStackTrace(object obj)
    {
#if UNITY_EDITOR
        StackTraces.Insert(0, GameEventStackTrace.Create(obj));
#endif
    }
    protected void AddStackTrace()
    {
#if UNITY_EDITOR
        StackTraces.Insert(0, GameEventStackTrace.Create());
#endif
    }
}