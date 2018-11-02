using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "Vector2GameEvent.asset",
    menuName = SOArchitecture_Utility.GAME_EVENT + "Structs/Vector2",
    order = 120)]
public sealed class Vector2GameEvent : GameEventBase<Vector2>
{
}