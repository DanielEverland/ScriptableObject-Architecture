public sealed class ByteGameEventListener : BaseGameEventListener<ByteGameEvent, ByteUnityEvent>
{
    protected override void RaiseResponse()
    {
        Response.Invoke(GameEvent.Value);
    }
}