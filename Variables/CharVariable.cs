using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "CharVariable.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "char",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 7)]
    public sealed class CharVariable : BaseVariable<char>
    {
    } 
}