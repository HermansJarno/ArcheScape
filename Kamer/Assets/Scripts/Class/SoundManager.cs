using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

	private void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
