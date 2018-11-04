using UnityEngine;

[CreateAssetMenu(
    fileName = "IntClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "int",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 1)]
public class IntClampedVariable : ClampedVariable<int>
{
    protected override int ClampValue(int value)
    {
        return Mathf.Clamp(value, MinValue, MaxValue);
    }
}