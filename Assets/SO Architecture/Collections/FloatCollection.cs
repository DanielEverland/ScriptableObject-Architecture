using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "FloatCollection.asset",
        menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "float",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 3)]
    public class FloatCollection : Collection<float>
    {
    } 
}