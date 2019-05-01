using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public abstract class BaseVariable : GameEventBase
    {
        public abstract bool ReadOnly { get; }
        public abstract System.Type Type { get; }
        public abstract object BaseValue { get; set; }
    }
    public abstract class BaseVariable<T> : BaseVariable
    {
        public virtual T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = SetValue(value);
                Raise();
            }
        }
        public virtual T MinClampValue
        {
            get
            {
                if(Clampable)
                {
                    return _minValue;
                }
                else
                {
                    return default(T);
                }
            }
        }
        public virtual T MaxClampValue
        {
            get
            {
                if(Clampable)
                {
                    return _maxValue;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public virtual bool Clampable { get { return false; } }
        public override bool ReadOnly { get { return _readOnly; } }
        public override System.Type Type { get { return typeof(T); } }
        public override object BaseValue
        {
            get
            {
                return _value;
            }
            set
            {
                _value = SetValue((T)value);
                Raise();
            }
        }

        [SerializeField]
        protected T _value = default(T);
        [SerializeField]
        private bool _readOnly = false;
        [SerializeField]
        private bool _raiseWarning = true;
        [SerializeField]
        protected T _minValue = default(T);
        [SerializeField]
        protected T _maxValue = default(T);
        
        public virtual T SetValue(T value)
        {
            if (_readOnly)
            {
                RaiseReadonlyWarning();
                return _value;
            }
            else if(Clampable)
            {
                return ClampValue(value);
            }

            return value;
        }
        public virtual T SetValue(BaseVariable<T> value)
        {
            if (_readOnly)
            {
                RaiseReadonlyWarning();
                return _value;
            }
            else if (Clampable)
            {
                return ClampValue(value.Value);
            }

            return value.Value;
        }
        protected virtual T ClampValue(T value)
        {
            return value;
        }
        private void RaiseReadonlyWarning()
        {
            if (!_readOnly || !_raiseWarning)
                return;

            Debug.LogWarning("Tried to set value on " + name + ", but value is readonly!", this);
        }
        public override string ToString()
        {
            return _value == null ? "null" : _value.ToString();
        }
        public static implicit operator T(BaseVariable<T> variable)
        {
            return variable.Value;
        }
    } 
}