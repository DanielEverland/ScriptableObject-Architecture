using UnityEngine;

[CreateAssetMenu(
    fileName = "ShortVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "short",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 14)]
public sealed class ShortVariable : BaseVariable<short>
{
}