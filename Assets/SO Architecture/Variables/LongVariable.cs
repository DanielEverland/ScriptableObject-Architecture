using UnityEngine;

[CreateAssetMenu(
    fileName = "LongVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "long",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 9)]
public sealed class LongVariable : BaseVariable<long>
{
}