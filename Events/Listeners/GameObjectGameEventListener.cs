using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "GameObject Event Listener")]
    public sealed class GameObjectGameEventListener : BaseGameEventListener<GameObject, GameObjectGameEvent, GameObjectUnityEvent>
    {
    }
}