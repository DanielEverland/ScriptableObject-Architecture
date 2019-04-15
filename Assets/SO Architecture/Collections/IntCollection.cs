using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "IntCollection.asset",
        menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "int",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 4)]
    public class IntCollection : Collection<int>
    {
    } 
}