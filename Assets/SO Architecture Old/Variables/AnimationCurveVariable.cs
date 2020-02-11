using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public class AnimationCurveEvent : UnityEvent<AnimationCurve> { }

	[CreateAssetMenu(
	    fileName = "AnimationCurveVariable.asset",
	    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "AnimationCurve",
	    order = 120)]
	public class AnimationCurveVariable : BaseVariable<AnimationCurve, AnimationCurveEvent>
	{
	}
}