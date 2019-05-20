using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public sealed class Vector4Reference : BaseReference<Vector4, Vector4Variable>
    {
        public Vector4Reference() : base() { }
        public Vector4Reference(Vector4 value) : base(value) { }
    } 
}