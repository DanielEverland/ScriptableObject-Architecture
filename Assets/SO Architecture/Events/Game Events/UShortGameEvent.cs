using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "UnsignedShortGameEvent.asset",
    menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "Unsigned Short",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class UShortGameEvent : GameEvent
{
    [SerializeField]
    private ushort _value;

    public ushort Value { get { return _value; } }
}