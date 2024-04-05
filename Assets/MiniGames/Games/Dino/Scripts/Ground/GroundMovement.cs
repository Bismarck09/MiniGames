using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private SpeedMovement _speedMovement;
    [SerializeField] private Vector2 _startPosition;

    private float _speed;

    private void FixedUpdate()
    {
        _speed = _speedMovement.Speed;
        transform.Translate(Vector2.left * _speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Barrier barrier))
            transform.position = _startPosition;
    }
}
