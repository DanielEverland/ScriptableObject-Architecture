public sealed class ULongGameEventListener : BaseGameEventListener<ULongGameEvent, ULongUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}