using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private MovementBird _bird;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void GameStart()
    {
        Time.timeScale = 1.0f;
        _startMenu.SetActive(false);
        _bird.gameObject.SetActive(true);
    }
}
