using UnityEngine;

public class ObjectGameEventListener : BaseGameEventListener<ObjectGameEvent, ObjectUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}