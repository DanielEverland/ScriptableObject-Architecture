using UnityEditor;

namespace ScriptableObjectArchitecture.Editor
{
    public abstract class BaseGameEventEditor : UnityEditor.Editor
    {
        private IStackTraceObject Target { get { return (IStackTraceObject)target; } }

        private StackTrace _stackTrace;

        protected abstract void DrawRaiseButton();

        protected virtual void OnEnable()
        {
            _stackTrace = new StackTrace(Target);
            _stackTrace.OnRepaint.AddListener(Repaint);
        }
        public override void OnInspectorGUI()
        {
            DrawRaiseButton();

            if (!SOArchitecturePreferences.IsDebugEnabled)
                EditorGUILayout.HelpBox("Debug mode disabled\nStack traces will not be filed on raise!", MessageType.Warning);

            _stackTrace.Draw();
        }
    }
}