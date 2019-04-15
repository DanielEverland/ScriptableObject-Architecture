using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [ExecuteInEditMode]
    public sealed class GameEventListener : BaseGameEventListener<GameEventBase, UnityEvent>
    {
    } 
}