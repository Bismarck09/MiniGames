using System.Collections.Generic;
using UnityEngine;

public class SpawnCards : MonoBehaviour
{
    [SerializeField] private LevelGame _levelGame;
    [SerializeField] private DataCard _card;
    [SerializeField] private GamePoints _gamePoints;
    [SerializeField] private List<Sprite> _cardSprite;
    [SerializeField] private List<Vector2> _levelPositions1;
    [SerializeField] private List<Vector2> _levelPositions2;
    [SerializeField] private List<Vector2> _levelPositions3;

    private List<int> _indexCard = new List<int>(){ 0, 0, 1, 1, 2, 2, 3, 3, 4, 4};
    private int _numberOfCards;


    private void OnEnable()
    {
        _levelGame.OnLevelChoose += SpawningCards;
    }

    private void OnDisable()
    {
        _levelGame.OnLevelChoose -= SpawningCards;
    }

    private void SpawningCards(int numberOfCards, int level)
    {
        _numberOfCards = numberOfCards;
        List<Vector2> spawnPosition = ChooseSpawnPositions(level);

        for (int i = 0; i < numberOfCards; i++)
        {
            DataCard newCard = Instantiate(_card, spawnPosition[i], Quaternion.identity);
            int idCard = Random.Range(0, numberOfCards - i);
            newCard.SetSprite(_cardSprite[idCard]);
            newCard.SetIndex(_indexCard[idCard]);

            _cardSprite.Remove(_cardSprite[idCard]);
            _indexCard.Remove(_indexCard[idCard]);
        }
    }

    private List<Vector2> ChooseSpawnPositions(int level)
    {
        if (level == 0)
            return _levelPositions1;
        else if (level == 1)
            return _levelPositions2;

        return _levelPositions3;
    }

    public void CheckNumberOfOpenCards(int numberOpenCard)
    {
        if (_numberOfCards <= numberOpenCard)
            _gamePoints.SaveMovesRecord();
    }
}
