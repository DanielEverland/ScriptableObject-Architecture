using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "QuaternionVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Structs/Quaternion",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 13)]
    public sealed class QuaternionVariable : BaseVariable<Quaternion>
    {
    } 
}