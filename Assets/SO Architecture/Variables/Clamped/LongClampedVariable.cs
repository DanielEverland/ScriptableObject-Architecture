using UnityEngine;

[CreateAssetMenu(
    fileName = "LongClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "long",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 4)]
public class LongClampedVariable : ClampedVariable<long>
{
    protected override long ClampValue(long value)
    {
        if (value < MinValue)
            return MinValue;

        if (value > MaxValue)
            return MaxValue;

        return value;
    }
}