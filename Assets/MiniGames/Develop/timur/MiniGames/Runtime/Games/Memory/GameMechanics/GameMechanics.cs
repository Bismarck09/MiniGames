using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberOfPointsText;
    [SerializeField] private SpawnCards _spawnCards;
    [SerializeField] private GamePoints _gamePoints;

    private List<RotationCard> _numberOfOpenCards = new List<RotationCard>();

    private int _points;
    private int _currentNumberOfOpenCards;
    private bool _isActive;


    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        _numberOfPointsText.text = _points.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _numberOfOpenCards.Count < 2)
            CheckClick();

        if (_numberOfOpenCards.Count == 2 && !_isActive)
        {
            _gamePoints.AddPoint();
            CheckIdCards(_numberOfOpenCards[0], _numberOfOpenCards[1]);
        }
    }

    private void CheckClick()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out RotationCard card))
        {
            card = hit.collider.GetComponent<RotationCard>();
            _numberOfOpenCards.Add(card);
            RotateCard(card);

        }
    }

    private void RotateCard(RotationCard card)
    {
        if (card.IsFlip == false)
        {
            card.RotateCard(180);

        }
    }

    private void CheckIdCards(RotationCard firstCard, RotationCard secondCard)
    {
        DataCard card1 = firstCard.GetComponent<DataCard>();
        DataCard card2 = secondCard.GetComponent<DataCard>();

        if (card1.GetIndex() == card2.GetIndex()&& card1.isPayment && card2.isPayment && firstCard.gameObject != secondCard.gameObject)
        {
            card1.isPayment = false;
            card2.isPayment = false;
            _points++;
            _currentNumberOfOpenCards += 2;

            _numberOfPointsText.text = _points.ToString();
            _numberOfOpenCards.Clear();
            _spawnCards.CheckNumberOfOpenCards(_currentNumberOfOpenCards);
        }
        else
        {
            StartCoroutine(CloseCard(firstCard, secondCard));
        }
    }

    private IEnumerator CloseCard(RotationCard firstCard, RotationCard secondCard)
    {
        DataCard card1 = firstCard.GetComponent<DataCard>();
        DataCard card2 = secondCard.GetComponent<DataCard>();

        _isActive = true;

        yield return new WaitForSeconds(1);
        _numberOfOpenCards.Clear();
        if(card1.isPayment && card2.isPayment)
        {
            firstCard.RotateCard(0);
            secondCard.RotateCard(0);
        }

        _isActive = false;
    }
}
