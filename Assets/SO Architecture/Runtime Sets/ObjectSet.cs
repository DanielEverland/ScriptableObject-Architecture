using UnityEngine;

[CreateAssetMenu(
    fileName = "ObjectSet.asset",
    menuName = SOArchitecture_Utility.OBJECT_SETS,
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public class ObjectSet : Collection<Object>
{
}