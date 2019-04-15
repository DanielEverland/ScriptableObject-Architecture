using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "ByteCollection.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_COLLECTION + "byte",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 6)]
    public class ByteCollection : Collection<byte>
    {
    } 
}