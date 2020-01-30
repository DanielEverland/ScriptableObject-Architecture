using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public class Vector2Event : UnityEvent<Vector2> { }

    [CreateAssetMenu(
        fileName = "Vector2Variable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Structs/Vector2",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 10)]
    public sealed class Vector2Variable : BaseVariable<Vector2, Vector2Event>
    {
    } 
}