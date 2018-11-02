using UnityEngine;

[CreateAssetMenu(
    fileName = "SByteVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "sbyte",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 15)]
public sealed class SByteVariable : BaseVariable<sbyte>
{
}