public sealed class UShortGameEventListener : BaseGameEventListener<UShortGameEvent, UShortUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}