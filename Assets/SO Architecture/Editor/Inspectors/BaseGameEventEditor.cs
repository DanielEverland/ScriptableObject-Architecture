using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

public abstract class BaseGameEventEditor : Editor
{
    private IStackTraceObject Target { get { return (IStackTraceObject)target; } }    
    private SerializedProperty DeveloperDescrption { get { return serializedObject.FindProperty("DeveloperDescription"); } }

    private StackTrace _stackTrace;

    protected abstract void DrawRaiseButton();

    protected virtual void OnEnable()
    {
        _stackTrace = new StackTrace(Target);
        _stackTrace.OnRepaint.AddListener(Repaint);
    }
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginDisabledGroup(!Application.isPlaying);
            DrawRaiseButton();
        EditorGUI.EndDisabledGroup();
                
        _stackTrace.Draw();

        SOArchitectureBaseObjectEditor.DrawDescription(DeveloperDescrption);
    }
}