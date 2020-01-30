using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class BaseVariableWithEvent<T, TEvent> : BaseVariable<T> where TEvent : UnityEvent<T>
{
    [SerializeField]
    private TEvent _event = default;

    public override T SetValue(T value)
    {
        T newValue = base.SetValue(value);

        if (!newValue.Equals(value))
            _event.Invoke(newValue);

        return newValue;
    }
}
