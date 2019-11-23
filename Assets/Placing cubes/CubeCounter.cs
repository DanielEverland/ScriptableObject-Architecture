using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeCounter : MonoBehaviour
{
    [SerializeField]
    private Text textField;
    [SerializeField]
    private GameObjectCollection gameObjectCollection;

    private void Update()
    {
        textField.text = $"There are {gameObjectCollection.Count} cubes in the scene.";
    }
}
