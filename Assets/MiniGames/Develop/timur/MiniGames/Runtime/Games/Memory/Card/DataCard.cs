using UnityEngine;

public class DataCard : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private RotationCard rotationCard;

    private int _index;

    public bool isPayment;

    private void Start()
    {
        isPayment = true;
    }
    public int GetIndex()
    {
        return _index;
    }

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    public void SetIndex(int index)
    {
        _index = index;
    }

    public bool FlipCard()
    {
        return rotationCard.ReturnFlip();
    }

}
