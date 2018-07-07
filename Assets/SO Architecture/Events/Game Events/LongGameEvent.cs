using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "LongGameEvent.asset",
    menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "Long",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class LongGameEvent : GameEvent
{
    [SerializeField]
    private long _value;

    public long Value { get { return _value; } }
}