using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "SceneCollection.asset",
        menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Scene",
        order = 120)]
    public class SceneCollection : Collection<SceneVariable>
    {

    }
}