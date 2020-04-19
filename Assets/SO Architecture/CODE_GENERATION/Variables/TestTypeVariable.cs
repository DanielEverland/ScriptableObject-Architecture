using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class TestTypeEvent : UnityEvent<TestType> { }

	[CreateAssetMenu(
	    fileName = "TestTypeVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "TestType",
	    order = 120)]
	public class TestTypeVariable : BaseVariable<TestType, TestTypeEvent>
	{
	}
}