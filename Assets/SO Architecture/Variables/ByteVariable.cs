using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "ByteVariable.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "byte",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 6)]
    public class ByteVariable : BaseVariable<byte>
    {
    } 
}