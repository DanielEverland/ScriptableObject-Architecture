using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableObjectArchitecture.Editor
{
    public static class GenericPropertyDrawer
    {
        private const string VALUE_LABEL = "Value";

        private static GUIContent ValueGUIContent
        {
            get
            {
                if (_valueGUIContent == null)
                {
                    _valueGUIContent = new GUIContent(VALUE_LABEL);
                }

                return _valueGUIContent;
            }
        }

        private static GUIContent _valueGUIContent;

        /// <summary>
        /// Draws a property drawer using the <see cref="EditorGUI"/> methods and the area the drawer is drawn
        /// in is determined by the passed <see cref="Rect"/> <paramref name="rect"/>.
        /// </summary>
        public static void DrawPropertyDrawer(Rect rect, Type type, SerializedProperty property, GUIContent errorLabel, bool drawValueLabel = false)
        {
            GUIContent label = drawValueLabel ? ValueGUIContent : GUIContent.none;

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
                    property.quaternionValue = EditorGUI.Vector4Field(
                        rect,
                        label,
                        property.quaternionValue.ToVector4()).ToQuaternion();
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

        /// <summary>
        /// Draws a property drawer using the <see cref="EditorGUILayout"/> methods.
        /// </summary>
        public static void DrawPropertyDrawerLayout(Type type, SerializedProperty property, GUIContent errorLabel, bool drawValueLabel = false)
        {
            GUIContent label = drawValueLabel ? ValueGUIContent : GUIContent.none;

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
                    property.quaternionValue = EditorGUILayout.Vector4Field(
                        label,
                        property.quaternionValue.ToVector4()).ToQuaternion();
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

        /// <summary>
        /// Returns true if the passed <see cref="Type"/> <paramref name="type"/> should be displayed on
        /// single line regardless of whether <see cref="EditorGUI.GetPropertyHeight(SerializedProperty)"/>
        /// says otherwise.
        /// </summary>
        public static bool IsSingleLineGUIType(Type type)
        {
            return type.IsAssignableFrom(typeof(Vector4)) ||
                   type.IsAssignableFrom(typeof(Quaternion));
        }
    }
}
