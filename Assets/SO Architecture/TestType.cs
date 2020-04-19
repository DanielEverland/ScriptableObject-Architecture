using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestType
{
    [SerializeField]
    private float floatValue;
    [SerializeField]
    private Quaternion quaternionValue;
    [SerializeField]
    private SubType subType;

    [System.Serializable]
    public class SubType
    {
        public double publicValue;

        [SerializeField]
        private string privateValue;
    }
}
