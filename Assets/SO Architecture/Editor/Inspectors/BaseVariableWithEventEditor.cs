using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(BaseVariableWithEvent<,>), true)]
    public class BaseVariableWithEventEditor : BaseVariableEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("_event"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}