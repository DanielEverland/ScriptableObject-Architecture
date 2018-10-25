using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Type = System.Type;

[CustomEditor(typeof(BaseRuntimeSet), true)]
public class RuntimeSetEditor : Editor
{
    private BaseRuntimeSet Target { get { return (BaseRuntimeSet)target; } }
    private SerializedProperty DeveloperDescription { get { return serializedObject.FindProperty("DeveloperDescription"); } }

    private ReorderableList _reorderableList;

    private const bool DISABLE_ELEMENTS = false;
    private const bool ELEMENT_DRAGGABLE = true;
    private const bool LIST_DISPLAY_HEADER = true;
    private const bool LIST_DISPLAY_ADD_BUTTON = true;
    private const bool LIST_DISPLAY_REMOVE_BUTTON = true;

    private void OnEnable()
    {
        SerializedProperty items = serializedObject.FindProperty("_items");

        string title = "List (" + Target.Type + ")";
        
        _reorderableList = new ReorderableList(serializedObject, items, ELEMENT_DRAGGABLE, LIST_DISPLAY_HEADER, LIST_DISPLAY_ADD_BUTTON, LIST_DISPLAY_REMOVE_BUTTON);
        _reorderableList.drawHeaderCallback += (Rect rect) => { EditorGUI.LabelField(rect, title); };
        _reorderableList.drawElementCallback += DrawElement;
        _reorderableList.onRemoveCallback += Remove;
        _reorderableList.onChangedCallback += (ReorderableList list) => { Repaint(); };
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        _reorderableList.DoLayoutList();

        EditorGUILayout.PropertyField(DeveloperDescription);

        serializedObject.ApplyModifiedProperties();
    }
    private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        rect.height = EditorGUIUtility.singleLineHeight;
        rect.y++;

        SerializedProperty property = _reorderableList.serializedProperty.GetArrayElementAtIndex(index);

        EditorGUI.BeginDisabledGroup(DISABLE_ELEMENTS);

        EditorGUI.LabelField(rect, "Element " + index);

        rect.width /= 2;
        rect.x += rect.width;

        if (SOArchitecture_EditorUtility.HasPropertyDrawer(Target.Type))
        {
            //Unity doesn't like it when you have scene objects on assets,
            //so we do some magic to display it anyway
            if (typeof(Object).IsAssignableFrom(Target.Type) && !EditorUtility.IsPersistent(property.objectReferenceValue) && property.objectReferenceValue != null)
            {
                EditorGUI.BeginDisabledGroup(true);
                    EditorGUI.ObjectField(rect, new GUIContent(""), property.objectReferenceValue, Target.Type, false);
                EditorGUI.EndDisabledGroup();
            }
            else
            {
                EditorGUI.PropertyField(rect, property, new GUIContent(""));
            }            
        }
        else
        {
            string content = "No PropertyDrawer for " + Target.Type;

            EditorGUI.LabelField(rect, new GUIContent(content, content));
        }

            //EditorGUI.ObjectField(rect, "Element " + index, property.objectReferenceValue, Target.Type, false);
        EditorGUI.EndDisabledGroup();
    }
    private void Remove(ReorderableList list)
    {
        Target.Items.RemoveAt(list.index);
    }
}