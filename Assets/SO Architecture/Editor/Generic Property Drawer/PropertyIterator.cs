using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScriptableObjectArchitecture.Editor
{
    public class PropertyIterator : IPropertyIterator
    {
        public PropertyIterator(SerializedProperty property)
        {
            iterator = property;
            Next();
            
            endProperty = iterator.GetEndProperty();
        }

        protected readonly SerializedProperty iterator;
        protected readonly SerializedProperty endProperty;

        private bool consumeChildren;
        private int parentDepth;

        public virtual bool Next()
        {
            bool nextVisible = iterator.NextVisible(true);
            bool canDraw = CanDraw();

            if (nextVisible)
            {
                if (IsScriptField(iterator))
                    nextVisible = NextVisible();

                if (consumeChildren)
                {
                    ConsumeSingleLineFields(parentDepth);
                    consumeChildren = false;
                }

                int depth = iterator.depth;
                if (IsSingleLine(iterator))
                {
                    parentDepth = depth;
                    consumeChildren = true;
                }
            }

            return nextVisible && canDraw;
        }
        public virtual void End()
        {
        }
        private bool CanDraw()
        {
            return !SerializedProperty.EqualContents(iterator, endProperty);
        }
        private void ConsumeSingleLineFields(int depth)
        {
            do
            {
                iterator.Next(true);
            }
            while (iterator.depth != depth);
        }
        private bool IsSingleLine(SerializedProperty property)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.Vector3:
                case SerializedPropertyType.Vector2:
                case SerializedPropertyType.Vector3Int:
                case SerializedPropertyType.Vector2Int:
                case SerializedPropertyType.Vector4:
                case SerializedPropertyType.Quaternion:
                case SerializedPropertyType.Rect:
                case SerializedPropertyType.RectInt:
                case SerializedPropertyType.Bounds:
                case SerializedPropertyType.BoundsInt:
                    return true;
            }

            return false;
        }
        private bool IsScriptField(SerializedProperty property)
        {
            return property.propertyPath == "m_Script";
        }
        private bool NextVisible()
        {
            return iterator.NextVisible(true);
        }
    }
}
