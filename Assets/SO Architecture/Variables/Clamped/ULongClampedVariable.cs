using UnityEngine;

[CreateAssetMenu(
    fileName = "UlongClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "ulong",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 8)]
public class ULongClampedVariable : ClampedVariable<ulong>
{
    protected override ulong ClampValue(ulong value)
    {
        if (value < MinValue)
            return MinValue;

        if (value > MaxValue)
            return MaxValue;

        return value;
    }
}