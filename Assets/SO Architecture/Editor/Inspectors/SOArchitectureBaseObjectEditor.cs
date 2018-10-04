using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SOArchitectureBaseObject), true)]
public class SOArchitectureBaseObjectEditor : Editor {

    private SOArchitectureBaseObject Target { get { return (SOArchitectureBaseObject)target; } }
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Target.DeveloperDescription = DrawDescription(Target.DeveloperDescription);
    }
    public static string DrawDescription(string text)
    {
        string toReturn = text;
        
        EditorGUILayout.LabelField(new GUIContent("Description", "Click below this field to add a description"));

        EditorGUI.indentLevel++;
            toReturn = EditorGUILayout.TextArea(toReturn, Styles.TextAreaStyle);
        EditorGUI.indentLevel--;
        
        return toReturn;
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
