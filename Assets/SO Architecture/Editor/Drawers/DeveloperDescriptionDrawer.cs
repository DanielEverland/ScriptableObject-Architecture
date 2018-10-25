using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(DeveloperDescription))]
public class DeveloperDescriptionDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty stringValue = property.FindPropertyRelative("_value");

        return Styles.TextAreaStyle.CalcSize(new GUIContent("Descriptions\n" + stringValue.stringValue)).y;
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        DrawTitle(ref position);
        DrawTextArea(ref position, property);

        property.serializedObject.ApplyModifiedProperties();
    }
    private void DrawTitle(ref Rect rect)
    {
        EditorGUI.LabelField(rect, new GUIContent("Description", "Click below this field to add a description"));

        rect.y += EditorGUIUtility.singleLineHeight;
    }
    private void DrawTextArea(ref Rect rect, SerializedProperty property)
    {
        SerializedProperty stringValue = property.FindPropertyRelative("_value");
        
        Vector2 fieldSize = Styles.TextAreaStyle.CalcSize(new GUIContent(stringValue.stringValue));
        rect.height = fieldSize.y;

        EditorGUI.indentLevel++;        
            stringValue.stringValue = EditorGUI.TextArea(rect, stringValue.stringValue, Styles.TextAreaStyle);
        EditorGUI.indentLevel--;

        HandleInput(rect, property);
    }
    private void HandleInput(Rect textAreaRect, SerializedProperty property)
    {
        Event e = Event.current;
        
        if(e.type == EventType.MouseDown)
        {
            if (!textAreaRect.Contains(e.mousePosition))
                RemoveFocus(property);
        }
        else if(e.type == EventType.KeyDown || e.type == EventType.KeyUp)
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