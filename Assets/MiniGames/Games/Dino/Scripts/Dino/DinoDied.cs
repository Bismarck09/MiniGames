using System;
using UnityEngine;

public class DinoDied : MonoBehaviour
{
    [SerializeField] private GameObject _restartButton;

    public event Action OnDinoDied;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ObstacleMovement obstacle))
            DiedDino();
    }

    private void DiedDino()
    {
        OnDinoDied?.Invoke();
        _restartButton.SetActive(true);

        Time.timeScale = 0f;
    }
}
