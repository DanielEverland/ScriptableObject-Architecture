using UnityEngine;

[CreateAssetMenu(
    fileName = "GameObjectCollection.asset",
    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "GameObject",
    order = 150)]
public class GameObjectCollection : Collection<GameObject>
{
}
