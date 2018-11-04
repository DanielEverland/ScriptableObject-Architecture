using UnityEngine;

[CreateAssetMenu(
    fileName = "UlongClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "ulong",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 8)]
public class ULongClampedVariable : ClampedVariable<ulong, ULongVariable, ULongReference>
{
    protected override ulong ClampValue(ulong value)
    {
        if (value < MinValue.Value)
            return MinValue.Value;

        if (value > MaxValue.Value)
            return MaxValue.Value;

        return value;
    }
}