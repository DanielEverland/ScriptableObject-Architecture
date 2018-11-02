using UnityEngine;

[CreateAssetMenu(
    fileName = "GameObjectCollection.asset",
    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "GameObject",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public class GameObjectCollection : Collection<GameObject>
{
}
