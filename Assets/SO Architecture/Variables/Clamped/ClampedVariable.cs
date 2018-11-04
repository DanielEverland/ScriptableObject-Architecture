using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClampedVariable<TType, TVariable, TReference> : BaseVariable<TType>
    where TVariable : BaseVariable<TType>
    where TReference : BaseReference<TType, TVariable>
{
    protected TReference MinValue { get { return _minClampedValue; } }
    protected TReference MaxValue { get { return _maxClampedValue; } }

    [SerializeField]
    private TReference _minClampedValue;
    [SerializeField]
    private TReference _maxClampedValue;

    protected abstract TType ClampValue(TType value);
    
    public override TType SetValue(BaseVariable<TType> value)
    {
        return ClampValue(value.Value);
    }
    public override TType SetValue(TType value)
    {
        return ClampValue(value);
    }
}