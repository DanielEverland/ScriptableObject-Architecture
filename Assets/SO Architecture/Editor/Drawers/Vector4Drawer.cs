using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomPropertyDrawer(typeof(Vector4))]
    public class Vector4Drawer : PropertyDrawer
    {
        private const float Height = 20;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.vector4Value = EditorGUI.Vector4Field(position, label, property.vector4Value);
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return Height;
        }
    }
}
