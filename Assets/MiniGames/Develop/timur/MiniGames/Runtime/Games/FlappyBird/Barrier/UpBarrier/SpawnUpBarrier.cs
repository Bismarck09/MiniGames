using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUpBarrier : MonoBehaviour
{
    private void Start()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0f, Screen.height));
    }
}
