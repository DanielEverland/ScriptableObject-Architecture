public sealed class FloatGameEventListener : BaseGameEventListener<FloatGameEvent, FloatUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}