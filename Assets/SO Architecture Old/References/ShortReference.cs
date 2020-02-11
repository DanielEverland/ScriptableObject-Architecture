namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public sealed class ShortReference : BaseReference<short, ShortVariable>
    {
        public ShortReference() : base() { }
        public ShortReference(short value) : base(value) { }
    } 
}