using UnityEngine;
using UnityEditor;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomPropertyDrawer(typeof(DeveloperDescription))]
    public class DeveloperDescriptionDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return GetHeight(property);
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            DrawTitle(ref position, property);
            DrawTextArea(ref position, property);

            property.serializedObject.ApplyModifiedProperties();
        }
        private void DrawTitle(ref Rect rect, SerializedProperty property)
        {
            if (HasContent(property))
            {
                rect.height = 0;
            }

            EditorGUI.LabelField(rect, new GUIContent("Description", "Click below this field to add a description"));
        }
        private void DrawTextArea(ref Rect rect, SerializedProperty property)
        {
            SerializedProperty stringValue = property.FindPropertyRelative("_value");

            if (!HasContent(property))
                rect.y += EditorGUIUtility.singleLineHeight;

            rect.height = GetHeight(property);

            EditorGUI.indentLevel++;
            stringValue.stringValue = EditorGUI.TextArea(rect, stringValue.stringValue, Styles.TextAreaStyle);
            EditorGUI.indentLevel--;

            HandleInput(rect, property);
        }
        private void HandleInput(Rect textAreaRect, SerializedProperty property)
        {
            Event e = Event.current;

            if (e.type == EventType.MouseDown)
            {
                if (!textAreaRect.Contains(e.mousePosition))
                    RemoveFocus(property);
            }
            else if (e.type == EventType.KeyDown || e.type == EventType.KeyUp)
            {
                if (Event.current.keyCode == (KeyCode.Escape))
                {
                    RemoveFocus(property);
                }
            }
        }
        private void RemoveFocus(SerializedProperty property)
        {
            GUI.FocusControl(null);
            Repaint(property);
        }
        private void Repaint(SerializedProperty property)
        {
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        }
        private static bool HasContent(SerializedProperty property)
        {
            string content = GetContent(property);

            return content != "" && content != string.Empty;
        }
        private static string GetContent(SerializedProperty property)
        {
            return property.FindPropertyRelative("_value").stringValue;
        }
        private static float GetHeight(SerializedProperty property)
        {
            string content = GetContent(property);

            if (!HasContent(property))
            {
                return EditorGUIUtility.singleLineHeight * 2;
            }
            else
            {
                return Styles.TextAreaStyle.CalcHeight(new GUIContent(content), Screen.width);
            }
        }
        private static class Styles
        {
            public static GUIStyle TextAreaStyle;

            static Styles()
            {
                TextAreaStyle = new GUIStyle(EditorStyles.textArea);
                TextAreaStyle.normal = EditorStyles.label.normal;
            }
        }
    }
}