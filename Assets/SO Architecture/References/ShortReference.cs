[System.Serializable]
public class ShortReference : BaseReference<short, ShortVariable>
{
    public ShortReference() : base() { }
    public ShortReference(short value) : base(value) { }
}