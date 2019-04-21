using UnityEditor;
using UnityEngine;
using UnityEditorInternal;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(BaseCollection), true)]
    public class CollectionEditor : UnityEditor.Editor
    {
        private BaseCollection Target { get { return (BaseCollection)target; } }
        private SerializedProperty DeveloperDescriptionProperty
        {
            get { return serializedObject.FindProperty(DESCRIPTION_PROPERTY_NAME); }
        }
        private SerializedProperty CollectionItemsProperty
        {
            get { return serializedObject.FindProperty(LIST_PROPERTY_NAME);}
        }

        private ReorderableList _reorderableList;

        // UI
        private const bool DISABLE_ELEMENTS = false;
        private const bool ELEMENT_DRAGGABLE = true;
        private const bool LIST_DISPLAY_HEADER = true;
        private const bool LIST_DISPLAY_ADD_BUTTON = true;
        private const bool LIST_DISPLAY_REMOVE_BUTTON = true;

        private GUIContent _titleGUIContent;
        private GUIContent _noPropertyDrawerWarningGUIContent;

        private const string TITLE_FORMAT = "List ({0})";
        private const string NO_PROPERTY_WARNING_FORMAT = "No PropertyDrawer for type [{0}]";

        // Property Names
        private const string LIST_PROPERTY_NAME = "_list";
        private const string DESCRIPTION_PROPERTY_NAME = "DeveloperDescription";

        private void OnEnable()
        {
            _titleGUIContent = new GUIContent(string.Format(TITLE_FORMAT, Target.Type));
            _noPropertyDrawerWarningGUIContent = new GUIContent(string.Format(NO_PROPERTY_WARNING_FORMAT, Target.Type));

            _reorderableList = new ReorderableList(
                serializedObject,
                CollectionItemsProperty,
                ELEMENT_DRAGGABLE,
                LIST_DISPLAY_HEADER,
                LIST_DISPLAY_ADD_BUTTON,
                LIST_DISPLAY_REMOVE_BUTTON)
            {
                drawHeaderCallback = DrawHeader,
                drawElementCallback = DrawElement,
                elementHeightCallback = GetElementHeight,
                onRemoveCallback = Remove
            };
        }
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            _reorderableList.DoLayoutList();

            EditorGUILayout.PropertyField(DeveloperDescriptionProperty);

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
        private void DrawHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, _titleGUIContent);
        }
        private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty property = CollectionItemsProperty.GetArrayElementAtIndex(index);

            EditorGUI.BeginDisabledGroup(DISABLE_ELEMENTS);

            GenericPropertyDrawer.DrawPropertyDrawer(rect, Target.Type, property, _noPropertyDrawerWarningGUIContent);

            EditorGUI.EndDisabledGroup();
        }

        /// <summary>
        /// Return the height of the item in the <see cref="ReorderableList"/> that is being drawn.
        /// </summary>
        /// <param name="index">The index of the item in the list being drawn.</param>
        /// <returns></returns>
        private float GetElementHeight(int index)
        {
            var indexedItemProperty = CollectionItemsProperty.GetArrayElementAtIndex(index);
            return GenericPropertyDrawer.IsSingleLineGUIType(Target.Type)
                ? EditorGUIUtility.singleLineHeight
                : EditorGUI.GetPropertyHeight(indexedItemProperty);
        }
        private void Remove(ReorderableList list)
        {
            Target.List.RemoveAt(list.index);
        }
    }
}