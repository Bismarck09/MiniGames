using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkToOption : MonoBehaviour
{
    [SerializeField] private GameObject _option;

    public void OpenOption()
    {
        _option.SetActive(true);
    }

    public void CloseOption()
    {
        _option.SetActive(false);
    }
}
