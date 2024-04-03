using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingSettings : MonoBehaviour
{
    [SerializeField] private SwitchingAudio _switchingAudio;
    [SerializeField] private GameObject _muteSoursImage;
    [SerializeField] private GameObject _unmuteSoursImage;

    private bool _isOpening;
    
    public void SwitchSettings()
    {
       if(_isOpening)
            CloseSettings();
       else
            OpenSettings();

        _isOpening = !_isOpening;
    }

    private void OpenSettings()
    {
        if (_switchingAudio.IsPlaying)
            _unmuteSoursImage.SetActive(true);
        else
            _muteSoursImage.SetActive(true);
    }

    private void CloseSettings()
    {
        _muteSoursImage.SetActive(false);
        _unmuteSoursImage.SetActive(false);
    }
}
