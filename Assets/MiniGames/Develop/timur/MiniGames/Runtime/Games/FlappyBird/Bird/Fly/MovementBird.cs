using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBird : MonoBehaviour
{
    [SerializeField] private float _flyForce;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            Fly();
    }

    public void Fly()
    {
        _rigidbody2D.velocity = Vector3.zero;
        _rigidbody2D.AddForce(new Vector2(0, _flyForce));
    }
}
