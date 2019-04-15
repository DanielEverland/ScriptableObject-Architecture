using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "ShortCollection.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_COLLECTION + "short",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 14)]
    public class ShortCollection : Collection<short>
    {
    } 
}