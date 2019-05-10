using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "bool")]
    public sealed class BoolGameEventListener : BaseGameEventListener<bool, BoolGameEvent, BoolUnityEvent>
    {
    }
}