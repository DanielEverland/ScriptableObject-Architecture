using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "StringGameEvent.asset",
    menuName = SOArchitecture_Utility.GAME_EVENT + "String",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public sealed class StringGameEvent : GameEvent
{
    [SerializeField]
    private StringReference _value;

    public string Value { get { return _value; } }
}