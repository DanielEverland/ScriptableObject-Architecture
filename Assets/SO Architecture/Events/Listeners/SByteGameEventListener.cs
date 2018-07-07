public sealed class SByteGameEventListener : BaseGameEventListener<SByteGameEvent, SByteUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}