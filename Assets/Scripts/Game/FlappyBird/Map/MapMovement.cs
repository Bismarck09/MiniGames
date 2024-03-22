using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Barrier"))
            transform.position = _startPosition;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * 2.2f * Time.fixedDeltaTime);
    }
}
