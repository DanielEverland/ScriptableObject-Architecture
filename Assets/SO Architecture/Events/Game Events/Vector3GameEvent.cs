using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "Vector3GameEvent.asset",
    menuName = SOArchitecture_Utility.GAME_EVENT + "Structs/Vector3",
    order = 120)]
public sealed class Vector3GameEvent : GameEventBase<Vector3>
{
}