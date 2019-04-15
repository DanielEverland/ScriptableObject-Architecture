namespace ScriptableObjectArchitecture
{
    public interface IClampedVariable { }
    public interface IClampedVariable<TType, TReference> : IClampedVariable
    {
        TReference MinValue { get; }
        TReference MaxValue { get; }

        TType ClampValue(TType value);
    }
}
