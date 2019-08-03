using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.OBSERVER_SUBMENU + "String Observer")]
	public sealed class StringObserver : BaseObserver<string, StringVariable, StringUnityEvent>
	{
	}
}