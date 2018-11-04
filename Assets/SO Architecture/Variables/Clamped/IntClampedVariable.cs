using UnityEngine;

[CreateAssetMenu(
    fileName = "IntClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "int",
    order = 120)]
public class IntClampedVariable : ClampedVariable<int>
{
    protected override int ClampValue(int value)
    {
        return Mathf.Clamp(value, MinValue, MaxValue);
    }
}