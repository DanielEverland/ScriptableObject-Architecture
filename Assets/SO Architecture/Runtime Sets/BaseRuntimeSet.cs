using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRuntimeSet : SOArchitectureBaseObject, IEnumerable
{
    public object this[int index]
    {
        get
        {
            return Items[index];
        }
        set
        {
            Items[index] = value;
        }
    }

    public int Count { get { return Items.Count; } }

    public abstract IList Items { get; }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return Items.GetEnumerator();
    }
}