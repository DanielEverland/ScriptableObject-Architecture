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
            referenceType = referenceType.GetElementType();

        FieldInfo constantValueField = referenceType.GetField(ConstantValueName, NonPublicBindingsFlag);

        return constantValueField.FieldType;
    }
}
