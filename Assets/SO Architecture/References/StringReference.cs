namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public sealed class StringReference : BaseReference<string, StringVariable>
    {
        public StringReference() : base() { }
        public StringReference(string value) : base(value) { }
    } 
}