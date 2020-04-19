using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "TestTypeCollection.asset",
	    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "TestType",
	    order = 120)]
	public class TestTypeCollection : Collection<TestType>
	{
	}
}