using UnityEngine;

[CreateAssetMenu(
    fileName = "UnsignedIntVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "Unsigned Int",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]

public sealed class UIntVariable : BaseVariable<uint>
{

}
