using UnityEngine;

[CreateAssetMenu(
    fileName = "ShortClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "short",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 5)]
public class ShortClampedVariable : ClampedVariable<short, ShortVariable, ShortReference>
{
    protected override short ClampValue(short value)
    {
        return (short)Mathf.Clamp(value, MinValue.Value, MaxValue.Value);
    }
}