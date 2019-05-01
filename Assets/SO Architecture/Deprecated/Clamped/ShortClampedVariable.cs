using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "ShortClampedVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "short",
        order = 120)]
    public class ShortClampedVariable : ShortVariable, IClampedVariable<short, ShortReference>
    {
        public ShortReference MinValue { get { return _minClampedValue; } }
        public ShortReference MaxValue { get { return _maxClampedValue; } }

        [SerializeField]
        private ShortReference _minClampedValue = default(ShortReference);
        [SerializeField]
        private ShortReference _maxClampedValue = default(ShortReference);

#pragma warning disable 0114
        public virtual short ClampValue(short value)
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
        public override short SetValue(BaseVariable<short> value)
        {
            return ClampValue(value.Value);
        }
        public override short SetValue(short value)
        {
            return ClampValue(value);
        }
    }
}