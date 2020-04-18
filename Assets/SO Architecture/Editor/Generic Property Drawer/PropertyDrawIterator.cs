using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScriptableObjectArchitecture.Editor
{
    public class PropertyDrawIterator : BasePropertyDrawIterator
    {
        public PropertyDrawIterator(Rect rect, SerializedProperty property, bool drawLabel) : base(property, drawLabel)
        {
            this.rect = rect;
            this.rect.height = EditorGUIUtility.singleLineHeight;
        }

        private Rect rect;

        public override void Draw()
        {
            base.Draw();

            MoveRectDownOneLine();
        }

        protected override void DrawPropertyWithLabel()
        {
            EditorGUI.PropertyField(rect, iterator);
        }
        protected override void DrawProperty()
        {
            EditorGUI.PropertyField(rect, iterator, GUIContent.none);
        }

        private void MoveRectDownOneLine()
        {
            rect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        }
    }
}
