using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class SO_CodeGenerator
{
    static SO_CodeGenerator()
    {
        CreateTargetDirectories();
        GatherFilePaths();
    }
    private static void CreateTargetDirectories()
    {
        _targetDirectories = new string[TYPE_COUNT]
        {
            Application.dataPath + "/SO Architecture/Events/Listeners",
            Application.dataPath + "/SO Architecture/Events/Game Events",
            Application.dataPath + "/SO Architecture/References",
            Application.dataPath + "/SO Architecture/Runtime Sets",
            Application.dataPath + "/SO Architecture/Events/Responses",
            Application.dataPath + "/SO Architecture/Variables",
        };
    }
    private static void GatherFilePaths()
    {
        Queue<string> foldersToCheck = new Queue<string>();
        foldersToCheck.Enqueue(Application.dataPath);

        while (foldersToCheck.Count > 0)
        {
            string currentDirectory = foldersToCheck.Dequeue();

            foreach (string filePath in Directory.GetFiles(currentDirectory))
            {
                string fileName = Path.GetFileName(filePath);

                for (int i = 0; i < TYPE_COUNT; i++)
                {
                    if (_templateNames[i] == fileName)
                        _templatePaths[i] = filePath;
                }
            }
            foreach (string subDirectory in Directory.GetDirectories(currentDirectory))
            {
                foldersToCheck.Enqueue(subDirectory);
            }
        }

        //Double check that all filepaths were found
        for (int i = 0; i < TYPE_COUNT; i++)
        {
            if (_templatePaths[i] == default(string))
            {
                Debug.LogError("Couldn't find path for " + _templatePaths[i]);
            }
        }
    }

    public const int TYPE_COUNT = 6;

    public struct Data
    {
        public bool[] Types;
        public string TypeName;
        public string MenuName;
    }

    private static string[] _templateNames = new string[TYPE_COUNT]
    {
        "GameEventListenerTemplate",
        "GameEventTemplate",
        "ReferenceTemplate",
        "RuntimeSetTemplate",
        "UnityEventTemplate",
        "VariableTemplate"
    };

    private static string[] _targetFileNames = new string[TYPE_COUNT]
    {
        "{0}GameEventListener.cs",
        "{0}GameEvent.cs",
        "{0}Reference.cs",
        "{0}Set.cs",
        "{0}UnityEvent.cs",
        "{0}Variable.cs"
    };

    private static string[] _targetDirectories = null;
    private static string[] _templatePaths = new string[TYPE_COUNT];
    private static string[,] _replacementStrings = null;

    private static string Type { get { return _replacementStrings[0, 1]; } }
    private static string TypeName { get { return _replacementStrings[1, 1]; } }
    private static string MenuName { get { return _replacementStrings[2, 1]; } }

    public static void Generate(Data data)
    {
        _replacementStrings = new string[3, 2]
        {
            { "$TYPE$", data.TypeName },
            { "$TYPE_NAME$", CapitalizeFirstLetter(data.TypeName) },
            { "$MENU_NAME$", data.MenuName },
        };

        for (int i = 0; i < TYPE_COUNT; i++)
        {
            if (data.Types[i])
            {
                GenerateScript(i);
            }
        }

        AssetDatabase.Refresh();
    }
    private static void GenerateScript(int index)
    {
        string targetFilePath = GetTargetFilePath(index);
        string contents = GetScriptContents(index);

        Debug.Log("Creating " + targetFilePath);

        File.WriteAllText(targetFilePath, contents);
    }
    private static string GetScriptContents(int index)
    {
        string templatePath = _templatePaths[index];
        string templateContent = File.ReadAllText(templatePath);

        string output = templateContent;

        for (int i = 0; i < _replacementStrings.GetLength(0); i++)
        {
            output = output.Replace(_replacementStrings[i, 0], _replacementStrings[i, 1]);
        }

        return output;
    }
    private static string GetTargetFilePath(int index)
    {
        return _targetDirectories[index] + "/" + string.Format(_targetFileNames[index], TypeName);
    }
    private static string CapitalizeFirstLetter(string input)
    {
        return input.First().ToString().ToUpper() + input.Substring(1);
    }
}