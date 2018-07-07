using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class GameEventListener : BaseGameEventListener<GameEvent, UnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke();
    }
}
