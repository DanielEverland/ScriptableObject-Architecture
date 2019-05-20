using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "string Event Listener")]
    public sealed class StringGameEventListener : BaseGameEventListener<string, StringGameEvent, StringUnityEvent>
    {
    }
}