using UnityEngine;

public class SwitchingRecord : MonoBehaviour
{
    [SerializeField] private GameObject _recordObject;

    public void OpenRecords()
    {
        _recordObject.SetActive(true);
    }

    public void CloseRecords()
    {
        _recordObject.SetActive(false);
    }
}
