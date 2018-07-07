public sealed class UIntGameEventListener : BaseGameEventListener<UIntGameEvent, UIntUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}