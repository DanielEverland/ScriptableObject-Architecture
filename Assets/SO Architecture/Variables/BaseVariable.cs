using UnityEngine;

public interface IBaseVariable
{
    System.Type Type { get; }
}
public abstract class BaseVariable<T> : SOArchitectureBaseObject, IBaseVariable
{
    public T Value { get { return _value; } set { _value = value; } }
    public System.Type Type { get { return typeof(T); } }

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