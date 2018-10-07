public interface IGameEvent<T>
{
    void Raise(T value);
    void RegisterListener(IGameEventListener<T> listener);
    void UnregisterListener(IGameEventListener<T> listener);
}
public interface IGameEvent
{
    void Raise();
    void RegisterListener(IGameEventListener listener);
    void UnregisterListener(IGameEventListener listener);
}