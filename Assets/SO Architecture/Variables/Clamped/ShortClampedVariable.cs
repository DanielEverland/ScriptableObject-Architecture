using UnityEngine;

[CreateAssetMenu(
    fileName = "ShortClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "short",
    order = 120)]
public class ShortClampedVariable : ClampedVariable<short>
{
    protected override short ClampValue(short value)
    {
        return (short)Mathf.Clamp(value, MinValue, MaxValue);
    }
}