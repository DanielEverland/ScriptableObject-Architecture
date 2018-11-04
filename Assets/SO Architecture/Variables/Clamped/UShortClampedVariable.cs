using UnityEngine;

[CreateAssetMenu(
    fileName = "UshortClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "ushort",
    order = 120)]
public class UShortClampedVariable : ClampedVariable<ushort>
{
    protected override ushort ClampValue(ushort value)
    {
        return (ushort)Mathf.Clamp(value, MinValue, MaxValue);
    }
}