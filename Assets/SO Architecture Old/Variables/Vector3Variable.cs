using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public class Vector3Event : UnityEvent<Vector3> { }

    [CreateAssetMenu(
        fileName = "Vector3Variable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Structs/Vector3",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 11)]
    public sealed class Vector3Variable : BaseVariable<Vector3, Vector3Event>
    {
    } 
}