using System.Collections.Generic;
using UnityEngine;

public class SpawnCards : MonoBehaviour
{
    [SerializeField] private List<Vector3> _spawnPosition;
    [SerializeField] private List<GameObject> _spawnObjects;
    [SerializeField] private GameObject _buttonStart;

    private int _spawnObjectIndex;

    private void Start()
    {
        _buttonStart.SetActive(true);
    }

    public void SpawnAllCards()
    {
        _buttonStart.SetActive(false);

        for (int i = 0; i < _spawnPosition.Count; i++)
        {
            _spawnObjectIndex = Random.Range(0, _spawnObjects.Count);
            Instantiate(_spawnObjects[_spawnObjectIndex], _spawnPosition[i], Quaternion.identity);

            _spawnObjects.Remove(_spawnObjects[_spawnObjectIndex]);
        }
    }


}
