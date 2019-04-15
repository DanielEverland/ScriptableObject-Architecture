using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "UnsignedShortGameEvent.asset",
        menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "ushort",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 18)]
    public sealed class UShortGameEvent : GameEventBase<ushort>
    {
    } 
}