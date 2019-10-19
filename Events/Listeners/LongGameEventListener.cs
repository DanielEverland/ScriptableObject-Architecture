using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "long Event Listener")]
    public sealed class LongGameEventListener : BaseGameEventListener<long, LongGameEvent, LongUnityEvent>
    {
    }
}