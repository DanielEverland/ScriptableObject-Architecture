using UnityEngine;

[CreateAssetMenu(
    fileName = "UshortClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "ushort",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 9)]
public class UShortClampedVariable : ClampedVariable<ushort>
{
    protected override ushort ClampValue(ushort value)
    {
        return (ushort)Mathf.Clamp(value, MinValue, MaxValue);
    }
}