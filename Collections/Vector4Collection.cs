using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "Vector4Collection.asset",
        menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Structs/Vector4",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 12)]
    public class Vector4Collection : Collection<Vector4>
    {
    } 
}