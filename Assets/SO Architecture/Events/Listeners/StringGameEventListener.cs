public sealed class StringGameEventListener : BaseGameEventListener<StringGameEvent, StringUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}