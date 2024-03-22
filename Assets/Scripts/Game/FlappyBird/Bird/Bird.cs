using TMPro;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointsText;

    private int _countPoints;
    
    public void AddPoint()
    {
        _countPoints++;
        _pointsText.text = _countPoints.ToString();
    }
}
