using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "FloatGameEvent.asset",
    menuName = SOArchitecture_Utility.GAME_EVENT + "Float",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public sealed class FloatGameEvent : GameEvent {

    [SerializeField]
    private FloatReference _value;

    public float Value { get { return _value; } }
}
