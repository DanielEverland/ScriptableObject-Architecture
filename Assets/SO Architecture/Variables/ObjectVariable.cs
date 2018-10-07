using UnityEngine;

[CreateAssetMenu(
    fileName = "ObjectVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Object",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public class ObjectVariable : BaseVariable<Object>
{
}