using UnityEngine;

public class DinoSpawn : MonoBehaviour
{
    private Vector3 leftBottomCorner;

    private void Start()
    {
       SpawnDino();
    }

    private void SpawnDino()
    {
        leftBottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        Vector3 newPos = transform.position;
        newPos.x = leftBottomCorner.x + 2;

        transform.position = newPos;
    }
}
