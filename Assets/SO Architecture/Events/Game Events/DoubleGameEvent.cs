using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "DoubleGameEvent.asset",
    menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "Double",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class DoubleGameEvent : GameEvent
{
    [SerializeField]
    private double _value;

    public double Value { get { return _value; } }
}