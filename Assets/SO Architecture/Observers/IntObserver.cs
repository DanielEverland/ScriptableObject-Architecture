using UnityEngine;

namespace ScriptableObjectArchitecture
{

    [AddComponentMenu(SOArchitecture_Utility.OBSERVER_SUBMENU + "Int Observer")]
	public sealed class IntObserver : NumericObserver<int, IntVariable, IntUnityEvent>
	{
        protected override void RaiseResponse(int value)
        {
            int v = Mathf.RoundToInt(value * _modifierCurve.Evaluate(value));
            base.RaiseResponse(v);
        }
    }
}