using UnityEngine;

[System.Serializable]
[CreateAssetMenu(
    fileName = "ObjectGameEvent.asset",
    menuName = SOArchitecture_Utility.GAME_EVENT + "Object",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public class ObjectGameEvent : GameEventBase<Object>
{
}