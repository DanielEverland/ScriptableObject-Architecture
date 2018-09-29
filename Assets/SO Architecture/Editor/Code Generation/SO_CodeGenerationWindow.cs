using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

public class SO_CodeGenerationWindow : EditorWindow {

    /* --------- DEPENDENCY GRAPH ---------*
     * [1] Game Event Listener
     * [2] Game Event
     * [3] Reference
     * [4] Runtime Set
     * [5] Unity Event
     * [6] Variable
     * 
     * /  1  2  3  4  5  6
     * 1     X        X
     * 2        X
     * 3                 X
     * 4
     * 5
     * 6
     */
        
    private bool[,] _dependencyGraph = new bool[SO_CodeGenerator.TYPE_COUNT, SO_CodeGenerator.TYPE_COUNT]
    {
        { false, true, false, false, true, false },
        { false, false, true, false, false, false },
        { false, false, false, false, false, true },
        { false, false, false, false, false, false },
        { false, false, false, false, false, false },
        { false, false, false, false, false, false },
    };

    private bool[] _states = new bool[SO_CodeGenerator.TYPE_COUNT];
    private string[] _names = new string[SO_CodeGenerator.TYPE_COUNT]
    {
        "Event Listener",
        "Game Event",
        "Reference",
        "Runtime Set",
        "Unity Event",
        "Variable"
    };

    private bool[] _menuRequirement = new bool[SO_CodeGenerator.TYPE_COUNT]
    {
        false, true, false, true, false, true
    };

    private string _typeName;
    private string _menuName;
    private AnimBool _menuAnim;
    
    
	[MenuItem("Window/SO Code Generation")]
    private static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SO_CodeGenerationWindow), true, "SO Code Generation");
    }
    private void OnEnable()
    {
        _menuAnim = new AnimBool();
        _menuAnim.valueChanged.AddListener(Repaint);
    }
    private void OnGUI()
    {
        TypeSelection();

        EditorGUILayout.Space();

        DataFields();

        if(GUILayout.Button("Generate"))
        {


            Close();
        }
    }
    private void TypeSelection()
    {
        EditorGUILayout.LabelField("Select Type(s)");

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
        EditorGUILayout.LabelField("Information");

        _typeName = EditorGUILayout.TextField(new GUIContent("Type Name", "Case sensitive, ensure exact match with actual type name"), _typeName);

        _menuAnim.target = RequiresMenu();
        EditorGUILayout.BeginFadeGroup(_menuAnim.faded);

        if (_menuAnim.value)
            _menuName = EditorGUILayout.TextField("Menu Name", _menuName);

        EditorGUILayout.EndFadeGroup();
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
