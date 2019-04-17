using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomPropertyDrawer(typeof(BaseReference), true)]
    public class BaseReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private static readonly string[] popupOptions =
        {
        "Use Constant",
        "Use Variable"
        };

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
            SerializedProperty useConstant = property.FindPropertyRelative("_useConstant");
            SerializedProperty constantValue = property.FindPropertyRelative("_constantValue");
            SerializedProperty variable = property.FindPropertyRelative("_variable");

            // Calculate rect for configuration button
            Rect buttonRect = new Rect(refValuePosition);
            buttonRect.yMin += PopupStyle.margin.top;
            buttonRect.yMax = buttonRect.yMin + EditorGUIUtility.singleLineHeight;
            buttonRect.width = PopupStyle.fixedWidth + PopupStyle.margin.right;
            refValuePosition.xMin = buttonRect.xMax;

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

            EditorGUI.PropertyField(refValuePosition,
                useConstant.boolValue ? constantValue : variable,
                GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty useConstant = property.FindPropertyRelative("_useConstant");
            return !useConstant.boolValue
                ? EditorGUIUtility.singleLineHeight
                : EditorGUIUtility.singleLineHeight * 2f +
                  EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_constantValue"));
        }
    }
}