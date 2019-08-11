using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "KeyCodeVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Key Code",
	    order = 120)]
	public class KeyCodeVariable : BaseVariable<KeyCode>
	{
	}
}