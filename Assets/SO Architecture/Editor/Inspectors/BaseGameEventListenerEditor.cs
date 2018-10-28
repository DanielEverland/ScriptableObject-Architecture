using UnityEditor;
using UnityEngine;

public abstract class BaseGameEventListenerEditor : Editor
{
    private IStackTraceObject Target { get { return (IStackTraceObject)target; } }
    private SerializedProperty DeveloperDescription { get { return serializedObject.FindProperty("DeveloperDescription"); } }

    private StackTrace _stackTrace;
    private SerializedProperty _event;
    private SerializedProperty _debugColor;
    private SerializedProperty _response;
    private SerializedProperty _enableDebug;

    protected abstract void DrawRaiseButton();

    protected virtual void OnEnable()
    {
        _stackTrace = new StackTrace(Target, true);
        _stackTrace.OnRepaint.AddListener(Repaint);

        _event = serializedObject.FindProperty("_event");
        _debugColor = serializedObject.FindProperty("_debugColor");
        _response = serializedObject.FindProperty("_response");
        _enableDebug = serializedObject.FindProperty("_enableDebug");
    }
    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(_enableDebug);

        EditorGUILayout.ObjectField(_event, new GUIContent("Event", "Event which will trigger the response"));
        _debugColor.colorValue = EditorGUILayout.ColorField(new GUIContent("Debug Color", "Color used to draw debug gizmos in the scene"), _debugColor.colorValue);

        EditorGUILayout.PropertyField(_response, new GUIContent("Response"));

        DrawRaiseButton();

        _stackTrace.Draw();
        
        EditorGUILayout.PropertyField(DeveloperDescription);

        serializedObject.ApplyModifiedProperties();
    }
}