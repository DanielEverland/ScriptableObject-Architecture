using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "Vector2Collection.asset",
        menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Structs/Vector2",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 10)]
    public class Vector2Collection : Collection<Vector2>
    {
    } 
}