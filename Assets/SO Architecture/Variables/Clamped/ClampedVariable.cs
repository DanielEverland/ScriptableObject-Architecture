using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClampedVariable<T> : BaseVariable<T>
{
    protected T MinValue { get { return _minClampedValue; } }
    protected T MaxValue { get { return _maxClampedValue; } }

    [SerializeField]
    private T _minClampedValue;
    [SerializeField]
    private T _maxClampedValue;

    protected abstract T ClampValue(T value);
    
    public override T SetValue(BaseVariable<T> value)
    {
        return ClampValue(value.Value);
    }
    public override T SetValue(T value)
    {
        return ClampValue(value);
    }
}