using UnityEngine;

[CreateAssetMenu(
    fileName = "ByteClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "byte",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 2)]
public class ByteClampedVariable : ClampedVariable<byte, ByteVariable, ByteReference>
{
    protected override byte ClampValue(byte value)
    {
        return (byte)Mathf.Clamp(value, MinValue.Value, MaxValue.Value);
    }
}