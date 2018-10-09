using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "GameObjectSet.asset",
    menuName = SOArchitecture_Utility.SETS_SUBMENU + "GameObject",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER)]
public class GameObjectSet : RuntimeSet<GameObject>
{
}
