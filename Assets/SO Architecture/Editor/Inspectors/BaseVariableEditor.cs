using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(BaseVariable<>), true)]
    public class BaseVariableEditor : UnityEditor.Editor
    {
        private BaseVariable Target { get { return (BaseVariable)target; } }
        protected bool IsClampable { get { return Target.Clampable; } }
        protected bool IsClamped { get { return Target.IsClamped; } }

        private SerializedProperty _valueProperty;
        private SerializedProperty _developerDescription;
        private SerializedProperty _readOnly;
        private SerializedProperty _raiseWarning;
        private SerializedProperty _isClamped;
        private SerializedProperty _minValueProperty;
        private SerializedProperty _maxValueProperty;
        private AnimBool _raiseWarningAnimation;
        private AnimBool _isClampedVariableAnimation;

        private const string READONLY_TOOLTIP = "Should this value be changable during runtime? Will still be editable in the inspector regardless";

        protected virtual void OnEnable()
        {
            _valueProperty = serializedObject.FindProperty("_value");
            _developerDescription = serializedObject.FindProperty("DeveloperDescription");
            _readOnly = serializedObject.FindProperty("_readOnly");
            _raiseWarning = serializedObject.FindProperty("_raiseWarning");
            _isClamped = serializedObject.FindProperty("_isClamped");
            _minValueProperty = serializedObject.FindProperty("_minClampedValue");
            _maxValueProperty = serializedObject.FindProperty("_maxClampedValue");

            _raiseWarningAnimation = new AnimBool(_readOnly.boolValue);
            _raiseWarningAnimation.valueChanged.AddListener(Repaint);

            _isClampedVariableAnimation = new AnimBool(_isClamped.boolValue);
            _isClampedVariableAnimation.valueChanged.AddListener(Repaint);
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawValue();
            DrawClampedFields();
            DrawReadonlyField();
            DrawDeveloperDescription();
        }
        protected virtual void DrawValue()
        {
            using (var scope = new EditorGUI.ChangeCheckScope())
            {
                string content = "Cannot display value. No PropertyDrawer for (" + Target.Type + ") [" + Target.ToString() + "]";
                GenericPropertyDrawer.DrawPropertyDrawerLayout(Target.Type, _valueProperty, new GUIContent(content, content));

                if (scope.changed)
                {
                    // Value changed, raise events
                    Target.Raise();
                }
            }
        }
        protected void DrawClampedFields()
        {
            if (!IsClampable)
                return;

            EditorGUILayout.PropertyField(_isClamped);
            _isClampedVariableAnimation.target = _isClamped.boolValue;

            using (var anim = new EditorGUILayout.FadeGroupScope(_isClampedVariableAnimation.faded))
            {
                if(anim.visible)
                {
                    using (new EditorGUI.IndentLevelScope())
                    {
                        EditorGUILayout.PropertyField(_minValueProperty);
                        EditorGUILayout.PropertyField(_maxValueProperty);
                    }
                }                
            }
            
        }
        protected void DrawReadonlyField()
        {
            if (IsClampable)
                return;

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
}