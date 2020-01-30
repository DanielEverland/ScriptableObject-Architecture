using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using Type = System.Type;

public static class BaseReferenceHelper
{
    private const BindingFlags NonPublicBindingsFlag = BindingFlags.Instance | BindingFlags.NonPublic;
    private const string ConstantValueName = "_constantValue";
    
    public static Type GetReferenceType(FieldInfo fieldInfo)
    {
        return fieldInfo.FieldType;
    }
    public static Type GetValueType(FieldInfo fieldInfo)
    {
        Type referenceType = GetReferenceType(fieldInfo);
        
        if(referenceType.IsArray)
        {
            referenceType = referenceType.GetElementType();
        }
        else if(IsList(referenceType))
        {
            referenceType = referenceType.GetGenericArguments()[0];
        }
        
        FieldInfo constantValueField = referenceType.GetField(ConstantValueName, NonPublicBindingsFlag);

        return constantValueField.FieldType;
    }
    private static bool IsList(Type referenceType)
    {
        return referenceType.IsGenericType;
    }
}
