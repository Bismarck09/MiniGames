using TMPro;
using UnityEngine;

public class GamePoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private string _keyBestScore;

    private int _countPoints;
    private int _bestScore;

    private void Start()
    {
        _bestScore = PlayerPrefs.GetInt(_keyBestScore);
    }

    public void AddPoint()
    {
        _countPoints++;
        _pointsText.text = _countPoints.ToString();
    }

    public void SaveScoreRecord()
    {
        if (_countPoints > _bestScore)
        {
            _bestScore = _countPoints;
            PlayerPrefs.SetInt(_keyBestScore, _bestScore);
        }     
    }

    public void SaveMovesRecord()
    {
        if (_countPoints < _bestScore)
        {
            _bestScore = _countPoints;
            PlayerPrefs.SetInt(_keyBestScore, _bestScore);
        }
    }
}
