using UnityEngine;

public class SwitchingAudio : MonoBehaviour
{
    [SerializeField] private GameObject _muteSoursImage;
    [SerializeField] private GameObject _unmuteSoursImage;

    private AudioSource _audioSource;
    private bool _isPlaying;

    public bool IsPlaying => _isPlaying;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _isPlaying = !_audioSource.mute;
    }

    public void SwitchAudio()
    {
        _isPlaying = !_isPlaying;
        _audioSource.mute = !_isPlaying;

        SwitchImage();
        RememberAudioInfo();
    }

    private void SwitchImage()
    {
        _unmuteSoursImage.SetActive(_isPlaying);
        _muteSoursImage.SetActive(!_isPlaying);
    }

    private void RememberAudioInfo()
    {
        if (_isPlaying)
            PlayerPrefs.SetInt("AudioEnable", 1);
        else
            PlayerPrefs.SetInt("AudioEnable", 0);
    }
}
