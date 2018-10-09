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

        _reorderableList = new ReorderableList(items.serializedObject, items);
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

        
        if(property.propertyType == SerializedPropertyType.ObjectReference)
        {
            property.objectReferenceValue = EditorGUI.ObjectField(rect, "Element " + index, property.objectReferenceValue, _targetType, true);
        }
        else
        {
            EditorGUI.PropertyField(rect, property);
        }
        
        property.serializedObject.ApplyModifiedProperties();
    }
}