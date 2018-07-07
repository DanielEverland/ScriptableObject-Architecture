using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "StringGameEvent.asset",
    menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "String",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class StringGameEvent : GameEvent
{
    [SerializeField]
    private string _value;

    public string Value { get { return _value; } }
}