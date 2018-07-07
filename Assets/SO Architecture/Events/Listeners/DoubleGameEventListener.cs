public sealed class DoubleGameEventListener : BaseGameEventListener<DoubleGameEvent, DoubleUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}