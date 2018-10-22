using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(RuntimeSet<>), true)]
public class RuntimeSetEditor : Editor
{
    private SOArchitectureBaseObject Target { get { return (SOArchitectureBaseObject)target; } }
    private SerializedProperty DeveloperDescription { get { return serializedObject.FindProperty("DeveloperDescription"); } }
    
    public override void OnInspectorGUI()
    {
        //EditorGUILayout.HelpBox("Cannot inspect sets. They're meant to contain runtime-data only, and assets cannot have those assigned through the editor", MessageType.Info);

        EditorGUILayout.PropertyField(DeveloperDescription);
    }
}