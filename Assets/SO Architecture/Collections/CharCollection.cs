using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "CharCollection.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_COLLECTION + "char",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 7)]
    public class CharCollection : Collection<char>
    {
    } 
}