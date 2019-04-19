using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

namespace PR_Test_Content
{
    public class AudioClipReferenceTest : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private bool _useRandomClickNoise;

        [Header("Data")]
        [SerializeField]
        private AudioClipReference _clickAudioClipReference;

        [SerializeField]
        private AudioClipCollection _randomAudioClipCollection;

        private void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            var clip = _useRandomClickNoise
                ? _randomAudioClipCollection[Random.Range(0, _randomAudioClipCollection.Count)]
                : _clickAudioClipReference.Value;

            if (!_audioSource.isPlaying)
            {
                _audioSource.clip = clip;
                _audioSource.Play();
            }
        }
    }
}
