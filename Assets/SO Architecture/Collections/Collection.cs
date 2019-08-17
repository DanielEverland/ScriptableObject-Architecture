using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public class Collection<T> : BaseCollection, IEnumerable<T>
    {
        public new T this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                _list[index] = value;
            }
        }

        [SerializeField]
        private List<T> _list = new List<T>();

        public override IList List
        {
            get
            {
                return _list;
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
            if (!_list.Contains(obj))
                _list.Add(obj);
        }
        public void Remove(T obj)
        {
            if (_list.Contains(obj))
                _list.Remove(obj);
        }
        public void Clear()
        {
            _list.Clear();
        }
        public bool Contains(T value)
        {
            return _list.Contains(value);
        }
        public int IndexOf(T value)
        {
            return _list.IndexOf(value);
        }
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
        public void Insert(int index, T value)
        {
            _list.Insert(index, value);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        public override string ToString()
        {
            return "Collection<" + typeof(T) + ">(" + Count + ")";
        }
        public T[] ToArray() {
            return _list.ToArray();
        }
    } 
}
