using UnityEngine;

[CreateAssetMenu(
    fileName = "BoolVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Boolean",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public sealed class BoolVariable : BaseVariable<bool>
{
}