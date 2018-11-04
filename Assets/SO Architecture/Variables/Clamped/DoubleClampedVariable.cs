using UnityEngine;

[CreateAssetMenu(
    fileName = "DoubleClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "double",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 3)]
public class DoubleClampedVariable : ClampedVariable<double, DoubleVariable, DoubleReference>
{
    protected override double ClampValue(double value)
    {
        if (value < MinValue.Value)
            return MinValue.Value;

        if (value > MaxValue.Value)
            return MaxValue.Value;

        return value;
    }
}