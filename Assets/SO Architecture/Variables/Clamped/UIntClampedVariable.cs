using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "UintClampedVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "uint",
        order = 120)]
    public class UintClampedVariable : UIntVariable, IClampedVariable<uint, UIntVariable, UIntVariable>
    {
        public UIntVariable MinValue { get { return _minClampedValue; } }
        public UIntVariable MaxValue { get { return _maxClampedValue; } }

        [SerializeField]
        private UIntVariable _minClampedValue = default(UIntVariable);
        [SerializeField]
        private UIntVariable _maxClampedValue = default(UIntVariable);

        public virtual uint ClampValue(uint value)
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
        public override uint SetValue(BaseVariable<uint> value)
        {
            return ClampValue(value.Value);
        }
        public override uint SetValue(uint value)
        {
            return ClampValue(value);
        }
    } 
}