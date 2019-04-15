using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "FloatVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "float",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 3)]
    public class FloatVariable : BaseVariable<float>
    {
    } 
}