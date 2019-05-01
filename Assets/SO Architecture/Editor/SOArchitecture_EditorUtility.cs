using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using Type = System.Type;

namespace ScriptableObjectArchitecture.Editor
{
    public static class SOArchitecture_EditorUtility
    {
        static SOArchitecture_EditorUtility()
        {
            //We use this as a default since it'll be Assembly-CSharp-Editor
            _defaultTargetType = typeof(SOArchitecture_EditorUtility).Assembly;

            CreateDebugStyle();
        }
        
        /// <summary>
        /// A debug <see cref="GUIStyle"/> that allows for identification of EditorGUI Rect issues.
        /// </summary>
        public static GUIStyle DebugStyle { get; private set; }
        private const float DebugStyleBackgroundAlpha = 0.33f;
        
        private static PropertyDrawerGraph _propertyDrawerGraph;
        private static Assembly _defaultTargetType;
        private static BindingFlags _fieldBindingsFlag = BindingFlags.Instance | BindingFlags.NonPublic;

        private static void CreateDebugStyle()
        {
            DebugStyle = new GUIStyle();

            Color debugColor = Color.magenta;
            debugColor.a = DebugStyleBackgroundAlpha;

            DebugStyle.normal.background = CreateTexture(2, 2, debugColor);
        }
        public static bool HasPropertyDrawer(Type type)
        {
            return HasPropertyDrawer(type, _defaultTargetType);
        }
        public static bool HasPropertyDrawer(Type type, Assembly assembly)
        {
            if (HasBuiltinPropertyDrawer(type))
                return true;

            if (_propertyDrawerGraph == null)
                _propertyDrawerGraph = new PropertyDrawerGraph();

            _propertyDrawerGraph.CreateGraph(assembly);

            return _propertyDrawerGraph.HasPropertyDrawer(type);
        }
        private static bool HasBuiltinPropertyDrawer(Type type)
        {
            if (type.IsPrimitive || type == typeof(string) || IsFromUnityAssembly(type))
                return true;

            return false;
        }
        private static bool IsFromUnityAssembly(Type type)
        {
            return type.Assembly == typeof(GameObject).Assembly;
        }
        [DidReloadScripts]
        private static void OnProjectReloaded()
        {
            _propertyDrawerGraph = null;
        }
        private static Texture2D CreateTexture(int width, int height, Color col)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; ++i)
            {
                pix[i] = col;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }

        /// <summary>
        /// Goes through the entirety of the project and collects data about custom property drawers
        /// </summary>
        private class PropertyDrawerGraph
        {
            private List<Type> _supportedTypes = new List<Type>();
            private List<Type> _supportedInheritedTypes = new List<Type>();
            private List<Assembly> _checkedAssemblies = new List<Assembly>();

            public bool HasPropertyDrawer(Type type)
            {
                foreach (Type supportedType in _supportedTypes)
                {
                    if (supportedType == type)
                        return true;
                }

                foreach (Type inheritedSupportedType in _supportedInheritedTypes)
                {
                    if (type.IsSubclassOf(inheritedSupportedType))
                        return true;
                }

                return false;
            }
            public void CreateGraph(Assembly assembly)
            {
                if (_checkedAssemblies.Contains(assembly))
                    return;

                _checkedAssemblies.Add(assembly);

                foreach (Type type in assembly.GetTypes())
                {
                    object[] attributes = type.GetCustomAttributes(typeof(CustomPropertyDrawer), false);

                    foreach (object attribute in attributes)
                    {
                        if (attribute is CustomPropertyDrawer)
                        {
                            CustomPropertyDrawer drawerData = attribute as CustomPropertyDrawer;

                            bool useForChildren = (bool)typeof(CustomPropertyDrawer).GetField("m_UseForChildren", _fieldBindingsFlag).GetValue(drawerData);
                            Type targetType = (Type)typeof(CustomPropertyDrawer).GetField("m_Type", _fieldBindingsFlag).GetValue(drawerData);

                            if (useForChildren)
                            {
                                _supportedInheritedTypes.Add(targetType);
                            }
                            else
                            {
                                _supportedTypes.Add(targetType);
                            }
                        }
                    }
                }
            }
        }
    }
}