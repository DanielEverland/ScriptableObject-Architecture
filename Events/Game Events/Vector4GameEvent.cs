using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "Vector4GameEvent.asset",
        menuName = SOArchitecture_Utility.GAME_EVENT + "Structs/Vector4",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 12)]
    public sealed class Vector4GameEvent : GameEventBase<Vector4>
    {
    } 
}