using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableObjectArchitecture
{
    public abstract class BaseObserver<TType, TVariable, TResponse> : DebuggableGameEventListener, IVariableObserver<TType>
where TVariable : BaseVariable<TType>
where TResponse : UnityEvent<TType>
    {
        protected override ScriptableObject GameEvent => Variable;

        protected ScriptableObject Variable { get { return _variable; } }
        protected override UnityEventBase Response { get { return _response; } }

        [SerializeField]
        private TVariable _PreviouslyRegisteredVariable = default(TVariable);
        [SerializeField]
        protected TVariable _variable = default(TVariable);
        [SerializeField]
        private TResponse _response = default(TResponse);
        [SerializeField]
        protected TType _debugValue = default(TType);

        protected virtual void RaiseResponse(TType value)
        {
            _response.Invoke(value);
        }

        private void OnEnable()
        {
            if (_variable != null)
                Register();
        }
        private void OnDisable()
        {
            if (_variable != null)
                _variable.RemoveObserver(this);
        }
        private void Register()
        {
            if (_PreviouslyRegisteredVariable != null)
            {
                _PreviouslyRegisteredVariable.RemoveObserver(this);
            }

            _variable.AddObserver(this);
            _PreviouslyRegisteredVariable = _variable;
        }

        public virtual void OnVariableChanged(TType variable)
        {
            RaiseResponse(variable);

            CreateDebugEntry(_response);

            AddStackTrace(variable);
        }

        public void Log(TType value)
        {
            Debug.Log($"[{gameObject.name} - {Variable.name}]: {value}");
        }
    }
}