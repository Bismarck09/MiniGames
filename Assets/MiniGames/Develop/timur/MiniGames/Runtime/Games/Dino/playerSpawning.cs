using UnityEngine;

public class playerSpawning : MonoBehaviour
{
   
    void Start()
    {
        Vector3 leftBottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        float playerWidth = transform.localScale.x / 2;
        Vector3 newPos = transform.position;

        newPos.x = leftBottomCorner.x + playerWidth;
        transform.position = newPos;
        
        transform.position = new Vector2(transform.position.x + 1, transform.position.y);
    }
}