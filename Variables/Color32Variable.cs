using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "Color32Variable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Structs/Color32",
	    order = 120)]
	public class Color32Variable : BaseVariable<Color32>
	{
	}
}