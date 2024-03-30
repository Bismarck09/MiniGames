using UnityEngine;

public class WorkToProfile : MonoBehaviour
{
    [SerializeField] private GameObject _profilePanel;

    public void OpenProfile()
    {
        _profilePanel.SetActive(true);
    }

    public void CloseProfile()
    {
        _profilePanel.SetActive(false);
    }
}
