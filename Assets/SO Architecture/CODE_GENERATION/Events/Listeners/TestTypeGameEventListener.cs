using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "TestType")]
	public sealed class TestTypeGameEventListener : BaseGameEventListener<TestType, TestTypeGameEvent, TestTypeUnityEvent>
	{
	}
}