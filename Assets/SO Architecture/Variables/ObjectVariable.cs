using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "ObjectVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Object",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 1)]
    public class ObjectVariable : BaseVariable<Object>
    {
    } 
}