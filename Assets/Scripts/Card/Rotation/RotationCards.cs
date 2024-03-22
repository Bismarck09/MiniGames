using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RotationCard : MonoBehaviour
{
    private bool _isFlip;

    public bool IsFlip => _isFlip;

    public void RotateCard(float rotate)
    {
        transform.rotation = new Quaternion(0, rotate, 0, 0);
        CheckFlip();
    }

    private void CheckFlip()
    {
        if (transform.rotation.eulerAngles.y == 180)
            _isFlip = true;
        else if (transform.rotation.eulerAngles.y == 0)
            _isFlip = false;
    }
}
