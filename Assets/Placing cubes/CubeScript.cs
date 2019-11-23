using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField]
    private GameObjectCollection collection;

    private void OnEnable()
    {
        collection.Add(gameObject);
    }
    private void OnDisable()
    {
        collection.Remove(gameObject);
    }
}
