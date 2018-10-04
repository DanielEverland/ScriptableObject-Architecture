using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEventBase), true)]
public sealed class GameEventEditor : BaseGameEventEditor
{
    private GameEvent Target { get { return (GameEvent)target; } }

    protected override void DrawRaiseButton()
    {
        if(GUILayout.Button("Raise"))
        {
            Target.Raise();
        }
    }
}