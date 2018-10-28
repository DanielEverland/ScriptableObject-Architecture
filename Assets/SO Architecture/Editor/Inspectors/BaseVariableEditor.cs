using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseVariable<>), true)]
public class BaseVariableEditor : Editor
{
    private BaseVariable Target { get { return (BaseVariable)target; } }

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
            //Unity doesn't like it when you have scene objects on assets,
            //so we do some magic to display it anyway
            if (typeof(Object).IsAssignableFrom(Target.Type)
                && !EditorUtility.IsPersistent(_valueProperty.objectReferenceValue)
                && _valueProperty.objectReferenceValue != null)
            {
                using (new EditorGUI.DisabledGroupScope(true))
                {
                    EditorGUILayout.ObjectField(new GUIContent("Value"), _valueProperty.objectReferenceValue, Target.Type, false);
                }
            }
            else
            {
                EditorGUILayout.PropertyField(_valueProperty);
            }
        }
        else
        {
            string labelContent = "Cannot display value. No PropertyDrawer for (" + Target.Type + ") [" + Target.BaseValue.ToString() + "]";

            EditorGUILayout.LabelField(new GUIContent(labelContent, labelContent));
        }


        EditorGUILayout.PropertyField(_developerDescription);
    }
}