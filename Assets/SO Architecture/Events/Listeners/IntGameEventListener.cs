public sealed class IntGameEventListener : BaseGameEventListener<IntGameEvent, IntUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}