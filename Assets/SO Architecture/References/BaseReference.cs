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
    protected bool _useConstant = false;
    [SerializeField]
    protected TBase _constantValue = default(TBase);
    [SerializeField]
    protected TVariable _variable = default(TVariable);

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
    public void AddListener(IGameEventListener listener)
    {
        if (_variable != null)
            _variable.AddListener(listener);
    }
    public void RemoveListener(IGameEventListener listener)
    {
        if (_variable != null)
            _variable.RemoveListener(listener);
    }
    public void AddListener(System.Action action)
    {
        if (_variable != null)
            _variable.AddListener(action);
    }
    public void RemoveListener(System.Action action)
    {
        if (_variable != null)
            _variable.AddListener(action);
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}

//Can't get property drawer to work with generic arguments
public abstract class BaseReference { }