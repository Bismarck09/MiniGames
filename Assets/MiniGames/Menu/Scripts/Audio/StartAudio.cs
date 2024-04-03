using UnityEngine;

public class StartAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        CheckAudio();
    }

    private void CheckAudio()
    {
        if (PlayerPrefs.GetInt("AudioEnable") == 1)
            _audioSource.mute = false;
        else 
            _audioSource.mute = true;
    }
}
