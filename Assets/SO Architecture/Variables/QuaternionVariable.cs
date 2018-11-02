using UnityEngine;

[CreateAssetMenu(
    fileName = "QuaternionVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Structs/Quaternion",
    order = 120)]
public sealed class QuaternionVariable : BaseVariable<Quaternion>
{
}