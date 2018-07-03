[System.Serializable]
public class BoolReference : BaseReference<bool, BoolVariable>
{
    public BoolReference() : base() { }
    public BoolReference(bool value) : base(value) { }
}
