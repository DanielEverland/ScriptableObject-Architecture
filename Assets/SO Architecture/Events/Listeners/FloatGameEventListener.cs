using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "float")]
    public sealed class FloatGameEventListener : BaseGameEventListener<float, FloatGameEvent, FloatUnityEvent>
    {
    }
}