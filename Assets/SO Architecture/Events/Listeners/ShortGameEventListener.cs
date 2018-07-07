public sealed class ShortGameEventListener : BaseGameEventListener<ShortGameEvent, ShortUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}