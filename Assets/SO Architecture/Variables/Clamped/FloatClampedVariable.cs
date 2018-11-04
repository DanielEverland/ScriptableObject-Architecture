using UnityEngine;

[CreateAssetMenu(
    fileName = "FloatClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "float",
    order = 120)]
public class FloatClampedVariable : ClampedVariable<float>
{
    protected override float ClampValue(float value)
    {
        return Mathf.Clamp(value, MinValue, MaxValue);
    }
}