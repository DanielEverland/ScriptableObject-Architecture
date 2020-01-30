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
        T oldValue = _value;
        T newValue = base.SetValue(value);

        if (!newValue.Equals(oldValue))
            _event.Invoke(newValue);            

        return newValue;
    }
    public void AddListener(UnityAction<T> callback)
    {
        _event.AddListener(callback);
    }
    public void RemoveListener(UnityAction<T> callback)
    {
        _event.RemoveListener(callback);
    }
    public override void RemoveAll()
    {
        base.RemoveAll();
        _event.RemoveAllListeners();
    }
}
