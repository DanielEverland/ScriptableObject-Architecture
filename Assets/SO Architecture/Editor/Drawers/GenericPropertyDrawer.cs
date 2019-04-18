using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    public static class GenericPropertyDrawer
    {
        public static void DrawPropertyDrawer(System.Type type, SerializedProperty property, GUIContent errorLabel)
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
