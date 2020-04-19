using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "TestTypeGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "TestType",
	    order = 120)]
	public sealed class TestTypeGameEvent : GameEventBase<TestType>
	{
	}
}