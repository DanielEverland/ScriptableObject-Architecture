using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "UnsignedIntGameEvent.asset",
    menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "Unsigned Int",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class UIntGameEvent : GameEvent
{
    [SerializeField]
    private UIntReference _value;

    public uint Value { get { return _value; } }
}