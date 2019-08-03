using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.OBSERVER_SUBMENU + "")]
	public sealed class Vector2Observer : BaseObserver<Vector2, Vector2Variable, Vector2UnityEvent>
	{
	}
}