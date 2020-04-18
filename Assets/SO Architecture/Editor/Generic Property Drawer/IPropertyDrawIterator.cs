using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
    public interface IPropertyDrawIterator : IPropertyIterator
    {
        void Draw();
    } 
}
