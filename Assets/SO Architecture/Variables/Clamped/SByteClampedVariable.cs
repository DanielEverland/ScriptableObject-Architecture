using UnityEngine;

[CreateAssetMenu(
    fileName = "SbyteClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "sbyte",
    order = 120)]
public class SbyteClampedVariable : ClampedVariable<sbyte>
{
    protected override sbyte ClampValue(sbyte value)
    {
        return (sbyte)Mathf.Clamp(value, MinValue, MaxValue);
    }
}