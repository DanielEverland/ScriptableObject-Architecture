using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "Vector4GameEvent.asset",
    menuName = SOArchitecture_Utility.GAME_EVENT + "Structs/Vector4",
    order = 120)]
public sealed class Vector4GameEvent : GameEventBase<Vector4>
{
}