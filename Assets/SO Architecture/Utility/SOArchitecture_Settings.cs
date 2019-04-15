using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public class SOArchitecture_Settings : ScriptableObject
    {
        #region Singleton
        public static SOArchitecture_Settings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = GetInstance();

                return _instance;
            }
        }
        private static SOArchitecture_Settings _instance;

        private static SOArchitecture_Settings GetInstance()
        {
            SOArchitecture_Settings instance = Resources.Load<SOArchitecture_Settings>("SOArchitecture_Settings");

            if (instance == null)
                return CreateInstance();

            return instance;
        }
        private static SOArchitecture_Settings CreateInstance()
        {
#if UNITY_EDITOR
            SOArchitecture_Settings newSettings = SOArchitecture_Settings.CreateInstance<SOArchitecture_Settings>();

            if (!UnityEditor.AssetDatabase.IsValidFolder("Assets/Resources"))
                UnityEditor.AssetDatabase.CreateFolder("Assets", "Resources");

            UnityEditor.AssetDatabase.CreateAsset(newSettings, "Assets/Resources/SOArchitecture_Settings.asset");
            UnityEditor.AssetDatabase.SaveAssets();

            UnityEditor.Selection.activeObject = newSettings;

            Debug.LogWarning("No SOArchitecture_Settings asset found! Creating new one, ensure it's locatable by Resources", newSettings);

            return newSettings;
#else
        throw new System.NullReferenceException();
#endif
        }
        #endregion

        public bool DrawEventGizmos { get { return _drawEventGizmos; } }
        public string CodeGenerationTargetDirectory { get { return _codeGenerationTargetDirectory; } }
        public bool CodeGenerationAllowOverwrite { get { return _codeGenerationAllowOverwrite; } }
        public int DefaultCreateAssetMenuOrder { get { return _defualtCreateAssetMenuOrder; } }

        [SerializeField]
        private bool _drawEventGizmos = true;
        [SerializeField]
        private string _codeGenerationTargetDirectory = "CODE_GENERATION";
        [SerializeField, Tooltip("Allow newly generated code files to overwrite existing ones")]
        private bool _codeGenerationAllowOverwrite = false;
        [SerializeField]
        private int _defualtCreateAssetMenuOrder = 120;
    }
}