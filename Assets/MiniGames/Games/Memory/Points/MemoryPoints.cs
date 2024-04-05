using TMPro;
using UnityEngine;

public class MemoryPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private IDCards _idCard;

    private int _points;

    private void OnEnable()
    {
        _idCard.OnSameCardsOpened += AddPoints;
    }

    private void OnDisable()
    {
        _idCard.OnSameCardsOpened -= AddPoints;
    }

    private void AddPoints()
    {
        _points++;

        _pointsText.text = _points.ToString();
    }
}
