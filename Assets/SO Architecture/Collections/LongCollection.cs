using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "LongCollection.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_COLLECTION + "long",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 9)]
    public class LongCollection : Collection<long>
    {
    } 
}