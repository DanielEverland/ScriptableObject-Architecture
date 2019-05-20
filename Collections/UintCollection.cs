using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "UIntCollection.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_COLLECTION + "uint",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 16)]
    public class UIntCollection : Collection<uint>
    {
    } 
}