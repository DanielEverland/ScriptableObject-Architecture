using System;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [Serializable]
    public class DeveloperDescription : IEquatable<DeveloperDescription>, IEquatable<string>
    {
        public DeveloperDescription() { }
        public DeveloperDescription(string value)
        {
            _value = value;
        }

        [SerializeField]
        private string _value = string.Empty;

        public static implicit operator string(DeveloperDescription description)
        {
            return description._value;
        }
        public static implicit operator DeveloperDescription(string value)
        {
            return new DeveloperDescription(value);
        }

        public override bool Equals(object obj)
        {
            return _value.Equals(obj);
        }
        public bool Equals(DeveloperDescription other)
        {
            if (other == null)
                return false;

            return _value == other._value;
        }
        public bool Equals(string other)
        {
            if (other == null)
                return false;

            return _value == other;
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        public override string ToString()
        {
            return _value;
        }
    }
}