using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    public class SO_CodeGenerationWindow : EditorWindow
    {
        /* --------- DEPENDENCY GRAPH ---------*
         * [1] Game Event Listener
         * [2] Game Event
         * [3] Reference
         * [4] Collection
         * [5] Unity Event
         * [6] Variable
         *
         * /  1  2  3  4  5  6  7
         * 1     X        X
         * 2        X
         * 3                 X
         * 4
         * 5
         * 6
         */

        private readonly bool[,] _dependencyGraph = new bool[SO_CodeGenerator.TYPE_COUNT, SO_CodeGenerator.TYPE_COUNT]
        {
            { false, true, false, false, true, false, },
            { false, false, true, false, false, false, },
            { false, false, false, false, false, true, },
            { false, false, false, false, false, false, },
            { false, false, false, false, false, false, },
            { false, false, false, false, false, false, },
        };

        private readonly bool[] _states = new bool[SO_CodeGenerator.TYPE_COUNT];
        private readonly string[] _names = new string[SO_CodeGenerator.TYPE_COUNT]
        {
            "Event Listener",
            "Game Event",
            "Reference",
            "Collection",
            "Unity Event",
            "Variable",
        };

        private readonly bool[] _menuRequirement = new bool[SO_CodeGenerator.TYPE_COUNT]
        {
            false, true, false, true, false, true
        };

        private int _order;
        private string _typeName;
        private string _menuName;
        private AnimBool _menuAnim;
        private AnimBool _clampedValueHelpBoxAnim;

        [MenuItem("Window/SO Code Generation")]
        private static void ShowWindow()
        {
            GetWindow(typeof(SO_CodeGenerationWindow), true, "SO Code Generation");
        }
        private void OnEnable()
        {
            _menuAnim = new AnimBool();
            _menuAnim.valueChanged.AddListener(Repaint);

            _clampedValueHelpBoxAnim = new AnimBool();
            _clampedValueHelpBoxAnim.valueChanged.AddListener(Repaint);

            _order = SOArchitecture_Settings.Instance.DefaultCreateAssetMenuOrder;
        }
        private void OnGUI()
        {
            TypeSelection();

            EditorGUILayout.Space();

            DataFields();

            if (GUILayout.Button("Generate"))
            {
                SO_CodeGenerator.Data data = new SO_CodeGenerator.Data()
                {
                    Types = _states,
                    TypeName = _typeName,
                    MenuName = RequiresMenu() ? _menuName : default(string),
                    Order = _order,
                };

                SO_CodeGenerator.Generate(data);
                AssetDatabase.Refresh();
            }
        }
        private void TypeSelection()
        {
            EditorGUILayout.LabelField("Select Type(s)", EditorStyles.boldLabel);

            for (int i = 0; i < SO_CodeGenerator.TYPE_COUNT; i++)
            {
                bool isDepending = IsDepending(i);

                if (isDepending)
                {
                    _states[i] = true;
                }

                EditorGUI.BeginDisabledGroup(isDepending);

                _states[i] = EditorGUILayout.Toggle(_names[i], _states[i]);

                EditorGUI.EndDisabledGroup();
            }
        }
        private void DataFields()
        {
            EditorGUILayout.LabelField("Information", EditorStyles.boldLabel);

            // Type name.
            _typeName = EditorGUILayout.TextField(new GUIContent("Type Name", "Case sensitive, ensure exact match with actual type name"), _typeName);

            // Menu name.
            _menuAnim.target = RequiresMenu();
            EditorGUILayout.BeginFadeGroup(_menuAnim.faded);

            if (_menuAnim.value)
                _menuName = EditorGUILayout.TextField("Menu Name", _menuName);

            EditorGUILayout.EndFadeGroup();

            // Order.
            _order = EditorGUILayout.IntField(new GUIContent("Order", "Use default if unsure"), _order);
        }
        /// <summary>
        /// Polls the currently selected state types to determine whether any require menus
        /// </summary>
        /// <returns></returns>
        private bool RequiresMenu()
        {
            for (int i = 0; i < SO_CodeGenerator.TYPE_COUNT; i++)
            {
                if (_states[i] && _menuRequirement[i])
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Given an index, polls the dependency graph, and returns whether anyone is depending on it
        /// </summary>
        private bool IsDepending(int index)
        {
            for (int i = 0; i < SO_CodeGenerator.TYPE_COUNT; i++)
            {
                if (_states[i] && _dependencyGraph[i, index])
                    return true;
            }

            return false;
        }
    }
}