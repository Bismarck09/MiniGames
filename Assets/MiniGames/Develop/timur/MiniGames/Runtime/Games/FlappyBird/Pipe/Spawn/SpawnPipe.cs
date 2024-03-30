using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    [SerializeField] private GameObject _pipeObject;
    [SerializeField] private int _poolSize;
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _minimumSpawnedY;
    [SerializeField] private float _maximumSpawnedY;

    private List<GameObject> _pipePool;
    private float _elapsedTime = 5;
    private int _currentPipe;

    private void Awake()
    {
        _pipePool = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            _pipePool.Add(Instantiate(_pipeObject, transform.position, Quaternion.identity));
            _pipePool[i].SetActive(false);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _spawnRate)
        {
            SpawningPipe();
            _elapsedTime = 0;
        }
    }

    private void SpawningPipe()
    {
        if (_pipePool.Count > 0)
        {
            if (_currentPipe >= _poolSize)
                _currentPipe = 0;

            EnablePipe();
        }
    }

    private void EnablePipe()
    {
        Vector2 newPosition = new Vector2(transform.position.x, Random.Range(_minimumSpawnedY, _maximumSpawnedY));

        _pipePool[_currentPipe].SetActive(true);
        _pipePool[_currentPipe].transform.position = newPosition;

        _currentPipe++;
    }

}
