namespace ScriptableObjectArchitecture
{
    public interface IGameEvent<T>
    {
        void Raise(T value);
        void AddListener(IGameEventListener<T> listener);
        void RemoveListener(IGameEventListener<T> listener);
    }
    public interface IGameEvent
    {
        void Raise();
        void AddListener(IGameEventListener listener);
        void RemoveListener(IGameEventListener listener);
    } 
}