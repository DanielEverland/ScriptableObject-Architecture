using UnityEngine;

[CreateAssetMenu(
    fileName = "GameObjectVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "GameObject",
    order = 120)]
public sealed class GameObjectVariable : BaseVariable<GameObject>
{
}