using UnityEngine;

public class ScreenPosition : MonoBehaviour
{
    [SerializeField] private ScreenOrientation _screenOrientation;

    private void Awake()
    {
        LoadScreenPosition();
    }

    public void LoadScreenPosition()
    {
        Screen.orientation = _screenOrientation;
    }
}
