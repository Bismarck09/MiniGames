using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedBird : MonoBehaviour
{
    [SerializeField] private GameObject _diedWindow;
    [SerializeField] private GamePoints _gamePoints;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DiedObject"))
            Died();
    }

    private void Died()
    {
        _diedWindow.SetActive(true);
        Time.timeScale = 0f;
        _gamePoints.SaveScoreRecord();
    }
}
