using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBegin : MonoBehaviour
{
    [SerializeField] private GameObject _comment;

    private void Start()
    {
        _comment.SetActive(true);
        StartCoroutine(CloseCommitAfterTime());
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private IEnumerator CloseCommitAfterTime()
    {
        yield return new WaitForSeconds(5);
        _comment.SetActive(false);
    }

    public void CloseCommit()
    {
        _comment.SetActive(false);
    }
}
