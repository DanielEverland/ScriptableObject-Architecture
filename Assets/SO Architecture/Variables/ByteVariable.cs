using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "ByteVariable.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "byte",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 6)]
    public class ByteVariable : BaseVariable<byte>
    {
        public override bool Clampable { get { return true; } }
        protected override byte ClampValue(byte value)
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