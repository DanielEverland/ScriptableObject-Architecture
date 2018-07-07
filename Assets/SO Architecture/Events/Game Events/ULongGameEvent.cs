using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "UnsignedLongGameEvent.asset",
    menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "Unsigned Long",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class ULongGameEvent : GameEvent
{
    [SerializeField]
    private ULongReference _value;

    public ulong Value { get { return _value; } }
}