using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomPropertyDrawer(typeof(Quaternion))]
    public class QuaternionDrawer : PropertyDrawer
    {
        private const float Height = 20;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Vector4 vector = property.quaternionValue.ToVector4();

            EditorGUI.Vector4Field(position, label, vector);

            property.quaternionValue = new Quaternion(vector.x, vector.y, vector.z, vector.w);
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return Height;
        }
    }
}