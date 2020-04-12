using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableObjectArchitecture.Editor
{
    public static class GenericPropertyDrawer
    {
        private const string DefaultErrorLabelText = "Type is not drawable! Please implement property drawer";

        public static void DrawPropertyDrawerNew(Rect rect, SerializedProperty property, bool drawLabel = true)
        {
            property = property.Copy();

            DrawIterator iter = new DrawIterator(rect, property, drawLabel);
            if (property.Next(true))
            {
                while (iter.Next())
                {
                    iter.Draw();
                }

                iter.End();
            }
        }
        public static float GetHeight(SerializedProperty property)
        {
            property = property.Copy();

            int elements = 0;
            
            Iterator iter = new Iterator(property);
            if (property.Next(true))
            {
                while (iter.Next())
                {
                    ++elements;
                }

                iter.End();
            }

            float spacing = (elements - 1) * EditorGUIUtility.standardVerticalSpacing;
            float elementHeights = elements * EditorGUIUtility.singleLineHeight;

            return spacing + elementHeights;
        }

        private class Iterator
        {
            public Iterator(SerializedProperty property)
            {
                iterator = property.Copy();
                endProperty = iterator.GetEndProperty();
            }

            protected readonly SerializedProperty iterator;
            protected readonly SerializedProperty endProperty;

            private bool consumeChildren;
            private int parentDepth;

            public bool Next()
            {
                bool nextVisible = iterator.NextVisible(true);
                bool canDraw = CanDraw();

                if (nextVisible)
                {
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
                } while (iterator.depth != depth);
            }
            private bool IsSingleLine(SerializedProperty property)
            {
                switch (property.propertyType)
                {
                    case SerializedPropertyType.Vector3:
                    case SerializedPropertyType.Vector2:
                    case SerializedPropertyType.Vector3Int:
                    case SerializedPropertyType.Vector2Int:
                    case SerializedPropertyType.Rect:
                    case SerializedPropertyType.RectInt:
                    case SerializedPropertyType.Bounds:
                    case SerializedPropertyType.BoundsInt:
                        return true;
                }

                return false;
            }
        }
        private class DrawIterator : Iterator
        {
            public DrawIterator(Rect rect, SerializedProperty property, bool drawLabel) : base(property)
            {
                this.drawLabel = drawLabel;
                this.rect = rect;
                this.rect.height = EditorGUIUtility.singleLineHeight;
                startIndentLevel = EditorGUI.indentLevel;
                startDepth = iterator.depth;
            }

            private readonly bool drawLabel;
            private readonly int startIndentLevel;

            private int startDepth;
            private Rect rect;
            

            public void Draw()
            {
                EditorGUI.indentLevel = GetIndent(iterator.depth);

                if (IsCustom(iterator))
                {
                    DrawHeader();
                }
                else
                {
                    DrawValue();
                }

                rect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }


            public override void End()
            {
                base.End();

                EditorGUI.indentLevel = startIndentLevel;
            }
            private void DrawHeader()
            {
                EditorGUI.LabelField(rect, iterator.displayName);
                
            }
            private void DrawValue()
            {
                if(drawLabel)
                {
                    EditorGUI.PropertyField(rect, iterator);
                }
                else
                {
                    EditorGUI.PropertyField(rect, iterator, GUIContent.none);
                }               
            }
            
            private int GetIndent(int depth)
            {
                // Depth starts at 1, whereas indent starts at 0. So we subtract 1
                return startIndentLevel + (depth - startDepth) - 1;
            }
            private Rect GetFieldRect()
            {
                return new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight);
            }
            private void NextLine()
            {
                rect.y += EditorGUIUtility.singleLineHeight * 3;
            }
            
            
            private bool IsCustom(SerializedProperty property)
            {
                return property.propertyType == SerializedPropertyType.Generic;
            }
        }



        public static void DrawPropertyDrawer(Rect rect, GUIContent label, Type type, SerializedProperty property, GUIContent errorLabel)
        {
            if (errorLabel == GUIContent.none)
                errorLabel = GetDefaultErrorLabel();

            Debug.Log(type);
            if (IsDrawable(type))
            {
                Debug.Log(1);
                //Unity doesn't like it when you have scene objects on assets,
                //so we do some magic to display it anyway
                if (typeof(Object).IsAssignableFrom(type)
                    && !EditorUtility.IsPersistent(property.objectReferenceValue)
                    && property.objectReferenceValue != null)
                {
                    Debug.Log(2);
                    using (new EditorGUI.DisabledGroupScope(true))
                    {
                        EditorGUI.ObjectField(rect, label, property.objectReferenceValue, type, false);
                    }
                }
                else if (TryDrawBuiltinType(rect, label, type, property))
                {
                    Debug.Log(3);
                }
                else
                {
                    Debug.Log(4);
                    EditorGUI.PropertyField(rect, property, label);
                }
            }
            else
            {
                Debug.Log(5);
                EditorGUI.LabelField(rect, errorLabel);
            }
        }

        private static bool TryDrawBuiltinType(Rect rect, GUIContent label, Type type, SerializedProperty property)
        {
            if(typeof(Color).IsAssignableFrom(type))
            {
                EditorGUI.ColorField(rect, property.colorValue);
                return true;
            }
            else if(typeof(AnimationCurve).IsAssignableFrom(type))
            {
                EditorGUI.CurveField(rect, property.animationCurveValue);
                return true;
            }
            else if(typeof(double).IsAssignableFrom(type))
            {
                EditorGUI.DoubleField(rect, property.doubleValue);
                return true;
            }
            else if(typeof(float).IsAssignableFrom(type))
            {
                EditorGUI.FloatField(rect, property.floatValue);
                return true;
            }
            else if(typeof(int).IsAssignableFrom(type))
            {
                EditorGUI.IntField(rect, property.intValue);
                return true;
            }
            else if(typeof(string).IsAssignableFrom(type))
            {
                EditorGUI.TextField(rect, property.stringValue);
                return true;
            }
            else if(typeof(long).IsAssignableFrom(type))
            {
                EditorGUI.LongField(rect, property.longValue);
                return true;
            }
            else if(typeof(bool).IsAssignableFrom(type))
            {
                EditorGUI.Toggle(rect, property.boolValue);
                return true;
            }
            else if(typeof(Vector2).IsAssignableFrom(type))
            {
                EditorGUI.Vector2Field(rect, label, property.vector2Value);
                return true;
            }
            else if(typeof(Vector3).IsAssignableFrom(type))
            {
                EditorGUI.Vector3Field(rect, label, property.vector3Value);
                return true;
            }
            else if(typeof(Vector4).IsAssignableFrom(type))
            {
                EditorGUI.Vector4Field(rect, label, property.vector4Value);
                return true;
            }
            else if(typeof(Quaternion).IsAssignableFrom(type))
            {
                EditorGUI.Vector4Field(rect, label, property.quaternionValue.ToVector4());
                return true;
            }

            return false;
        }
        
        public static void DrawPropertyDrawerLayout(Type type, GUIContent label, SerializedProperty property, GUIContent errorLabel)
        {
            if (IsDrawable(type))
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
                    Vector4 displayValue = property.quaternionValue.ToVector4();

                    property.quaternionValue = EditorGUILayout.Vector4Field(label, displayValue).ToQuaternion();
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

        private static bool IsDrawable(Type type)
        {
            return SOArchitecture_EditorUtility.HasPropertyDrawer(type) || typeof(Object).IsAssignableFrom(type) || type.IsEnum;
        }

        private static GUIContent GetDefaultErrorLabel()
        {
            return new GUIContent(DefaultErrorLabelText);
        }
    }
}
