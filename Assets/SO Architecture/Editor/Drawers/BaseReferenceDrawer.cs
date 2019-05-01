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

        // Property Names
        private const string VARIABLE_PROPERTY_NAME = "_variable";
        private const string CONSTANT_VALUE_PROPERTY_NAME = "_constantValue";
        private const string USE_CONSTANT_VALUE_PROPERTY_NAME = "_useConstant";

        // Warnings
        private const string COULD_NOT_FIND_VALUE_FIELD_WARNING_FORMAT =
            "Could not find FieldInfo for [{0}] specific property drawer on type [{1}].";

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
            DrawField(position, fieldRect);

            EndIndent(oldIndent);
            
            property.serializedObject.ApplyModifiedProperties();
        }
        private Rect DrawLabel(Rect position, SerializedProperty property, GUIContent label)
        {
            return EditorGUI.PrefixLabel(position, label);
        }
        private void DrawField(Rect position, Rect fieldRect)
        {
            Rect buttonRect = GetPopupButtonRect(fieldRect);
            Rect valueRect = GetValueRect(fieldRect, buttonRect);

            int result = DrawPopupButton(buttonRect, useConstant.boolValue ? 0 : 1);
            useConstant.boolValue = result == 0;

            DrawValue(position, valueRect);
        }
        private void DrawValue(Rect position, Rect valueRect)
        {
            if (ShouldDrawMultiLineField())
            {
                valueRect = GetMultiLineFieldRect(position);
                GUI.Box(valueRect, string.Empty);
            }

            if (useConstant.boolValue)
            {
                DrawGenericPropertyField(valueRect);
            }
            else
            {
                EditorGUI.PropertyField(valueRect, variable, GUIContent.none);
            }
        }
        private void DrawGenericPropertyField(Rect valueRect)
        {
            Type genericReferenceType = GetReferenceGenericType(constantValue);
            if (genericReferenceType != null)
            {
                GenericPropertyDrawer.DrawPropertyDrawer(valueRect, genericReferenceType, constantValue, GUIContent.none);
            }
            else
            {
                Debug.LogWarningFormat(
                    property.objectReferenceValue,
                    COULD_NOT_FIND_VALUE_FIELD_WARNING_FORMAT,
                    CONSTANT_VALUE_PROPERTY_NAME,
                    GetReferenceType(constantValue));
            }
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
            return useConstant.boolValue && SupportsMultiLine(constantValue) && EditorGUI.GetPropertyHeight(constantValue) > EditorGUIUtility.singleLineHeight;
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
            if (SupportsMultiLine(property.FindPropertyRelative(CONSTANT_VALUE_PROPERTY_NAME)))
            {
                SerializedProperty useConstant = property.FindPropertyRelative(USE_CONSTANT_VALUE_PROPERTY_NAME);
                var constantPropertyHeight = EditorGUI.GetPropertyHeight(property.FindPropertyRelative(CONSTANT_VALUE_PROPERTY_NAME));
                return !useConstant.boolValue || constantPropertyHeight <= EditorGUIUtility.singleLineHeight
                    ? EditorGUIUtility.singleLineHeight
                    : EditorGUIUtility.singleLineHeight * 2 + constantPropertyHeight;
            }
            else
            {
                return base.GetPropertyHeight(property, label);
            }
        }

        public bool SupportsMultiLine(SerializedProperty property)
        {
            return SupportsMultiLine(GetReferenceGenericType(property));
        }
        public bool SupportsMultiLine(Type type)
        {
            return type.GetCustomAttributes(typeof(MultiLine), true).Length > 0;
        }

        public Type GetReferenceType(SerializedProperty property)
        {
            return SerializedPropertyHelper.GetParent(property).GetType();
        }

        public Type GetReferenceGenericType(SerializedProperty property)
        {
            var referenceObject = SerializedPropertyHelper.GetParent(property);
            var valueFieldInfo = referenceObject.GetType().GetField(
                CONSTANT_VALUE_PROPERTY_NAME,
                BindingFlags.Instance | BindingFlags.NonPublic);

            return valueFieldInfo == null ? null : valueFieldInfo.FieldType;
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