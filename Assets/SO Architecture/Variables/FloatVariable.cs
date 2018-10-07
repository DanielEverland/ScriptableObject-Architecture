using UnityEngine;

[CreateAssetMenu(
    fileName = "FloatVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Float",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public sealed class FloatVariable : BaseVariable<float>
{
}