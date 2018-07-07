using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "ByteGameEvent.asset",
    menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "Byte",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class ByteGameEvent : GameEvent
{
    [SerializeField]
    private ByteReference _value;

    public byte Value { get { return _value; } }
}