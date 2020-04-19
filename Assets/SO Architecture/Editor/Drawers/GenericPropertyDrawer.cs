using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableObjectArchitecture.Editor
{
    public static class GenericPropertyDrawer
    {
        private const string DefaultErrorLabelText = "Type is not drawable! Please implement property drawer";
        private const string NullPropertyText = "SerializedProperty is null. Your custom type is probably missing the [Serializable] attribute";

        public static void DrawPropertyDrawer(Rect rect, SerializedProperty property, Type type, bool drawLabel = true)
        {
            if (property == null)
            {
                Debug.LogError(NullPropertyText);
                return;
            }

            if (SOArchitecture_EditorUtility.HasPropertyDrawer(type))
            {
                if(drawLabel)
                {
                    EditorGUI.PropertyField(rect, property);
                }
                else
                {
                    EditorGUI.PropertyField(rect, property, GUIContent.none);
                }
            }
            else
            {
                PropertyDrawIterator iter = new PropertyDrawIterator(rect, property.Copy(), drawLabel);

                DrawPropertyDrawerInternal(iter);
            }
        }
        public static void DrawPropertyDrawerLayout(SerializedProperty property, Type type, bool drawLabel = true)
        {
            if(property == null)
            {
                Debug.LogError(NullPropertyText);
                return;
            }

            if (SOArchitecture_EditorUtility.HasPropertyDrawer(type))
            {
                if (drawLabel)
                {
                    EditorGUILayout.PropertyField(property);
                }
                else
                {
                    EditorGUILayout.PropertyField(property, GUIContent.none);
                }
            }
            else
            {
                PropertyDrawIteratorLayout iter = new PropertyDrawIteratorLayout(property.Copy(), drawLabel);

                DrawPropertyDrawerInternal(iter);
            }
        }
        private static void DrawPropertyDrawerInternal(IPropertyDrawIterator iter)
        {
            do
            {
                iter.Draw();
            }
            while (iter.Next());

            iter.End();
        }
        public static float GetHeight(SerializedProperty property, Type type)
        {
            if (SOArchitecture_EditorUtility.HasPropertyDrawer(type))
            {
                return EditorGUI.GetPropertyHeight(property);
            }
            else
            {
                property = property.Copy();

                int elements = 0;

                PropertyIterator iter = new PropertyIterator(property);
                do
                {
                    ++elements;
                }
                while (iter.Next());

                iter.End();

                float spacing = (elements - 1) * EditorGUIUtility.standardVerticalSpacing;
                float elementHeights = elements * EditorGUIUtility.singleLineHeight;

                return spacing + elementHeights;
            }
        }
    }
}
