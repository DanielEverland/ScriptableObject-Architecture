using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    public abstract class BaseGameEventListenerEditor : UnityEditor.Editor
    {
        private IStackTraceObject Target { get { return (IStackTraceObject)target; } }

        private StackTrace _stackTrace;
        private SerializedProperty _event;
        private SerializedProperty _debugColor;
        private SerializedProperty _response;
        private SerializedProperty _enableDebug;
        private SerializedProperty _showDebugFields;

        protected abstract void DrawRaiseButton();

        protected virtual void OnEnable()
        {
            _stackTrace = new StackTrace(Target, true);
            _stackTrace.OnRepaint.AddListener(Repaint);

            _event = serializedObject.FindProperty("_event");
            _debugColor = serializedObject.FindProperty("_debugColor");
            _response = serializedObject.FindProperty("_response");
            _enableDebug = serializedObject.FindProperty("_enableGizmoDebugging");
            _showDebugFields = serializedObject.FindProperty("_showDebugFields");
        }
        public override void OnInspectorGUI()
        {
            EditorGUILayout.ObjectField(_event, new GUIContent("Event", "Event which will trigger the response"));
            EditorGUILayout.PropertyField(_response, new GUIContent("Response"));

            _showDebugFields.boolValue = EditorGUILayout.Foldout(_showDebugFields.boolValue, new GUIContent("Show Debug Fields"));
            if (_showDebugFields.boolValue)
            {
                DrawDebugging();
            }

            serializedObject.ApplyModifiedProperties();
        }
        private void DrawDebugging()
        {
            EditorGUILayout.LabelField("Callback Debugging", EditorStyles.boldLabel);
            using (new EditorGUI.IndentLevelScope())
            {
                DrawRaiseButton();

                _stackTrace.Draw();
            }


            EditorGUILayout.Space();
            EditorGUILayout.Space();


            EditorGUILayout.LabelField("Gizmo Debugging", EditorStyles.boldLabel);
            using (new EditorGUI.IndentLevelScope())
            {
                EditorGUILayout.PropertyField(_enableDebug, new GUIContent("Enable Gizmo Debugging"));

                using (new EditorGUI.DisabledGroupScope(_enableDebug.boolValue))
                {
                    EditorGUILayout.PropertyField(_debugColor, new GUIContent("Debug Color", "Color used to draw debug gizmos in the scene"));
                }
            }


            EditorGUILayout.Space();
        }
    } 
}