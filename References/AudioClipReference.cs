using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class AudioClipReference : BaseReference<AudioClip, AudioClipVariable>
	{
	    public AudioClipReference() : base() { }
	    public AudioClipReference(AudioClip value) : base(value) { }
	}
}