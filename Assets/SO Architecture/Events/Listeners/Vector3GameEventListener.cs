using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Vector3 Event Listener")]
    public sealed class Vector3GameEventListener : BaseGameEventListener<Vector3, Vector3GameEvent, Vector3UnityEvent>
    {
    }
}