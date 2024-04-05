using System;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnCard : MonoBehaviour
{
    [SerializeField] private IDCards _idCards;

    private List<CardRotation> _cards;

    public bool IsRotating;

    public event Action OnCardRotated;

    private void Start()
    {
        _cards = new List<CardRotation>();
        IsRotating = true;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                CheckCkick(touch);
        }
    }

    private void CheckCkick(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider == null)
            return;

        if (hit.collider.gameObject.TryGetComponent(out CardRotation card) && card.IsRotate == false && IsRotating)
        {
            _cards.Add(card);
            RotateCard(card);

            if (_cards.Count >= 2)
            {
                IsRotating = false;
                _idCards.CheckIDCards(_cards[0], _cards[1]);
                OnCardRotated?.Invoke();

                _cards.Clear();
            }
        }
    }

    private void RotateCard(CardRotation card)
    {
        if (card.IsRotate == false)
            card.RotateCard();
    }
}
