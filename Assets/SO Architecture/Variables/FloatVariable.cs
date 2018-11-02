using UnityEngine;

[CreateAssetMenu(
    fileName = "FloatVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "float",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 3)]
public sealed class FloatVariable : BaseVariable<float>
{
}