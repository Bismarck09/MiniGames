using System;
using System.Collections;
using UnityEngine;

public class IDCards : MonoBehaviour
{
    [SerializeField] private ClickOnCard _clickOnCard;

    public event Action OnSameCardsOpened;

    public void CheckIDCards(CardRotation card1, CardRotation card2)
    {
        Card firstCard = card1.GetComponent<Card>();
        Card secondCard = card2.GetComponent<Card>();

        if (firstCard.CardID == secondCard.CardID)
        {
            OnSameCardsOpened();
            _clickOnCard.IsRotating = true;
        }
        else
        {
            StartCoroutine(RotationCards(card1, card2));
        }
    }

    private IEnumerator RotationCards(CardRotation card1, CardRotation card2)
    {
        yield return new WaitForSeconds(1);

        card1.RotateCard();
        card2.RotateCard();

        _clickOnCard.IsRotating = true;
    }
}
