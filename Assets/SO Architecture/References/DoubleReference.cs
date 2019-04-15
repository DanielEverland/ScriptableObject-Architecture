namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public sealed class DoubleReference : BaseReference<double, DoubleVariable>
    {
        public DoubleReference() : base() { }
        public DoubleReference(double value) : base(value) { }
    } 
}