using UnityEngine;

[CreateAssetMenu(
    fileName = "StringVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "String",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public sealed class StringVariable : BaseVariable<string>
{
}