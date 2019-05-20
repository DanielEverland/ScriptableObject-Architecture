using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Vector4 Event Listener")]
    public sealed class Vector4GameEventListener : BaseGameEventListener<Vector4, Vector4GameEvent, Vector4UnityEvent>
    {
    }
}