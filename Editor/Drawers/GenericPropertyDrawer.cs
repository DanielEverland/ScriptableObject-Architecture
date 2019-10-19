using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableObjectArchitecture.Editor
{
    public static class GenericPropertyDrawer
    {
        public static void DrawPropertyDrawer(Rect rect, GUIContent label, Type type, SerializedProperty property, GUIContent errorLabel)
        {
            if (SOArchitecture_EditorUtility.HasPropertyDrawer(type) || typeof(Object).IsAssignableFrom(type) || type.IsEnum)
            {
                //Unity doesn't like it when you have scene objects on assets,
                //so we do some magic to display it anyway
                if (typeof(Object).IsAssignableFrom(type)
                    && !EditorUtility.IsPersistent(property.objectReferenceValue)
                    && property.objectReferenceValue != null)
                {
                    using (new EditorGUI.DisabledGroupScope(true))
                    {
                        EditorGUI.ObjectField(rect, label, property.objectReferenceValue, type, false);
                    }
                }
                else if (type.IsAssignableFrom(typeof(Quaternion)))
                {
                    Vector4 displayValue = property.quaternionValue.ToVector4();

                    property.quaternionValue = EditorGUI.Vector4Field(rect, label, displayValue).ToQuaternion();
                }
                else if (type.IsAssignableFrom(typeof(Vector4)))
                {
                    property.vector4Value = EditorGUI.Vector4Field(rect, label, property.vector4Value);
                }
                else
                {
                    EditorGUI.PropertyField(rect, property, label);
                }
            }
            else
            {
                EditorGUI.LabelField(rect, errorLabel);
            }
        }
        
        public static void DrawPropertyDrawerLayout(Type type, GUIContent label, SerializedProperty property, GUIContent errorLabel)
        {
            if (SOArchitecture_EditorUtility.HasPropertyDrawer(type) || typeof(Object).IsAssignableFrom(type) || type.IsEnum)
            {
                //Unity doesn't like it when you have scene objects on assets,
                //so we do some magic to display it anyway
                if (typeof(Object).IsAssignableFrom(type)
                    && !EditorUtility.IsPersistent(property.objectReferenceValue)
                    && property.objectReferenceValue != null)
                {
                    using (new EditorGUI.DisabledGroupScope(true))
                    {
                        EditorGUILayout.ObjectField(label, property.objectReferenceValue, type, false);
                    }
                }
                else if (type.IsAssignableFrom(typeof(Quaternion)))
                {
                    Vector4 displayValue = property.quaternionValue.ToVector4();

                    property.quaternionValue = EditorGUILayout.Vector4Field(label, displayValue).ToQuaternion();
                }
                else if (type.IsAssignableFrom(typeof(Vector4)))
                {
                    property.vector4Value = EditorGUILayout.Vector4Field(label, property.vector4Value);
                }
                else
                {
                    EditorGUILayout.PropertyField(property, label);
                }
            }
            else
            {
                EditorGUILayout.LabelField(errorLabel);
            }
        }
    }
}
