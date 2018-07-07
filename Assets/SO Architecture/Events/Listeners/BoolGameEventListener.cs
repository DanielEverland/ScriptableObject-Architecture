public sealed class BoolGameEventListener : BaseGameEventListener<BoolGameEvent, BoolUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}