using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using System;
#endif

[CreateAssetMenu(fileName = "GameEvent.asset", menuName = SOArchitecture_Utility.GAME_EVENT, order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public class GameEvent : ScriptableObject
{
#if UNITY_EDITOR
    public List<GameEventStackTrace> StackTraces = new List<GameEventStackTrace>();
#endif

    private readonly List<GameEventListener> _listeners = new List<GameEventListener>();

    public void Raise()
    {
#if UNITY_EDITOR
        StackTraces.Insert(0, GameEventStackTrace.Create());
#endif

        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised();
    }
    public void RegisterListener(GameEventListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }
}
#if UNITY_EDITOR
public class GameEventStackTrace : IEquatable<GameEventStackTrace>
{
    private GameEventStackTrace() { }
    private GameEventStackTrace(string trace)
    {
        _id = UnityEngine.Random.Range(int.MinValue, int.MaxValue);        
        _stackTrace = trace;

        if (Application.isPlaying)
        {
            _frameCount = Time.frameCount;
        }
    }

    private readonly int _id;
    private readonly int _frameCount;
    private readonly string _stackTrace;

    public static GameEventStackTrace Create()
    {
        return new GameEventStackTrace(Environment.StackTrace);
    }
    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        
        if(obj is GameEventStackTrace)
        {
            return Equals(obj as GameEventStackTrace);
        }

        return false;
    }
    public bool Equals(GameEventStackTrace other)
    {
        return other._id == this._id;
    }
    public override int GetHashCode()
    {
        return _id;
    }
    public override string ToString()
    {
        if(_frameCount > 0)
        {
            return string.Format("{0} {1}", _frameCount, _stackTrace);
        }
        else
        {
            return _stackTrace;
        }        
    }    

    public static implicit operator string(GameEventStackTrace trace)
    {
        return trace.ToString();
    }
}
#endif
