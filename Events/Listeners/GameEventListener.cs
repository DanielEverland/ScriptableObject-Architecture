using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "GameEvent")]
    [ExecuteInEditMode]
    public sealed class GameEventListener : BaseGameEventListener<GameEventBase, UnityEvent>
    {
    }
}