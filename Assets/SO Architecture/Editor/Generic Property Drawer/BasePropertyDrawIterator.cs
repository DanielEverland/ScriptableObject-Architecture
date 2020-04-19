using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScriptableObjectArchitecture.Editor
{
    public abstract class BasePropertyDrawIterator : PropertyIterator, IPropertyDrawIterator
    {
        public BasePropertyDrawIterator(SerializedProperty property, bool drawLabel) : base(property)
        {
            this.drawLabel = drawLabel;
            this.startIndentLevel = EditorGUI.indentLevel;
            this.startDepth = iterator.depth;
        }

        protected readonly bool drawLabel;
        protected readonly int startIndentLevel;
        protected readonly int startDepth;

        protected abstract void DrawProperty();
        protected abstract void DrawPropertyWithLabel();

        public virtual void Draw()
        {
            EditorGUI.indentLevel = GetIndent(iterator.depth);

            if (IsCustom(iterator))
            {
                if (drawLabel)
                {
                    DrawPropertyWithLabel();
                }
                else
                {
                    DrawProperty();
                }
            }
            else
            {
                if(drawLabel)
                {
                    DrawPropertyWithLabel();
                }
                else
                {
                    DrawProperty();
                }
            }
        }
        public override void End()
        {
            base.End();

            EditorGUI.indentLevel = startIndentLevel;
        }
        private int GetIndent(int depth)
        {
            return startIndentLevel + (depth - startDepth);
        }
        private bool IsCustom(SerializedProperty property)
        {
            return property.propertyType == SerializedPropertyType.Generic;
        }
    } 
}
