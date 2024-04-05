using TMPro;
using UnityEngine;

public class Moved : MonoBehaviour
{
    [SerializeField] private ClickOnCard _clickOnCard;
    [SerializeField] private TextMeshProUGUI _numberOfMoveText;

    private int _numberOfMove;

    private void OnEnable()
    {
        _clickOnCard.OnCardRotated += AddMove;
    }

    private void OnDisable()
    {
        _clickOnCard.OnCardRotated -= AddMove;
    }

    private void AddMove()
    {
        _numberOfMove++;
        _numberOfMoveText.text = _numberOfMove.ToString();
    }

    public void CheckNumberOfMove()
    {
        if (_numberOfMove < PlayerPrefs.GetInt("MemoryRecord"))
            PlayerPrefs.SetInt("MemoryRecord", _numberOfMove);
    }
}
