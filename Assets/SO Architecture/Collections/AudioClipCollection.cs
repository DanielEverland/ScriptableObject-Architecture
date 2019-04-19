using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "AudioClipCollection.asset",
	    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "AudioClip",
	    order = 120)]
	public class AudioClipCollection : Collection<AudioClip>
	{
	}
}