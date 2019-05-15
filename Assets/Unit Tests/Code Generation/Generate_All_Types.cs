using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using ScriptableObjectArchitecture.Editor;
using UnityEditor.Callbacks;

namespace Tests
{
    public class Generate_All_Types
    {
        private const string TypeName = "UnitTest_TestClass";
        
        [Test]
        public void SimplePass()
        {
            EditorApplication.LockReloadAssemblies();

            SO_CodeGenerator.Data data = new SO_CodeGenerator.Data()
            {
                Types = CreateStates(),
                TypeName = TypeName,
                MenuName = default(string),
                Order = 1,
            };

            SO_CodeGenerator.Generate(data);
        }
        [TearDown]
        public void FileCleanup()
        {
            CleanupUtils.RecursiveCleanup(Application.dataPath, x => x.Contains(TypeName));
        }

        private bool[] CreateStates()
        {
            bool[] states = new bool[SO_CodeGenerator.TYPE_COUNT];

            for (int i = 0; i < SO_CodeGenerator.TYPE_COUNT; i++)
            {
                states[i] = true;
            }

            return states;
        }
    }
}
