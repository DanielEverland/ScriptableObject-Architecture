using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "QuaternionGameEvent.asset",
    menuName = SOArchitecture_Utility.GAME_EVENT + "Structs/Quaternion",
    order = 120)]
public sealed class QuaternionGameEvent : GameEventBase<Quaternion>
{
}