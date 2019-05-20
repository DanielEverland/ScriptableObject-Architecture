namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public sealed class BoolReference : BaseReference<bool, BoolVariable>
    {
        public BoolReference() : base() { }
        public BoolReference(bool value) : base(value) { }
    } 
}