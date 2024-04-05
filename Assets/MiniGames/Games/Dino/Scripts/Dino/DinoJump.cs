using UnityEngine;

public class DinoJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2d;
    private bool _isGrounded;

    private void Start()
    {
        _isGrounded = true;
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isGrounded)
            JumpDino();
    }

    private void JumpDino()
    {
        _rigidbody2d.AddForce(Vector2.up * _jumpForce);
        _isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
            _isGrounded = true;
    }
}
