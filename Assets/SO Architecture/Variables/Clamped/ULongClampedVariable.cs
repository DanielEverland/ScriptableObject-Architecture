using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "UlongClampedVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "ulong",
        order = 120)]
    public class UlongClampedVariable : ULongVariable, IClampedVariable<ulong, ULongVariable>
    {
        public ULongVariable MinValue { get { return _minClampedValue; } }
        public ULongVariable MaxValue { get { return _maxClampedValue; } }

        [SerializeField]
        private ULongVariable _minClampedValue = default(ULongVariable);
        [SerializeField]
        private ULongVariable _maxClampedValue = default(ULongVariable);

        public virtual ulong ClampValue(ulong value)
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
        public override ulong SetValue(BaseVariable<ulong> value)
        {
            return ClampValue(value.Value);
        }
        public override ulong SetValue(ulong value)
        {
            return ClampValue(value);
        }
    }
}