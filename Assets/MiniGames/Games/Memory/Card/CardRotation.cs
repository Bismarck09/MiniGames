using UnityEngine;

public class CardRotation : MonoBehaviour
{
    private bool _isRotate;

    public bool IsRotate => _isRotate;

    public void RotateCard()
    {
        transform.Rotate(0, 180, 0);
        _isRotate = !_isRotate;
    }
}
