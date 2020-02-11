#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    /// <summary>
    /// An editor class for managing project and user preferences for the SOArchitecture library. This is kept
    /// in the runtime assembly for the purpose of enabling editor-only additional features when playing such as
    /// gizmos and debugging.
    /// </summary>
    public static class SOArchitecturePreferences
    {
        /// <summary>
        /// Returns true if debug features should be enabled, otherwise false.
        /// </summary>
        public static bool IsDebugEnabled
        {
            get { return GetBoolPref(ENABLE_DEBUG_PREF, ENABLE_DEBUG_DEFAULT); }
        }

        /// <summary>
        /// Returns true if Gizmos should be enabled, otherwise false.
        /// </summary>
        public static bool AreGizmosEnabled
        {
            get { return GetBoolPref(DRAW_EVENT_GIZMOS_PREF, DRAW_EVENT_GIZMOS_DEFAULT); }
        }

        // UI
        private const string PREFERENCES_TITLE_PATH = "Preferences/SOArchitecture";
        private const string PROJECT_TITLE_PATH = "Project/SOArchitecture";

        private const string USER_PREFERENCES_HEADER = "User Preferences";
        private const string PROJECT_REFERENCES_HEADER = "Project Preferences";

        private const string CODE_GEN_DIRECTORY_LABEL = "Code Generation Output Directory";
        private const string CODE_GEN_DIRECTORY_DESCRIPTION
            = "The directory where the output of code generation will write to.";

        private const string ALLOW_OVERWRITE_LABEL = "Allow Code Generation to Overwrite";
        private const string ALLOW_OVERWRITE_DESCRIPTION =
            "Allow newly generated code files to overwrite existing ones.";

        private const string ASSET_MENU_ORDER_LABEL = "Create Asset Menu Order";
        private const string ASSET_MENU_ORDER_DESCRIPTION =
            "This determines the order in which the CreateAsset Context Menu will be placed into.";

        private static readonly GUILayoutOption MAX_WIDTH;

#if UNITY_2018_3_OR_NEWER
        // Searchable Fields
        private static readonly string[] KEYWORDS =
        {
            "Scriptable",
            "Architecture"
        };
#endif

        // User Editor Preferences
        private const string DRAW_EVENT_GIZMOS_PREF = "SOArchitecture.DrawEventGizmoos";
        private const string ENABLE_DEBUG_PREF = "SOArchitecture.EnableDebug";

        private const bool DRAW_EVENT_GIZMOS_DEFAULT = true;
        private const bool ENABLE_DEBUG_DEFAULT = true;

        static SOArchitecturePreferences()
        {
            MAX_WIDTH = GUILayout.MaxWidth(200f);
        }

#if UNITY_2018_3_OR_NEWER
        [SettingsProvider]
        private static SettingsProvider CreateProjectPreferenceSettingsProvider()
        {
            return new SettingsProvider(PROJECT_TITLE_PATH, SettingsScope.Project)
            {
                guiHandler = DrawProjectGUI,
                keywords = KEYWORDS
            };
        }

        [SettingsProvider]
        private static SettingsProvider CreatePersonalPreferenceSettingsProvider()
        {
            return new SettingsProvider(PREFERENCES_TITLE_PATH, SettingsScope.User)
            {
                guiHandler = DrawPersonalPrefsGUI,
                keywords = KEYWORDS
            };
        }
#endif
        private static void DrawAllGUI()
        {
            DrawProjectGUI();
            DrawPersonalPrefsGUI();
        }

        private static void DrawProjectGUI(string value = "")
        {
            EditorGUILayout.LabelField(PROJECT_REFERENCES_HEADER, EditorStyles.boldLabel);

            var settings = SOArchitecture_Settings.Instance;

            GUI.changed = false;

            // Code Generation Target Directory
            EditorGUILayout.HelpBox(CODE_GEN_DIRECTORY_DESCRIPTION, MessageType.Info);
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField(new GUIContent(CODE_GEN_DIRECTORY_LABEL), MAX_WIDTH);
                var directory = EditorGUILayout.TextField(settings.CodeGenerationTargetDirectory);
                settings.CodeGenerationTargetDirectory = directory;
            }

            // Code Generation Allow Overwrite
            EditorGUILayout.HelpBox(ALLOW_OVERWRITE_DESCRIPTION, MessageType.Info);
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField(new GUIContent(ALLOW_OVERWRITE_LABEL), MAX_WIDTH);
                var newOverwrite = EditorGUILayout.Toggle(settings.CodeGenerationAllowOverwrite);
                settings.CodeGenerationAllowOverwrite = newOverwrite;
            }

            // Default Create Asset Menu Order
            EditorGUILayout.HelpBox(ASSET_MENU_ORDER_DESCRIPTION, MessageType.Info);
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField(ASSET_MENU_ORDER_LABEL, MAX_WIDTH);
                var newMenuOrder = EditorGUILayout.IntField(settings.DefaultCreateAssetMenuOrder);
                settings.DefaultCreateAssetMenuOrder = newMenuOrder;
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(settings);
            }
        }

        private static void DrawPersonalPrefsGUI(string value = "")
        {
            EditorGUILayout.LabelField(USER_PREFERENCES_HEADER, EditorStyles.boldLabel);

            // Draw Event Gizmo
            var drawEventPref = GetBoolPref(DRAW_EVENT_GIZMOS_PREF, DRAW_EVENT_GIZMOS_DEFAULT);

            GUI.changed = false;
            drawEventPref = EditorGUILayout.Toggle("Draw Event Gizmo", drawEventPref);
            if (GUI.changed)
            {
                EditorPrefs.SetBool(DRAW_EVENT_GIZMOS_PREF, drawEventPref);
            }

            // Enable Debug
            EditorGUILayout.HelpBox("This will enable debug features for troubleshooting purposes such as " +
                                    "game events collecting stack traces. This will decrease performance " +
                                    "in-editor.", MessageType.Info);
            var enableDebugPref = GetBoolPref(ENABLE_DEBUG_PREF, ENABLE_DEBUG_DEFAULT);

            GUI.changed = false;
            enableDebugPref = EditorGUILayout.Toggle("Enable Debug", enableDebugPref);
            if (GUI.changed)
            {
                EditorPrefs.SetBool(ENABLE_DEBUG_PREF, enableDebugPref);
            }
        }

        /// <summary>
        /// Returns the current bool preference; if none exists, the default is set and returned.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static bool GetBoolPref(string key, bool defaultValue)
        {
            if (!EditorPrefs.HasKey(key))
            {
                EditorPrefs.SetBool(key, defaultValue);
            }

            return EditorPrefs.GetBool(key);
        }
    }
}

#endif
