using UnityEngine;

[CreateAssetMenu(
    fileName = "SbyteClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "sbyte",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 6)]
public class SbyteClampedVariable : ClampedVariable<sbyte, SByteVariable, SByteReference>
{
    protected override sbyte ClampValue(sbyte value)
    {
        return (sbyte)Mathf.Clamp(value, MinValue.Value, MaxValue.Value);
    }
}