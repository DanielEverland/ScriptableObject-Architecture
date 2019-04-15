namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public sealed class CharReference : BaseReference<char, CharVariable>
    {
        public CharReference() : base() { }
        public CharReference(char value) : base(value) { }
    } 
}