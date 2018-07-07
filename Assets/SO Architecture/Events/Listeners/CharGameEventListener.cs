public sealed class CharGameEventListener : BaseGameEventListener<CharGameEvent, CharUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}