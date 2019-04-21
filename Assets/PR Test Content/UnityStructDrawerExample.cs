using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public class UnityStructDrawerExample : MonoBehaviour
    {
        [SerializeField]
        private Vector2Reference _vector2Reference;

        [SerializeField]
        private Vector3Reference _vector3Reference;

        [SerializeField]
        private Vector4Reference _vector4Reference;

        [SerializeField]
        private QuaternionReference quaternionReference;

        [SerializeField]
        private Vector2Reference[] _vector2References;

        [SerializeField]
        private Vector3Reference[] _vector3References;

        [SerializeField]
        private Vector4Reference[] _vector4References;

        [SerializeField]
        private QuaternionReference[] quaternionReferences;
    }
}
