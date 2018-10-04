using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "SignedByteGameEvent.asset",
    menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "Signed Byte",
    order = SOArchitecture_Utility.ADVANCED_ASSET_MENU_ORDER)]
public sealed class SByteGameEvent : GameEventBase<sbyte>
{
}