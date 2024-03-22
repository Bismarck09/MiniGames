using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCard : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _index;
    
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
}
