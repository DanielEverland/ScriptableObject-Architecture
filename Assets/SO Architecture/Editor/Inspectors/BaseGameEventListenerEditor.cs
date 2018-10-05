using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BaseGameEventListenerEditor : Editor
{
    private IStackTraceObject Target { get { return (IStackTraceObject)target; } }
    private SerializedProperty DeveloperDescrption { get { return serializedObject.FindProperty("DeveloperDescription"); } }

    private StackTrace _stackTrace;
    
    protected virtual void OnEnable()
    {
        _stackTrace = new StackTrace(Target);
        _stackTrace.OnRepaint.AddListener(Repaint);
    }
    public override void OnInspectorGUI()
    {
        //EditorGUILayout.Space();

        _stackTrace.Draw();

        //SOArchitectureBaseObjectEditor.DrawDescription(DeveloperDescrption);
    }
}