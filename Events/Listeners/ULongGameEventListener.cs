using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "ulong")]
    public sealed class ULongGameEventListener : BaseGameEventListener<ulong, ULongGameEvent, ULongUnityEvent>
    {
    }
}