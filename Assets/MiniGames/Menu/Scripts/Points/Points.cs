using TMPro;
using UnityEngine;

public class DinoPoints : MonoBehaviour
{
    [SerializeField] private DinoDied _dinoDied;
    [SerializeField] private TextMeshProUGUI _numberOfPointsText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    private float _numberOfPoints;
    private float _elapsedTimeToAddPoint;
    private float _elapsedTimeToIncreaseMultiplier;
    private float _timeAfterStartOfGame = 1;

    private void Start()
    {
        _bestScoreText.text = PlayerPrefs.GetInt("DinoRecord").ToString("D5");
    }

    private void OnEnable()
    {
        _dinoDied.OnDinoDied += CheckPoints;
    }

    private void OnDisable()
    {
        _dinoDied.OnDinoDied -= CheckPoints;
    }

    private void Update()
    {
        _elapsedTimeToAddPoint += Time.deltaTime;
        _elapsedTimeToIncreaseMultiplier += Time.deltaTime;


        if (_elapsedTimeToAddPoint >= 0.3f / _timeAfterStartOfGame)
        {
            AddPoints();
            _elapsedTimeToAddPoint = 0;
        }

        if (_elapsedTimeToIncreaseMultiplier >= 1)
        {
            IncreaseMultiplier();
            _elapsedTimeToIncreaseMultiplier = 0;
        }
    }

    public void CheckPoints()
    {
        if (PlayerPrefs.GetInt("DinoRecord") < _numberOfPoints)
            SetNewRecord();
    }

    private void AddPoints()
    {
        _numberOfPoints++;
        _numberOfPointsText.text = Mathf.FloorToInt(_numberOfPoints).ToString("D5");
    }


    private void SetNewRecord()
    {
        PlayerPrefs.SetInt("DinoRecord", Mathf.FloorToInt(_numberOfPoints));
    }

    private void IncreaseMultiplier()
    {
         _timeAfterStartOfGame += 0.1f;
    }
}
