using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.OBSERVER_SUBMENU + "Float Observer")]
	public sealed class FloatObserver : NumericObserver<float, FloatVariable, FloatUnityEvent>
	{
        protected override void RaiseResponse(float value)
        {
            value *= _modifierCurve.Evaluate(value);
            base.RaiseResponse(value);
        }
    }
}