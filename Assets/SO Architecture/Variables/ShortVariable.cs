using UnityEngine;

[CreateAssetMenu(
    fileName = "ShortVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "Short",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class ShortVariable : BaseVariable<short>
{
}