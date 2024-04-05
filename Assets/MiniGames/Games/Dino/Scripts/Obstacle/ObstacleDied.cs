using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDied : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Barrier barrier))
            Destroy(gameObject);
    }
}
