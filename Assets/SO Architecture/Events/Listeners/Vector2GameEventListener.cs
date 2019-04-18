using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Vector2")]
    public sealed class Vector2GameEventListener : BaseGameEventListener<Vector2, Vector2GameEvent, Vector2UnityEvent>
    {
    }
}