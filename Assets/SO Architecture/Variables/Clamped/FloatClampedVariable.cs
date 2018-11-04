using UnityEngine;

[CreateAssetMenu(
    fileName = "FloatClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "float",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 0)]
public class FloatClampedVariable : ClampedVariable<float, FloatVariable, FloatReference>
{
    protected override float ClampValue(float value)
    {
        return Mathf.Clamp(value, MinValue.Value, MaxValue.Value);
    }
}