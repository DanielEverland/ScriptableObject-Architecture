using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ClampedVariable<,,>), true)]
public class ClampedVariableEditor : BaseVariableEditor
{
    private SerializedProperty _minValueProperty;
    private SerializedProperty _maxValueProperty;

    protected override void OnEnable()
    {
        base.OnEnable();

        _minValueProperty = serializedObject.FindProperty("_minClampedValue");
        _maxValueProperty = serializedObject.FindProperty("_maxClampedValue");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();


        DrawValue();
        DrawClampedFields();
        DrawDeveloperDescription();

        serializedObject.ApplyModifiedProperties();
    }
    private void DrawClampedFields()
    {
        using (new EditorGUI.IndentLevelScope())
        {
            EditorGUILayout.PropertyField(_minValueProperty);
            EditorGUILayout.PropertyField(_maxValueProperty);
        }
    }
}