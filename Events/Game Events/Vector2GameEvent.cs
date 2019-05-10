using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "Vector2GameEvent.asset",
        menuName = SOArchitecture_Utility.GAME_EVENT + "Structs/Vector2",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 10)]
    public sealed class Vector2GameEvent : GameEventBase<Vector2>
    {
    } 
}