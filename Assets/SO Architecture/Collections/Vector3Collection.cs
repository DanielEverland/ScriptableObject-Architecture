using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "Vector3Collection.asset",
        menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Structs/Vector3",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 11)]
    public class Vector3Collection : Collection<Vector3>
    {
    } 
}