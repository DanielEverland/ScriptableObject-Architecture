using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "AudioClipVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "AudioClip",
	    order = 120)]
	public class AudioClipVariable : BaseVariable<AudioClip>
	{
	}
}