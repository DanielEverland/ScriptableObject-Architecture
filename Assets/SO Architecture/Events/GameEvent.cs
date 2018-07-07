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

    private readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();

    public void Raise()
    {
#if UNITY_EDITOR
        StackTraces.Insert(0, GameEventStackTrace.Create());
#endif

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