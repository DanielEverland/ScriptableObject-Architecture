using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "ShortGameEvent.asset",
    menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "Short",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class ShortGameEvent : GameEventBase<short>
{
}