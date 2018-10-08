using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEventBase<>), true)]
public class TypedGameEventEditor : BaseGameEventEditor
{
    private System.Type GenericType { get { return target.GetType().BaseType.GetGenericArguments()[0]; } }

    private MethodInfo _raiseMethod;
    private TypedRaiseButton _raiseButton;

    protected override void OnEnable()
    {
        base.OnEnable();

        _raiseMethod = target.GetType().BaseType.GetMethod("Raise");
        _raiseButton = new TypedRaiseButton(GenericType, CallMethod);
    }
    protected override void DrawRaiseButton()
    {
        _raiseButton.Draw();
    }
    private void CallMethod(object value)
    {
        _raiseMethod.Invoke(target, new object[1] { value });
    }
}