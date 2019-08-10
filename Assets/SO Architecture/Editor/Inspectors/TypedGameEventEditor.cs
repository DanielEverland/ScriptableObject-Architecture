using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using Type = System.Type;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(GameEventBase<>), true)]
    public class TypedGameEventEditor : BaseGameEventEditor
    {
        private MethodInfo _raiseMethod;

        protected override void OnEnable()
        {
            base.OnEnable();

            _raiseMethod = target.GetType().BaseType.GetMethod(nameof(GameEventBase.Raise), BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
        }

        protected virtual void DrawDebugValue(SerializedProperty property)
        {
            EditorGUILayout.PropertyField(property);
        }

        protected override void DrawRaiseButton()
        {
            SerializedProperty property = serializedObject.FindProperty("_debugValue");
            DrawDebugValue(property);


            if (GUILayout.Button("Raise"))
            {
                CallMethod(GetDebugValue(property));
            }
        }
        protected object GetDebugValue(SerializedProperty property)
        {
            Type targetType = property.serializedObject.targetObject.GetType();
            FieldInfo targetField = targetType.GetField("_debugValue", BindingFlags.Instance | BindingFlags.NonPublic);
            return targetField.GetValue(property.serializedObject.targetObject);
        }
        protected virtual void CallMethod(object value)
        {
            _raiseMethod.Invoke(target, new object[1] { value });
        }
    }
}