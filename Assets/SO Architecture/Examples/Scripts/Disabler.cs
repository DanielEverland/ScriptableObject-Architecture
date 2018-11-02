using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
    [SerializeField]
    private GameObjectCollection _targetSet;

    public void DisableRandom()
    {
        if (_targetSet.Count > 0)
        {
            int index = Random.Range(0, _targetSet.Count);

            GameObject objToDisable = _targetSet[index];
            objToDisable.SetActive(false);
        }        
    }
}