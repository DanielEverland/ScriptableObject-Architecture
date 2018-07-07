using UnityEngine;

[CreateAssetMenu(
    fileName = "ByteVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "Byte",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]

public sealed class ByteVariable : BaseVariable<byte>
{

}
