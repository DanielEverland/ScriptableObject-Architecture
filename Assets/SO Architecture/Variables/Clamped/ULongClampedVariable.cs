using UnityEngine;

[CreateAssetMenu(
    fileName = "UlongClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "ulong",
    order = 120)]
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