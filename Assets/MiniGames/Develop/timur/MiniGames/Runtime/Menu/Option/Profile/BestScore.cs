using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScoreFlappyBirdText;
    [SerializeField] private TextMeshProUGUI _bestScoreDinoText;
    [SerializeField] private TextMeshProUGUI _bestScoreMemoryText;
    [SerializeField] private TextMeshProUGUI _bestScoreMathQuestText;
    [SerializeField] private TextMeshProUGUI _bestScoreWaveMasterText;

    public void TakeBestScores()
    {
        _bestScoreFlappyBirdText.text = PlayerPrefs.GetInt("FlappyBirdRecord").ToString();
        _bestScoreDinoText.text = PlayerPrefs.GetInt("DinoRecord").ToString();
        _bestScoreMemoryText.text = PlayerPrefs.GetInt("MemoryRecord").ToString();
        _bestScoreMathQuestText.text = PlayerPrefs.GetInt("MathQuestRecord").ToString();
        _bestScoreWaveMasterText.text = PlayerPrefs.GetInt("WaveMasterRecord").ToString();
    }
}
