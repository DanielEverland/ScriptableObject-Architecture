using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "CharGameEvent.asset",
    menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "Char",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class CharGameEvent : GameEvent
{
    [SerializeField]
    private CharReference _value;

    public char Value { get { return _value; } }
}
