using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "SbyteClampedVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "sbyte",
        order = 120)]
    public class SByteClampedVariable : SByteVariable, IClampedVariable<sbyte, SByteVariable>
    {
        public SByteVariable MinValue { get { return _minClampedValue; } }
        public SByteVariable MaxValue { get { return _maxClampedValue; } }

        [SerializeField]
        private SByteVariable _minClampedValue = default(SByteVariable);
        [SerializeField]
        private SByteVariable _maxClampedValue = default(SByteVariable);

        public virtual sbyte ClampValue(sbyte value)
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
        public override sbyte SetValue(BaseVariable<sbyte> value)
        {
            return ClampValue(value.Value);
        }
        public override sbyte SetValue(sbyte value)
        {
            return ClampValue(value);
        }
    }
}