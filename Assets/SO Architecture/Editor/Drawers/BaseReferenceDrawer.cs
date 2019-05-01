using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

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

        /// <summary>
        /// Cached style to use to draw the popup button. Lazy loaded as GUIStyles cannot be initialized as
        /// an inline static field.
        /// </summary>
        private static GUIStyle PopupStyle
        {
            get
            {
                if (_popupStyle == null)
                {
                    _popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
                    {
                        imagePosition = ImagePosition.ImageOnly
                    };
                }

                return _popupStyle;
            }
        }

        private static GUIStyle _popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            var refValuePosition = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            // Get properties
            SerializedProperty useConstant = property.FindPropertyRelative(USE_CONSTANT_VALUE_PROPERTY_NAME);
            SerializedProperty constantValue = property.FindPropertyRelative(CONSTANT_VALUE_PROPERTY_NAME);
            SerializedProperty variable = property.FindPropertyRelative(VARIABLE_PROPERTY_NAME);

            // Calculate rect for configuration button
            Rect buttonRect = new Rect
            {
                position = refValuePosition.position,
                size = new Vector2(30f, refValuePosition.height)
            };
            buttonRect.yMin += PopupStyle.margin.top;
            buttonRect.yMax = buttonRect.yMin + EditorGUIUtility.singleLineHeight;
            refValuePosition.position = new Vector2(refValuePosition.x + buttonRect.width, refValuePosition.y);
            refValuePosition.size = new Vector2(refValuePosition.width - buttonRect.width, refValuePosition.height);

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, popupOptions, PopupStyle);

            useConstant.boolValue = result == 0;

            if (useConstant.boolValue && EditorGUI.GetPropertyHeight(constantValue) > EditorGUIUtility.singleLineHeight)
            {
                refValuePosition = EditorGUI.IndentedRect(new Rect
                {
                    position = new Vector2(position.x, position.y + EditorGUIUtility.singleLineHeight),
                    size = new Vector2(position.width, EditorGUI.GetPropertyHeight(constantValue) +
                                                       EditorGUIUtility.singleLineHeight)
                });
                GUI.Box(refValuePosition, string.Empty);
            }

            if (useConstant.boolValue)
            {
                var genericReferenceType = GetReferenceGenericType(constantValue);
                if (genericReferenceType != null)
                {
                    GenericPropertyDrawer.DrawPropertyDrawer(refValuePosition, genericReferenceType, constantValue, GUIContent.none);
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
            else
            {
                EditorGUI.PropertyField(refValuePosition, variable, GUIContent.none);
            }

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty useConstant = property.FindPropertyRelative(USE_CONSTANT_VALUE_PROPERTY_NAME);
            var constantPropertyHeight = EditorGUI.GetPropertyHeight(property.FindPropertyRelative(CONSTANT_VALUE_PROPERTY_NAME));
            return !useConstant.boolValue || constantPropertyHeight <= EditorGUIUtility.singleLineHeight
                ? EditorGUIUtility.singleLineHeight
                : EditorGUIUtility.singleLineHeight * 2 + constantPropertyHeight;
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
    }
}