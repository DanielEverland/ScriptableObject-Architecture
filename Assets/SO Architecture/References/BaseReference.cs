using UnityEngine;

[System.Serializable]
public abstract class BaseReference<TBase, TVariable> : BaseReference where TVariable : BaseVariable<TBase>
{
    public BaseReference() { }
    public BaseReference(TBase baseValue)
    {
        _useConstant = true;
        _constantValue = baseValue;
    }

    [SerializeField]
    protected bool _useConstant = true;
    [SerializeField]
    protected TBase _constantValue;
    [SerializeField]
    protected TVariable _variable;

    public TBase Value
    {
        get { return _useConstant ? _constantValue : _variable.Value; }
        set
        {
            if (!_useConstant && _variable != null)
                _variable.Value = value;
            else if (_useConstant)
                _constantValue = value;
        }
    }
}

//Can't get property drawer to work with generic arguments
public abstract class BaseReference { }