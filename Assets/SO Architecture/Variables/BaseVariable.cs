using UnityEngine;

public abstract class BaseVariable : SOArchitectureBaseObject
{
    public abstract bool ReadOnly { get; }
    public abstract System.Type Type { get; }
    public abstract object BaseValue { get; set; }
}
public abstract class BaseVariable<T> : BaseVariable
{
    public virtual T Value { get { return _value; } set { _value = SetValue(value); } }
    public override bool ReadOnly { get { return _readOnly; } }    
    public override System.Type Type { get { return typeof(T); } }
    public override object BaseValue { get { return _value; } set { _value = SetValue((T)value); } }

    [SerializeField]
    protected T _value;
    [SerializeField]
    private bool _readOnly = false;
    [SerializeField]
    private bool _raiseWarning = true;
    
    public virtual T SetValue(T value)
    {
        if (_readOnly)
        {
            RaiseReadonlyWarning();
            return _value;
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

        return value.Value;
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