using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeSet<T> : BaseRuntimeSet, IEnumerable<T>
{
    public new T this[int index]
    {
        get
        {
            return _items[index];
        }
        set
        {
            _items[index] = value;
        }
    }

    [SerializeField]
    private List<T> _items = new List<T>();

    public override IList Items
    {
        get
        {
            return _items;
        }
    }
    public override Type Type
    {
        get
        {
            return typeof(T);
        }
    }

    public void Add(T obj)
    {
        if (!_items.Contains(obj))
            _items.Add(obj);
    }
    public void Remove(T obj)
    {
        if (_items.Contains(obj))
            _items.Remove(obj);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}