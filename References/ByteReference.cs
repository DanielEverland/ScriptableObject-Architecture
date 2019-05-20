namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public sealed class ByteReference : BaseReference<byte, ByteVariable>
    {
        public ByteReference() : base() { }
        public ByteReference(byte value) : base(value) { }
    } 
}