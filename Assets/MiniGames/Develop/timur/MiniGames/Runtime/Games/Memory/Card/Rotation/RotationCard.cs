using UnityEngine;

public class RotationCard : MonoBehaviour
{
    private bool _isFlip;

    public bool IsFlip => _isFlip;

    public void RotateCard(float rotate)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, rotate, 0));
        CheckFlip();

    }

    private void CheckFlip()
    {
        if (transform.rotation.eulerAngles.y == 180)
            _isFlip = true;
        else if (transform.rotation.eulerAngles.y == 0)
            _isFlip = false;
    }

    public bool ReturnFlip()
    {
        return _isFlip;
    }
}
