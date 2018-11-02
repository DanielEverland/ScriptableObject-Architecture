using UnityEngine;

[CreateAssetMenu(
    fileName = "ObjectCollection.asset",
    menuName = SOArchitecture_Utility.OBJECT_SETS,
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public class ObjectCollection : Collection<Object>
{
}