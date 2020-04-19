using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomPropertyDrawer(typeof(Quaternion))]
    public class QuaternionDrawer : PropertyDrawer
    {
        private const int ElementsInQuaternion = 4;
        private const float ElementLabelWidth = 13;
        private const float ElementSpacing = 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (HasLabel(label))
            {
                Rect labelRect = GetLabelRect(position);
                Rect valueRect = GetValueRect(position);

                EditorGUI.LabelField(labelRect, label);
                DrawValue(valueRect, property);
            }
            else
            {
                DrawValue(position, property);
            }
        }
        private void DrawValue(Rect rect, SerializedProperty property)
        {
            float oldLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = ElementLabelWidth;

            Quaternion quaternion = property.quaternionValue;            

            quaternion.x = DrawElement(GetElementRect(rect, 0), quaternion.x, new GUIContent("X"));
            quaternion.y = DrawElement(GetElementRect(rect, 1), quaternion.y, new GUIContent("Y"));
            quaternion.z = DrawElement(GetElementRect(rect, 2), quaternion.z, new GUIContent("Z"));
            quaternion.w = DrawElement(GetElementRect(rect, 3), quaternion.w, new GUIContent("W"));

            property.quaternionValue = quaternion;
            EditorGUIUtility.labelWidth = oldLabelWidth;
        }
        private float DrawElement(Rect rect, float value, GUIContent label)
        {
            return EditorGUI.FloatField(rect, label, value);
        }
        private Rect GetElementRect(Rect parentRect, int index)
        {
            float widthPerElement = parentRect.width / ElementsInQuaternion;

            return new Rect()
            {
                x = parentRect.x + widthPerElement * index,
                y = parentRect.y,
                width = widthPerElement - ElementSpacing,
                height = parentRect.height,
            };
        }
        private Rect GetLabelRect(Rect parentRect)
        {
            return new Rect()
            {
                x = parentRect.x,
                y = parentRect.y,
                width = EditorGUIUtility.labelWidth,
                height = parentRect.height,
            };
        }
        private Rect GetValueRect(Rect parentRect)
        {
            return new Rect()
            {
                x = parentRect.x + EditorGUIUtility.labelWidth + ElementSpacing,
                y = parentRect.y,
                width = parentRect.width - EditorGUIUtility.labelWidth,
                height = parentRect.height,
            };
        }
        private bool HasLabel(GUIContent label)
        {
            return label != GUIContent.none;
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}