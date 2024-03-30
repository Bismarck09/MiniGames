using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float _pipeSpeed;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left *  _pipeSpeed * Time.fixedDeltaTime);
    }
}
