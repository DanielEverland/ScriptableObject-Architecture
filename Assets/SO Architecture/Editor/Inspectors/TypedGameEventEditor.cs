using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEventBase<>), true)]
public sealed class TypedGameEventEditor : BaseGameEventEditor
{
    private System.Type GenericType { get { return target.GetType().BaseType.GetGenericArguments()[0]; } }

    private MethodInfo _raiseMethod;
    private MutableObject _value = new MutableObject();

    protected override void OnEnable()
    {
        base.OnEnable();

        _raiseMethod = target.GetType().BaseType.GetMethod("Raise");
    }
    protected override void DrawRaiseButton()
    {
        if (GenericType == typeof(bool))
        {
            _value = EditorGUILayout.Toggle("Debug Value", _value);
            
            RaiseButton((bool)_value);
        }
        else if(GenericType == typeof(byte))
        {
            _value = EditorGUILayout.IntField("Debug Value", _value);

            RaiseButton((byte)_value);
        }
        else if(GenericType == typeof(char))
        {
            _value = EditorGUILayout.TextField("Debug Value", _value);
            
            RaiseButton((char)_value);
        }
        else if(GenericType == typeof(double))
        {
            _value = EditorGUILayout.DoubleField("Debug Value", _value);

            RaiseButton((double)_value);
        }
        else if(GenericType == typeof(float))
        {
            _value = EditorGUILayout.FloatField("Debug Value", _value);

            RaiseButton((float)_value);
        }
        else if(GenericType == typeof(int))
        {
            _value = EditorGUILayout.IntField("Debug Value", _value);

            RaiseButton((int)_value);
        }
        else if(GenericType == typeof(long))
        {
            _value = EditorGUILayout.LongField("Debug Value", _value);

            RaiseButton((long)_value);
        }
        else if(GenericType == typeof(Object))
        {
            _value = EditorGUILayout.ObjectField("Debug Value", _value, GenericType, true);

            RaiseButton((Object)_value);
        }
        else if(GenericType == typeof(sbyte))
        {
            _value = EditorGUILayout.IntField("Debug Value", _value);

            RaiseButton((sbyte)_value);
        }
        else if(GenericType == typeof(short))
        {
            _value = EditorGUILayout.IntField("Debug Value", _value);

            RaiseButton((short)_value);
        }
        else if(GenericType == typeof(string))
        {
            _value = EditorGUILayout.TextField("Debug Value", _value);

            RaiseButton((string)_value);
        }
        else if(GenericType == typeof(uint))
        {
            _value = EditorGUILayout.LongField("Debug Value", _value);

            RaiseButton((uint)(long)_value);
        }
        else if(GenericType == typeof(ushort))
        {
            _value = EditorGUILayout.IntField("Debug Value", _value);

            RaiseButton((ushort)(int)_value);
        }
        else
        {
            EditorGUILayout.LabelField("Can't draw debug value field for " + GenericType);
        }
    }
    private void RaiseButton(object value)
    {
        if (GUILayout.Button("Raise"))
        {
            _raiseMethod.Invoke(target, new object[1] { value });
        }
    }
    private partial class MutableObject
    {
        public MutableObject() { }
    }
    private partial class MutableObject
    {
        public MutableObject(bool value)
        {
            _boolValue = value;
        }

        private bool _boolValue;

        public static implicit operator bool(MutableObject obj)
        {
            return obj._boolValue;
        }
        public static implicit operator MutableObject(bool value)
        {
            return new MutableObject(value);
        }
    }
    private partial class MutableObject
    {
        public MutableObject(int value)
        {
            _intValue = value;
        }

        private int _intValue;

        public static implicit operator int(MutableObject obj)
        {
            return obj._intValue;
        }
        public static implicit operator MutableObject(int value)
        {
            return new MutableObject(value);
        }
    }
    private partial class MutableObject
    {
        public MutableObject(float value)
        {
            _floatValue = value;
        }

        private float _floatValue;

        public static implicit operator float(MutableObject obj)
        {
            return obj._floatValue;
        }
        public static implicit operator MutableObject(float value)
        {
            return new MutableObject(value);
        }
    }
    private partial class MutableObject
    {
        public MutableObject(string value)
        {
            _stringValue = value;
        }

        private string _stringValue;

        public static implicit operator string(MutableObject obj)
        {
            return obj._stringValue;
        }
        public static implicit operator char(MutableObject obj)
        {
            if (obj._stringValue == null)
                return default(char);

            if (obj._stringValue.Length > 0)
                return obj._stringValue[0];

            return default(char);
        }
        public static implicit operator MutableObject(string value)
        {
            return new MutableObject(value);
        }
    }
    private partial class MutableObject
    {
        public MutableObject(double value)
        {
            _doubleValue = value;
        }

        private double _doubleValue;

        public static implicit operator double(MutableObject obj)
        {
            return obj._doubleValue;
        }        
        public static implicit operator MutableObject(double value)
        {
            return new MutableObject(value);
        }
    }
    private partial class MutableObject
    {
        public MutableObject(long value)
        {
            _longValue = value;
        }

        private long _longValue;

        public static implicit operator long(MutableObject obj)
        {
            return obj._longValue;
        }
        public static implicit operator MutableObject(long value)
        {
            return new MutableObject(value);
        }
    }
    private partial class MutableObject
    {
        public MutableObject(Object value)
        {
            _objectValue = value;
        }

        private Object _objectValue;

        public static implicit operator Object(MutableObject obj)
        {
            return obj._objectValue;
        }
        public static implicit operator MutableObject(Object value)
        {
            return new MutableObject(value);
        }
    }
}