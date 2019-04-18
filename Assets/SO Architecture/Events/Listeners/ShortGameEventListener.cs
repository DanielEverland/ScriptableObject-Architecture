using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "short")]
    public sealed class ShortGameEventListener : BaseGameEventListener<short, ShortGameEvent, ShortUnityEvent>
    {
    }
}