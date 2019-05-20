using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "Vector3GameEvent.asset",
        menuName = SOArchitecture_Utility.GAME_EVENT + "Structs/Vector3",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 11)]
    public sealed class Vector3GameEvent : GameEventBase<Vector3>
    {
    } 
}