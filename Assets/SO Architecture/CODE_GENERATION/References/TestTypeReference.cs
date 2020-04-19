using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class TestTypeReference : BaseReference<TestType, TestTypeVariable>
	{
	    public TestTypeReference() : base() { }
	    public TestTypeReference(TestType value) : base(value) { }
	}
}