using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "UshortClampedVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_CLAMPED_SUBMENU + "ushort",
        order = 120)]
    public class UshortClampedVariable : UShortVariable, IClampedVariable<ushort, UShortVariable, UShortVariable>
    {
        public UShortVariable MinValue { get { return _minClampedValue; } }
        public UShortVariable MaxValue { get { return _maxClampedValue; } }

        [SerializeField]
        private UShortVariable _minClampedValue = default(UShortVariable);
        [SerializeField]
        private UShortVariable _maxClampedValue = default(UShortVariable);

        public virtual ushort ClampValue(ushort value)
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
        public override ushort SetValue(BaseVariable<ushort> value)
        {
            return ClampValue(value.Value);
        }
        public override ushort SetValue(ushort value)
        {
            return ClampValue(value);
        }
    } 
}