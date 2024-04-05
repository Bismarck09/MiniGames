using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private SpeedMovement _speedMovement;
    private float _speed;

    private void Start()
    {
        _speedMovement = FindObjectOfType<SpeedMovement>();
        _speed = _speedMovement.Speed;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * _speed * Time.fixedDeltaTime);
    }
}
