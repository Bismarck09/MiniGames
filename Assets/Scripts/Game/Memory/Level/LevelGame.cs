using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGame : MonoBehaviour
{
    [SerializeField] private List<int> _numberOfCards;
    [SerializeField] private List<GameObject> _buttonsLevel;

    public event Action<int, int> OnLevelChoose;

    public void ChooseLevel(int level)
    {
        OnLevelChoose?.Invoke(_numberOfCards[level], level);
        CloseButtonsLevel();
    }

    private void CloseButtonsLevel()
    {
        foreach (var button in _buttonsLevel)
        {
            button.gameObject.SetActive(false);
        }
    }
}
