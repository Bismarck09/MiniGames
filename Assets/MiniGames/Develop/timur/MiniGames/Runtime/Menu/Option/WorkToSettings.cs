using UnityEngine;

public class WorkToSettings : MonoBehaviour
{
    [SerializeField] private GameObject _mute;
    [SerializeField] private GameObject _unMute;

    private bool _isOpen;

    public void Mute()
    {
        if(!_isOpen) {
        
            if (PlayerPrefs.GetInt("Mute") == 1)
                EnableSprite(_mute);
            else
                EnableSprite(_unMute);
                
            _isOpen = true;
        }
        else {
            DisableSprite();
            _isOpen = false;
        }
            
    }
    
    private void EnableSprite(GameObject sprite)
    {
        sprite.SetActive(true);
    }
    
    private void DisableSprite()
    {
        _mute.SetActive(false);
        _unMute.SetActive(false);
    }
    
}
