using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "AudioClipCollection.asset",
	    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_COLLECTION + "AudioClip",
	    order = 120)]
	public class AudioClipCollection : Collection<AudioClip>
	{
	}
}