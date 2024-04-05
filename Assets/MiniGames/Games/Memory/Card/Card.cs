using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private int _cardID;
     
    public int CardID => _cardID;
}
