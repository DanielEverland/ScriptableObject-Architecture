using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    public abstract class NumericObserver<TType, TVariable, TResponse> :
        BaseObserver<TType, TVariable, TResponse>
        where TType : struct, IComparable
        where TVariable : BaseVariable<TType>
        where TResponse : UnityEvent<TType>
    {
        [SerializeField] protected AnimationCurve _modifierCurve = new AnimationCurve();
        [SerializeField] private bool _constrain = false;
        [SerializeField] private bool _equals = false;
        [SerializeField] private bool _bigger = false;
        [SerializeField] private bool _smaller = false;

        private TType _previousValue;


        public override void OnVariableChanged(TType variable)
        {
            if (_constrain)
            {
                var result = _previousValue.CompareTo(variable);
                if (_equals)
                {
                    if ((_bigger && result >= 0) || (_smaller && result <= 0))
                    {
                        base.OnVariableChanged(variable);
                    }
                    else if (result == 0)
                    {
                        base.OnVariableChanged(variable);
                    }
                }
                else
                {
                    if ((_bigger && result > 0) || (_smaller && result < 0))
                    {
                        base.OnVariableChanged(variable);
                    }
                    else if (result != 0)
                    {
                        base.OnVariableChanged(variable);
                    }
                }
            }
            base.OnVariableChanged(variable);
            _previousValue = variable;
        }
    }
}