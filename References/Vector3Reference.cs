using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public sealed class Vector3Reference : BaseReference<Vector3, Vector3Variable>
    {
        public Vector3Reference() : base() { }
        public Vector3Reference(Vector3 value) : base(value) { }
    } 
}