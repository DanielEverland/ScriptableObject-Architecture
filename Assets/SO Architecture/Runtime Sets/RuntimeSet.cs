using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeSet<T> : SOArchitectureBaseObject, IEnumerable<T>
{
    [SerializeField]
    protected List<T> _items = new List<T>();

    public int Count { get { return _items.Count; } }

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