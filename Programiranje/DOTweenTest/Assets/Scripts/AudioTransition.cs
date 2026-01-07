using DG.Tweening;
using UnityEngine;

public class AudioTransition : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void AudioFade()
    {
        if(_audioSource.volume <= 0.2f)
            _audioSource.DOFade(1f, 1f);

        else
            _audioSource.DOFade(0.1f, 1f);
    }
}
