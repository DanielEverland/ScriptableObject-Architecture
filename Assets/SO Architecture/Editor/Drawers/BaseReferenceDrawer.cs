using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Type = System.Type;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomPropertyDrawer(typeof(BaseReference), true)]
    public sealed class BaseReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private static readonly string[] popupOptions =
        {
            "Use Constant",
            "Use Variable"
        };

        private const float MultilineThreshold = 20;

        // Property Names
        private const string VARIABLE_PROPERTY_NAME = "_variable";
        private const string CONSTANT_VALUE_PROPERTY_NAME = "_constantValue";
        private const string USE_CONSTANT_VALUE_PROPERTY_NAME = "_useConstant";

        // Warnings
        private const string COULD_NOT_FIND_VALUE_FIELD_WARNING_FORMAT =
            "Could not find FieldInfo for [{0}] specific property drawer on type [{1}].";

        private Type ValueType { get { return BaseReferenceHelper.GetValueType(fieldInfo); } }
        private bool SupportsMultiLine { get { return SOArchitecture_EditorUtility.SupportsMultiLine(ValueType); } }

        private SerializedProperty property;
        private SerializedProperty useConstant;
        private SerializedProperty constantValue;
        private SerializedProperty variable;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Get properties
            this.property = property;
            useConstant = property.FindPropertyRelative("_useConstant");
            constantValue = property.FindPropertyRelative("_constantValue");
            variable = property.FindPropertyRelative("_variable");
                        
            int oldIndent = ResetIndent();

            Rect fieldRect = DrawLabel(position, property, label);
            Rect valueRect = DrawField(position, fieldRect);
            DrawValue(position, valueRect);
            
            EndIndent(oldIndent);
            
            property.serializedObject.ApplyModifiedProperties();
        }
        private bool IsConstantValueMultiline(SerializedProperty property)
        {
            return GenericPropertyDrawer.GetHeight(property, ValueType) > MultilineThreshold;
        }
        private Rect DrawLabel(Rect position, SerializedProperty property, GUIContent label)
        {
            return EditorGUI.PrefixLabel(position, label);
        }
        private Rect DrawField(Rect position, Rect fieldRect)
        {
            Rect buttonRect = GetPopupButtonRect(fieldRect);
            Rect valueRect = GetValueRect(fieldRect, buttonRect);

            int result = DrawPopupButton(buttonRect, useConstant.boolValue ? 0 : 1);
            useConstant.boolValue = result == 0;

            return valueRect;
        }
        private void DrawValue(Rect position, Rect valueRect)
        {
            if (useConstant.boolValue)
            {
                DrawGenericPropertyField(position, valueRect);
            }
            else
            {
                EditorGUI.PropertyField(valueRect, variable, GUIContent.none);
            }
        }
        private void DrawGenericPropertyField(Rect position, Rect valueRect)
        {
            if (IsConstantValueMultiline(constantValue))
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    position.y += EditorGUIUtility.singleLineHeight;
                    position.height = GenericPropertyDrawer.GetHeight(constantValue, ValueType);

                    GenericPropertyDrawer.DrawPropertyDrawer(position, constantValue, ValueType);
                }                
            }
            else
            {
                GenericPropertyDrawer.DrawPropertyDrawer(valueRect, constantValue, ValueType, false);
            }
        }
        private Rect GetConstantMultilineRect(Rect position, Rect valueRect)
        {
            return new Rect(position.x, valueRect.y + EditorGUIUtility.singleLineHeight, position.width, GenericPropertyDrawer.GetHeight(constantValue, ValueType));
        }
        private Rect GetMultiLineFieldRect(Rect position)
        {
            return EditorGUI.IndentedRect(new Rect
            {
                position = new Vector2(position.x, position.y + EditorGUIUtility.singleLineHeight),
                size = new Vector2(position.width, EditorGUI.GetPropertyHeight(constantValue) + EditorGUIUtility.singleLineHeight)
            });
        }
        private bool ShouldDrawMultiLineField()
        {
            return useConstant.boolValue && SupportsMultiLine && EditorGUI.GetPropertyHeight(constantValue) > EditorGUIUtility.singleLineHeight;
        }
        private int ResetIndent()
        {
            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            return indent;
        }
        private void EndIndent(int indent)
        {
            EditorGUI.indentLevel = indent;
        }
        private int DrawPopupButton(Rect rect, int value)
        {
            return EditorGUI.Popup(rect, value, popupOptions, Styles.PopupStyle);
        }
        private Rect GetValueRect(Rect fieldRect, Rect buttonRect)
        {
            Rect valueRect = new Rect(fieldRect);
            valueRect.x += buttonRect.width;
            valueRect.width -= buttonRect.width;

            return valueRect;
        }
        private Rect GetPopupButtonRect(Rect fieldrect)
        {
            Rect buttonRect = new Rect(fieldrect);
            buttonRect.yMin += Styles.PopupStyle.margin.top;
            buttonRect.width = Styles.PopupStyle.fixedWidth + Styles.PopupStyle.margin.right;
            buttonRect.height = Styles.PopupStyle.fixedHeight + Styles.PopupStyle.margin.top;

            return buttonRect;
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty useConstant = property.FindPropertyRelative(USE_CONSTANT_VALUE_PROPERTY_NAME);
            SerializedProperty constantValue = property.FindPropertyRelative(CONSTANT_VALUE_PROPERTY_NAME);
            
            if (useConstant.boolValue)
            {
                if (IsConstantValueMultiline(constantValue))
                {
                    return GenericPropertyDrawer.GetHeight(constantValue, ValueType) + EditorGUIUtility.singleLineHeight;
                }
                else
                {
                    return EditorGUIUtility.singleLineHeight;
                }
            }

            return EditorGUIUtility.singleLineHeight;
        }
        
        static class Styles
        {
            static Styles()
            {
                PopupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
                {
                    imagePosition = ImagePosition.ImageOnly,
                };
            }

            public static GUIStyle PopupStyle { get; set; }
        }
    }
}