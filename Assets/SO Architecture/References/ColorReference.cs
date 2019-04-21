using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ColorReference : BaseReference<Color, ColorVariable>
	{
	    public ColorReference() : base() { }
	    public ColorReference(Color value) : base(value) { }
	}
}