using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public class GameObjectEvent : UnityEvent<GameObject> { }

    [CreateAssetMenu(
        fileName = "GameObjectVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "GameObject",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 0)]
    public sealed class GameObjectVariable : BaseVariable<GameObject, GameObjectEvent>
    {
    } 
}