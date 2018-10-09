using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseVariable<>), true)]
public class BaseVariableEditor : Editor
{
    private SerializedProperty _valueProperty;
    private SerializedProperty _developerDescription;

    private void OnEnable()
    {
        _valueProperty = serializedObject.FindProperty("_value");
        _developerDescription = serializedObject.FindProperty("DeveloperDescription");
    }
    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(_valueProperty);
        EditorGUILayout.PropertyField(_developerDescription);
    }
}