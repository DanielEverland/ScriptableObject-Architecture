using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "StringVariable.asset",
        menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "string",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 2)]
    public sealed class StringVariable : BaseVariable<string>
    {
        public override void Awake()
        {
            base.Awake();
            // Evita que o valor seja inicializado como nulo
            Value = "";
        }
    }
}