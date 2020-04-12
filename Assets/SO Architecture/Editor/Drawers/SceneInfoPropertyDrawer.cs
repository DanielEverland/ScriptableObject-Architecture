using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomPropertyDrawer(typeof(SceneInfo))]
    internal sealed class SceneInfoPropertyDrawer : PropertyDrawer
    {
        private const string SCENE_PREVIEW_TITLE = "Preview (Read-Only)";
        private const string SCENE_NAME_PROPERTY = "_sceneName";
        private const string SCENE_INDEX_PROPERTY = "_sceneIndex";
        private const string SCENE_ENABLED_PROPERTY = "_isSceneEnabled";
        private const int FIELD_COUNT = 5;

        public override void OnGUI(Rect propertyRect, SerializedProperty property, GUIContent label)
        {
            var sceneNameProperty = property.FindPropertyRelative(SCENE_NAME_PROPERTY);
            var sceneIndexProperty = property.FindPropertyRelative(SCENE_INDEX_PROPERTY);
            var enabledProperty = property.FindPropertyRelative(SCENE_ENABLED_PROPERTY);

            EditorGUI.BeginProperty(propertyRect, new GUIContent(property.displayName), property);
            EditorGUI.BeginChangeCheck();

            // Draw Object Selector for SceneAssets
            var sceneAssetRect = new Rect
            {
                position = propertyRect.position,
                size = new Vector2(propertyRect.width, EditorGUIUtility.singleLineHeight)
            };

            var oldSceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(sceneNameProperty.stringValue);
            var sceneAsset = EditorGUI.ObjectField(sceneAssetRect, oldSceneAsset, typeof(SceneAsset), false);
            var sceneAssetPath = AssetDatabase.GetAssetPath(sceneAsset);
            if (sceneNameProperty.stringValue != sceneAssetPath)
            {
                sceneNameProperty.stringValue = sceneAssetPath;
            }

            if (string.IsNullOrEmpty(sceneNameProperty.stringValue))
            {
                sceneIndexProperty.intValue = -1;
                enabledProperty.boolValue = false;
            }

            // Draw preview fields for scene information.
            var titleLabelRect = sceneAssetRect;
            titleLabelRect.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.LabelField(titleLabelRect, SCENE_PREVIEW_TITLE);
            EditorGUI.BeginDisabledGroup(true);
            var nameRect = titleLabelRect;
            nameRect.y += EditorGUIUtility.singleLineHeight;

            var indexRect = nameRect;
            indexRect.y += EditorGUIUtility.singleLineHeight;

            var enabledRect = indexRect;
            enabledRect.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(nameRect, sceneNameProperty);
            EditorGUI.PropertyField(indexRect, sceneIndexProperty);
            EditorGUI.PropertyField(enabledRect, enabledProperty);
            EditorGUI.EndDisabledGroup();
            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * FIELD_COUNT + ((FIELD_COUNT - 1) * EditorGUIUtility.standardVerticalSpacing);
        }
    }
}