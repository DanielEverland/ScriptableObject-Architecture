using UnityEngine;

[CreateAssetMenu(
    fileName = "UintClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "uint",
    order = 120)]
public class UIntClampedVariable : ClampedVariable<uint>
{
    protected override uint ClampValue(uint value)
    {
        return (uint)Mathf.Clamp(value, MinValue, MaxValue);
    }
}