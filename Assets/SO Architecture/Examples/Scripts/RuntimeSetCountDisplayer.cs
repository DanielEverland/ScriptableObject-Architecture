using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuntimeSetCountDisplayer : MonoBehaviour
{
    [SerializeField]
    private Text _textTarget;
    [SerializeField]
    private BaseRuntimeSet _setTarget;
    [SerializeField]
    private string _textFormat = "There are {0} things.";

    private void Update()
    {
        _textTarget.text = string.Format(_textFormat, _setTarget.Count);
    }
}