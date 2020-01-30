using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public class CharEvent : UnityEvent<char> { }

    [CreateAssetMenu(
        fileName = "CharVariable.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "char",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 7)]
    public sealed class CharVariable : BaseVariable<char, CharEvent>
    {
    } 
}