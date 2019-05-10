using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "char")]
    public sealed class CharGameEventListener : BaseGameEventListener<char, CharGameEvent, CharUnityEvent>
    {
    }
}