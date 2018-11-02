using UnityEngine;

[CreateAssetMenu(
    fileName = "DoubleVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "double",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 8)]
public sealed class DoubleVariable : BaseVariable<double>
{
}