using UnityEngine;

[CreateAssetMenu(
    fileName = "ByteClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "byte",
    order = 120)]
public class ByteClampedVariable : ClampedVariable<byte>
{
    protected override byte ClampValue(byte value)
    {
        return (byte)Mathf.Clamp(value, MinValue, MaxValue);
    }
}