using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(BaseVariable<>), true)]
public class BaseVariableEditor : Editor
{
    private BaseVariable Target { get { return (BaseVariable)target; } }

    private SerializedProperty _valueProperty;
    private SerializedProperty _developerDescription;
    private SerializedProperty _readOnly;
    private SerializedProperty _raiseWarning;
    private AnimBool _raiseWarningAnimation;

    private const string READONLY_TOOLTIP = "Should this value be changable during runtime? Will still be editable in the inspector regardless";

    protected virtual void OnEnable()
    {
        _valueProperty = serializedObject.FindProperty("_value");
        _developerDescription = serializedObject.FindProperty("DeveloperDescription");
        _readOnly = serializedObject.FindProperty("_readOnly");
        _raiseWarning = serializedObject.FindProperty("_raiseWarning");

        _raiseWarningAnimation = new AnimBool(_readOnly.boolValue);
        _raiseWarningAnimation.valueChanged.AddListener(Repaint);
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        DrawValue();
        DrawReadonlyField();
        DrawDeveloperDescription();
    }
    protected void DrawValue()
    {
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
    }
    protected void DrawReadonlyField()
    {
        EditorGUILayout.PropertyField(_readOnly, new GUIContent("Read Only", READONLY_TOOLTIP));

        _raiseWarningAnimation.target = _readOnly.boolValue;
        using (var fadeGroup = new EditorGUILayout.FadeGroupScope(_raiseWarningAnimation.faded))
        {
            if (fadeGroup.visible)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(_raiseWarning);
                EditorGUI.indentLevel--;
            }
        }
    }
    protected void DrawDeveloperDescription()
    {
        EditorGUILayout.PropertyField(_developerDescription);
    }
}