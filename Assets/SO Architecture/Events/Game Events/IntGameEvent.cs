using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "IntGameEvent.asset",
    menuName = SOArchitecture_Utility.GAME_EVENT + "Integer",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public sealed class IntGameEvent : GameEventBase<int>
{
}