using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Object")]
    public class ObjectGameEventListener : BaseGameEventListener<Object, ObjectGameEvent, ObjectUnityEvent>
    {
    }
}