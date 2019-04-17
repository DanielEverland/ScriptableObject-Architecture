using ScriptableObjectArchitecture;
using UnityEngine;

namespace PR_Test_Content
{
    public class SceneReferenceExample : MonoBehaviour
    {
        [SerializeField]
        private SceneReference _sceneReference;

        [SerializeField]
        private SceneReference[] _sceneReferences;

        [SerializeField]
        private IntReference _intReference;

        [SerializeField]
        private IntReference[] _intReferences;
    }
}
