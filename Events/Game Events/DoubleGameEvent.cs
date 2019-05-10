using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "DoubleGameEvent.asset",
        menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "double",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 8)]
    public sealed class DoubleGameEvent : GameEventBase<double>
    {
    } 
}