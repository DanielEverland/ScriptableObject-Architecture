public sealed class $TYPE_NAME$GameEventListener : BaseGameEventListener<$TYPE_NAME$GameEvent, $TYPE_NAME$UnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}