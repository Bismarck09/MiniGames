using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;
    [SerializeField] private Vector2 _spawnPosition;

    private float _spawnSpeed;
    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _spawnSpeed)
        {
            ChooseObstacle();
            _elapsedTime = 0;
        }
    }

    private void ChooseObstacle()
    {
        int obstacleNumber = Random.Range(0, _obstacles.Count);

        SpawningObstacle(obstacleNumber);
    }

    private void SpawningObstacle(int obstacleNumber)
    {
        GameObject obstacle = Instantiate(_obstacles[obstacleNumber], _spawnPosition, Quaternion.identity);

        _spawnSpeed = Random.Range(1.7f,2.5f);
    }
}
