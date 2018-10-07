using UnityEngine;

[CreateAssetMenu(
    fileName = "IntVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Integer",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public sealed class IntVariable : BaseVariable<int>
{
}