using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateRecord : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dinoRecord;
    [SerializeField] private TextMeshProUGUI _memoryRecord;
    [SerializeField] private TextMeshProUGUI _mathQuestRecord;
    [SerializeField] private TextMeshProUGUI _waveMasterRecord;

    private void Start()
    {
        UpdateRecords();
    }

    private void UpdateRecords()
    {
        _dinoRecord.text = PlayerPrefs.GetInt("DinoRecord").ToString();
        _memoryRecord.text = PlayerPrefs.GetInt("MemoryRecord").ToString();
        _mathQuestRecord.text = PlayerPrefs.GetInt("MathQuestRecord").ToString();
        _waveMasterRecord.text = PlayerPrefs.GetInt("WaveMasterRecord").ToString();
    }
}
