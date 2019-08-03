namespace ScriptableObjectArchitecture
{
    public interface IVariableObserver<T>
    {
        void OnVariableChanged(T variable);
    }
}