using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "DoubleClampedVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "double",
        order = 120)]
    public class DoubleClampedVariable : DoubleVariable, IClampedVariable<double, DoubleReference>
    {
        public DoubleReference MinValue { get { return _minClampedValue; } }
        public DoubleReference MaxValue { get { return _maxClampedValue; } }

        [SerializeField]
        private DoubleReference _minClampedValue = default(DoubleReference);
        [SerializeField]
        private DoubleReference _maxClampedValue = default(DoubleReference);

        public virtual double ClampValue(double value)
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
        public override double SetValue(BaseVariable<double> value)
        {
            return ClampValue(value.Value);
        }
        public override double SetValue(double value)
        {
            return ClampValue(value);
        }
    }
}