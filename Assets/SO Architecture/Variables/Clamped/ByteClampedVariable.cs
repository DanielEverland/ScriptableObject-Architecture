using UnityEngine;

[CreateAssetMenu(
    fileName = "ByteClampedVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "byte",
    order = 120)]
public class ByteClampedVariable : ByteVariable, IClampedVariable<byte, ByteVariable, ByteReference>
{
    public ByteReference MinValue { get { return _minClampedValue; } }
    public ByteReference MaxValue { get { return _maxClampedValue; } }

    [SerializeField]
    private ByteReference _minClampedValue = default(ByteReference);
    [SerializeField]
    private ByteReference _maxClampedValue = default(ByteReference);

    public virtual byte ClampValue(byte value)
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
    public override byte SetValue(BaseVariable<byte> value)
    {
        return ClampValue(value.Value);
    }
    public override byte SetValue(byte value)
    {
        return ClampValue(value);
    }
}