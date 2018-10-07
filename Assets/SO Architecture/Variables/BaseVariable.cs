using UnityEngine;

public abstract class BaseVariable<T> : SOArchitectureBaseObject
{
    public T Value { get { return _value; } set { _value = value; } }

    [SerializeField]
    protected T _value;

    public void SetValue(T value)
    {
        Value = value;
    }
    public void SetValue(BaseVariable<T> value)
    {
        Value = value.Value;
    }

    public static implicit operator T(BaseVariable<T> variable)
    {
        return variable.Value;
    }
}