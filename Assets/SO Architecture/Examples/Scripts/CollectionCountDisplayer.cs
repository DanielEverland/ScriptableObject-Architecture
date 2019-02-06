using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionCountDisplayer : MonoBehaviour
{
    [SerializeField]
    private Text _textTarget = default(Text);
    [SerializeField]
    private BaseCollection _setTarget = default(BaseCollection);
    [SerializeField]
    private string _textFormat = "There are {0} things.";

    private void Update()
    {
        _textTarget.text = string.Format(_textFormat, _setTarget.Count);
    }
}