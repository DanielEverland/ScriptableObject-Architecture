using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "IntClampedVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "int",
        order = 120)]
    public class IntClampedVariable : IntVariable, IClampedVariable<int, IntReference>
    {
        public IntReference MinValue { get { return _minClampedValue; } }
        public IntReference MaxValue { get { return _maxClampedValue; } }

        [SerializeField]
        private IntReference _minClampedValue = default(IntReference);
        [SerializeField]
        private IntReference _maxClampedValue = default(IntReference);

#pragma warning disable 0114
        public virtual int ClampValue(int value)
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
#pragma warning restore
        public override int SetValue(BaseVariable<int> value)
        {
            return ClampValue(value.Value);
        }
        public override int SetValue(int value)
        {
            return ClampValue(value);
        }
    }
}