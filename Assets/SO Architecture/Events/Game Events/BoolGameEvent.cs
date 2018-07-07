using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "BoolGameEvent.asset",
    menuName = SOArchitecture_Utility.GAME_EVENT + "Bool",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public sealed class BoolGameEvent : GameEvent
{
    [SerializeField]
    private bool _value;

    public bool Value { get { return _value; } }
}
