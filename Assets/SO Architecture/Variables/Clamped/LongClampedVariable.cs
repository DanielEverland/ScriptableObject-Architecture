using UnityEngine;

[CreateAssetMenu(
    fileName = "LongClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "long",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 4)]
public class LongClampedVariable : ClampedVariable<long, LongVariable, LongReference>
{
    protected override long ClampValue(long value)
    {
        if (value < MinValue.Value)
            return MinValue.Value;

        if (value > MaxValue.Value)
            return MaxValue.Value;

        return value;
    }
}