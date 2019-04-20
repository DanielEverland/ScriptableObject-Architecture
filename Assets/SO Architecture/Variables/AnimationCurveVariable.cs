using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "AnimationCurveVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "AnimationCurve",
	    order = 120)]
	public class AnimationCurveVariable : BaseVariable<AnimationCurve>
	{
	}
}