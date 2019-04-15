namespace ScriptableObjectArchitecture
{
    public interface IClampedVariable { }
    public interface IClampedVariable<TType, TVariable, TReference> : IClampedVariable
    {
        TReference MinValue { get; }
        TReference MaxValue { get; }

        TType ClampValue(TType value);
    }
}
