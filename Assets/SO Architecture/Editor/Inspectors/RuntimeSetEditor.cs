using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(RuntimeSet<>), true)]
public class RuntimeSetEditor : Editor
{
    private SOArchitectureBaseObject Target { get { return (SOArchitectureBaseObject)target; } }
    private SerializedProperty DeveloperDescription { get { return serializedObject.FindProperty("DeveloperDescription"); } }

    private ReorderableList _reorderableList;
    private System.Type _targetType;

    private void OnEnable()
    {
        SerializedProperty items = serializedObject.FindProperty("_items");

        _targetType = Target.GetType().BaseType.GetGenericArguments()[0];

        _reorderableList = new ReorderableList(serializedObject, items);
        _reorderableList.drawElementCallback += DrawElement;
    }
    public override void OnInspectorGUI()
    {
        _reorderableList.DoLayoutList();

        EditorGUILayout.PropertyField(DeveloperDescription);
        
        _reorderableList.serializedProperty.serializedObject.ApplyModifiedProperties();
    }
    private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        rect.height = EditorGUIUtility.singleLineHeight;
        rect.y++;

        SerializedProperty property = _reorderableList.serializedProperty.GetArrayElementAtIndex(index);
        
        //We differentiate between the two so we can show scene objects that are assigned during runtime
        //Assets cannot contain scene objects, so we disallow assigning out of runtime
        //Note that scene objects must be assigned through code. Due to the above statement, the Unity editor specifically disallows it

        if(Application.isPlaying)
        {
            //Very important not to assign to property here. Due to the comments made above, doing so will make all scene object entries null
            Object obj = EditorGUI.ObjectField(rect, "Element " + index, property.objectReferenceValue, _targetType, false);

            //If the object is a scene object we do nothing. This allows scene objects assigned through code to be visible in the editor,
            //    while still allowing designers to manually assign non-scene objects
            if (EditorUtility.IsPersistent(obj))
            {
                property.objectReferenceValue = obj;
            }
        }
        else
        {
            EditorGUI.PropertyField(rect, property);
        }
        
        property.serializedObject.ApplyModifiedProperties();
    }
}