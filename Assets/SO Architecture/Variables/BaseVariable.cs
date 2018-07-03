using UnityEngine;

public class BaseVariable<T> : ScriptableObject
{
    public T Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif    

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
}