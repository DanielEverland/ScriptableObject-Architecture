using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseVariable<>), true)]
public class BaseVariableEditor : Editor
{
    private IBaseVariable Target { get { return (IBaseVariable)target; } }

    private SerializedProperty _valueProperty;
    private SerializedProperty _developerDescription;

    private void OnEnable()
    {
        _valueProperty = serializedObject.FindProperty("_value");
        _developerDescription = serializedObject.FindProperty("DeveloperDescription");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (SOArchitecture_EditorUtility.HasPropertyDrawer(Target.Type))
        {
            EditorGUILayout.PropertyField(_valueProperty);
        }
        else
        {
            EditorGUILayout.LabelField("Cannot display value. No PropertyDrawer for " + Target.Type);
        }

        
        EditorGUILayout.PropertyField(_developerDescription);
    }
}