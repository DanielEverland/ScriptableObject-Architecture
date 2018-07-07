public sealed class LongGameEventListener : BaseGameEventListener<LongGameEvent, LongUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}