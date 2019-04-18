using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "sbyte")]
    public sealed class SByteGameEventListener : BaseGameEventListener<sbyte, SByteGameEvent, SByteUnityEvent>
    {
    }
}