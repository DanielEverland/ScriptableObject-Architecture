using UnityEngine;

[CreateAssetMenu(
    fileName = "FloatClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "float",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_CLAMPED_VARIABLES + 0)]
public class FloatClampedVariable : FloatVariable, IClampedVariable<float, FloatVariable, FloatReference>
{
    public FloatReference MinValue { get { return _minClampedValue; } }
    public FloatReference MaxValue { get { return _maxClampedValue; } }

    [SerializeField]
    private FloatReference _minClampedValue;
    [SerializeField]
    private FloatReference _maxClampedValue;

    public virtual float ClampValue(float value)
    {
        if (value.CompareTo(MinValue.Value) < 0)
        {
            return MinValue.Value;
        }
        else if (value.CompareTo(MaxValue.Value) > 0)
        {
            return MaxValue.Value;
        }
        else
        {
            return value;
        }
    }
    public override float SetValue(BaseVariable<float> value)
    {
        return ClampValue(value.Value);
    }
    public override float SetValue(float value)
    {
        return ClampValue(value);
    }
}