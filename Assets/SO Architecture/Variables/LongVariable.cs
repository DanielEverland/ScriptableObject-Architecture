using UnityEngine;

[CreateAssetMenu(
    fileName = "LongVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "Long",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class LongVariable : BaseVariable<long>
{
}