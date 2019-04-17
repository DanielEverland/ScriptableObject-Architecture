using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PR_Test_Content
{
    public class LoadSceneOnAwake : MonoBehaviour
    {
        public SceneReference sceneReference;

        private void Awake()
        {
            if (sceneReference.Value.IsSceneEnabled && sceneReference.Value.IsSceneInBuildSettings)
            {
                SceneManager.LoadScene(sceneReference.Value.SceneName, LoadSceneMode.Additive);
            }
        }
    }
}