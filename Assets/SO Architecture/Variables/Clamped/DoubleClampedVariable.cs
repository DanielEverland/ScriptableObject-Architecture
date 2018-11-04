using UnityEngine;

[CreateAssetMenu(
    fileName = "DoubleClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "double",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 3)]
public class DoubleClampedVariable : ClampedVariable<double>
{
    protected override double ClampValue(double value)
    {
        if (value < MinValue)
            return MinValue;

        if (value > MaxValue)
            return MaxValue;

        return value;
    }
}