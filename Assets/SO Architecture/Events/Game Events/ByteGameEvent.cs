using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "ByteGameEvent.asset",
        menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "byte",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 6)]
    public sealed class ByteGameEvent : GameEventBase<byte>
    {
    } 
}