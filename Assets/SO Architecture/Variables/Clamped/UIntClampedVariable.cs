using UnityEngine;

[CreateAssetMenu(
    fileName = "UintClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "uint",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 7)]
public class UIntClampedVariable : ClampedVariable<uint, UIntVariable, UIntReference>
{
    protected override uint ClampValue(uint value)
    {
        return (uint)Mathf.Clamp(value, MinValue.Value, MaxValue.Value);
    }
}