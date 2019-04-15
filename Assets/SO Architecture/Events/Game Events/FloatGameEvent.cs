using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "FloatGameEvent.asset",
        menuName = SOArchitecture_Utility.GAME_EVENT + "float",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 3)]
    public sealed class FloatGameEvent : GameEventBase<float>
    {
    } 
}