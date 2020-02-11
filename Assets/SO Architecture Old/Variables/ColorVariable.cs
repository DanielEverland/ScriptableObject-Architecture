using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public class ColorEvent : UnityEvent<Color> { }

	[CreateAssetMenu(
	    fileName = "ColorVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Structs/Color",
	    order = 120)]
	public class ColorVariable : BaseVariable<Color, ColorEvent>
	{
	}
}