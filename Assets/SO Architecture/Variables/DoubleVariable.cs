using UnityEngine;

[CreateAssetMenu(
    fileName = "DoubleVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "Double",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class DoubleVariable : BaseVariable<double>
{
}