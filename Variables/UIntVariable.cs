using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "UnsignedIntVariable.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "uint",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 16)]
    public class UIntVariable : BaseVariable<uint>
    {
        public override bool Clampable { get { return true; } }
        protected override uint ClampValue(uint value)
        {
            if (value.CompareTo(MinClampValue) < 0)
            {
                return MinClampValue;
            }
            else if (value.CompareTo(MaxClampValue) > 0)
            {
                return MaxClampValue;
            }
            else
            {
                return value;
            }
        }
    } 
}