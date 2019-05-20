using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "UnsignedLongVariable.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "ulong",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 17)]
    public class ULongVariable : BaseVariable<ulong>
    {
        public override bool Clampable { get { return true; } }
        protected override ulong ClampValue(ulong value)
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