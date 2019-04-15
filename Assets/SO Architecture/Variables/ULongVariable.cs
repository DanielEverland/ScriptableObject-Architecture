using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "UnsignedLongVariable.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "ulong",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 17)]
    public class ULongVariable : BaseVariable<ulong>
    {
    } 
}