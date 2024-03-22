using UnityEngine;

public class RotateBird : MonoBehaviour
{
    [SerializeField] private float _rotationUp;
    [SerializeField] private float _rotationDown;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ( _rigidbody2D.velocity.y > 0)
            transform.rotation = Quaternion.Euler(0, 0, _rotationUp);
        else if (_rigidbody2D.velocity.y < -1)
            transform.rotation = Quaternion.Euler(0, 0, _rotationDown);
    }
}
