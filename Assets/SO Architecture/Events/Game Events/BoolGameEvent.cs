using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "BoolGameEvent.asset",
        menuName = SOArchitecture_Utility.GAME_EVENT + "bool",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 5)]
    public sealed class BoolGameEvent : GameEventBase<bool>
    {
    } 
}