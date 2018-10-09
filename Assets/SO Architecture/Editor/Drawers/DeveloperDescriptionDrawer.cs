using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(DeveloperDescription))]
public class DeveloperDescriptionDrawer : PropertyDrawer
{
    private SerializedProperty _property;
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        this._property = property;
        
        DrawTitle();
        DrawTextArea();

        property.serializedObject.ApplyModifiedProperties();
    }
    private void DrawTitle()
    {
        EditorGUILayout.LabelField(new GUIContent("Description", "Click below this field to add a description"));
    }
    private void DrawTextArea()
    {
        SerializedProperty stringValue = _property.FindPropertyRelative("_value");
        
        Vector2 fieldSize = Styles.TextAreaStyle.CalcSize(new GUIContent(stringValue.stringValue));
        Rect textAreaRect = GUILayoutUtility.GetRect(fieldSize.x, fieldSize.y);


        EditorGUI.indentLevel++;

        stringValue.stringValue = EditorGUI.TextArea(textAreaRect, stringValue.stringValue, Styles.TextAreaStyle);

        EditorGUI.indentLevel--;


        HandleInput(textAreaRect);
    }
    private void HandleInput(Rect textAreaRect)
    {
        Event e = Event.current;
        
        if(e.type == EventType.MouseDown)
        {
            if (!textAreaRect.Contains(e.mousePosition))
                RemoveFocus();
        }
        else if(e.type == EventType.KeyDown || e.type == EventType.KeyUp)
        {
            if (Event.current.keyCode == (KeyCode.Escape))
            {
                RemoveFocus();
            }
        }
    }
    private void RemoveFocus()
    {
        GUI.FocusControl(null);
        Repaint();
    }
    private void Repaint()
    {
        EditorUtility.SetDirty(_property.serializedObject.targetObject);
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