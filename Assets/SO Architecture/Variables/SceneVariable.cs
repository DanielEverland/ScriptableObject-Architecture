using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public class SceneInfoEvent : UnityEvent<SceneInfo> { }

    /// <summary>
    /// <see cref="SceneVariable"/> is a scriptable constant variable whose scene values are assigned at
    /// edit-time by assigning a <see cref="UnityEditor.SceneAsset"/> instance to it.
    /// </summary>
    [CreateAssetMenu(
        fileName = "SceneVariable.asset",
        menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "Scene",
        order = 120)]
    public sealed class SceneVariable : BaseVariable<SceneInfo, SceneInfoEvent>
    {
        /// <summary>
        /// Returns the <see cref="SceneInfo"/> of this instance.
        /// </summary>
        public override SceneInfo Value
        {
            get { return _value; }
        }

        public override bool ReadOnly
        {
            get
            {
                // A scene variable is essentially a constant for edit-time modification only; there is not
                // any kind of expectation for a user to be able to set this at runtime.
                return true;
            }
        }
    }

    [Serializable]
    [MultiLine]
    public sealed class SceneInfo : ISerializationCallbackReceiver
    {
        /// <summary>
        /// Returns the fully-qualified name of the scene.
        /// </summary>
        public string SceneName
        {
            get { return _sceneName; }
        }

        /// <summary>
        /// Returns the index of the scene in the build settings; if not present, -1 will be returned instead.
        /// </summary>
        public int SceneIndex
        {
            get { return _sceneIndex; }
            internal set { _sceneIndex = value; }
        }

        /// <summary>
        /// Returns true if the scene is present in the build settings, otherwise false.
        /// </summary>
        public bool IsSceneInBuildSettings
        {
            get { return _sceneIndex != -1; }
        }

        /// <summary>
        /// Returns true if the scene is enabled in the build settings, otherwise false.
        /// </summary>
        public bool IsSceneEnabled
        {
            get { return _isSceneEnabled; }
            internal set { _isSceneEnabled = value; }
        }

        #if UNITY_EDITOR
        internal UnityEditor.SceneAsset Scene
        {
            get { return UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEditor.SceneAsset>(_sceneName); }
        }
        #endif

        #pragma warning disable 0649

        [SerializeField]
        private string _sceneName;

        [SerializeField]
        private int _sceneIndex;

        [SerializeField]
        private bool _isSceneEnabled;

        #pragma warning restore 0649

        public SceneInfo()
        {
            _sceneIndex = -1;
        }

        #region ISerializationCallbackReceiver

        public void OnBeforeSerialize()
        {
            #if UNITY_EDITOR
            if (Scene != null)
            {
                var sceneAssetPath = UnityEditor.AssetDatabase.GetAssetPath(Scene);
                var sceneAssetGUID = UnityEditor.AssetDatabase.AssetPathToGUID(sceneAssetPath);
                var scenes = UnityEditor.EditorBuildSettings.scenes;

                SceneIndex = -1;
                for (var i = 0; i < scenes.Length; i++)
                {
                    if (scenes[i].guid.ToString() == sceneAssetGUID)
                    {
                        SceneIndex = i;
                        IsSceneEnabled = scenes[i].enabled;
                        break;
                    }
                }
            }
            #endif
        }

        public void OnAfterDeserialize(){}

        #endregion
    }
}
