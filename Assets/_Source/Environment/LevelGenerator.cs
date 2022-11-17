using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private List<LevelPrefab> _levelPrefabs;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _finishTransform;

    public void GenerateLevel(int levelLength)
    {
        for (int i = 0; i < levelLength; i++)
        {
            LevelPrefab lastInstance = Instantiate(_levelPrefabs[Random.Range(0, _levelPrefabs.Count )],
                new Vector2(_spawnPoint.position.x, _spawnPoint.position.y), new Quaternion());
            _spawnPoint.position = new Vector2(lastInstance.SpawnPoint.position.x, lastInstance.SpawnPoint.position.y);
            lastInstance.HideSomeObjects();
        }
        _finishTransform.position = new Vector2(_spawnPoint.position.x, _spawnPoint.position.y+5);
    }
}
