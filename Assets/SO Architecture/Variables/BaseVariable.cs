using UnityEngine;

public interface IBaseVariable
{
    System.Type Type { get; }
}
public abstract class BaseVariable : SOArchitectureBaseObject, IBaseVariable
{
    public abstract System.Type Type { get; }
    public abstract object BaseValue { get; set; }
}
public abstract class BaseVariable<T> : BaseVariable
{
    public T Value { get { return _value; } set { _value = value; } }
    public override System.Type Type { get { return typeof(T); } }
    public override object BaseValue { get { return _value; } set { _value = (T)value; } }

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