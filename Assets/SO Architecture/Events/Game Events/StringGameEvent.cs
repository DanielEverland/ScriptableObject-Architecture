using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "StringGameEvent.asset",
    menuName = SOArchitecture_Utility.GAME_EVENT + "String",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public sealed class StringGameEvent : GameEventBase<string>
{
}