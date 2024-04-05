using UnityEngine;

public class SpeedMovement : MonoBehaviour
{
    private float _speed = 5;
    private float _elapsedTime;

    public float Speed => _speed;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > 1)
        {
            IncreseSpeed();
            _elapsedTime = 0;
        }
    }

    private void IncreseSpeed()
    {
        _speed += 0.1f;
    }
}
