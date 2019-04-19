using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "Color32Variable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Color32",
	    order = 120)]
	public class Color32Variable : BaseVariable<Color32>
	{
	}
}