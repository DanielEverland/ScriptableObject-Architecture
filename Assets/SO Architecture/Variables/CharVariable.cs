using UnityEngine;

[CreateAssetMenu(
    fileName = "CharVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "Char",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]

public sealed class CharVariable : BaseVariable<char>
{

}