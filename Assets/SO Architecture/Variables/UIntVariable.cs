using UnityEngine;

[CreateAssetMenu(
    fileName = "UnsignedIntVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "uint",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 16)]
public sealed class UIntVariable : BaseVariable<uint>
{
}