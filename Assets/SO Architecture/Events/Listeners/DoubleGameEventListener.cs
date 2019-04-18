using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "double")]
    public sealed class DoubleGameEventListener : BaseGameEventListener<double, DoubleGameEvent, DoubleUnityEvent>
    {
    }
}