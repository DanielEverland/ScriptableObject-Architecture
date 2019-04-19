using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    public static class GenericPropertyDrawer
    {
        /// <summary>
        /// Draws a property drawer using the <see cref="EditorGUI"/> methods and the area the drawer is drawn
        /// in is determined by the passed <see cref="Rect"/> <paramref name="rect"/>.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="type"></param>
        /// <param name="property"></param>
        /// <param name="errorLabel"></param>
        public static void DrawPropertyDrawer(Rect rect, System.Type type, SerializedProperty property, GUIContent errorLabel)
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
                        EditorGUI.ObjectField(rect, new GUIContent("Value"), property.objectReferenceValue, type, false);
                    }
                }
                else
                {
                    EditorGUI.PropertyField(rect, property);
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
        /// <param name="type"></param>
        /// <param name="property"></param>
        /// <param name="errorLabel"></param>
        public static void DrawPropertyDrawerLayout(System.Type type, SerializedProperty property, GUIContent errorLabel)
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
                        EditorGUILayout.ObjectField(new GUIContent("Value"), property.objectReferenceValue, type, false);
                    }
                }
                else
                {
                    EditorGUILayout.PropertyField(property);
                }
            }
            else
            {
                EditorGUILayout.LabelField(errorLabel);
            }
        }
    }
}
