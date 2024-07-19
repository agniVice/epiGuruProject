using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacleSetPrefabs;

    private void Start()
    {
        SpawnRandomObstacleSet();
    }
    private void SpawnRandomObstacleSet() => Instantiate(_obstacleSetPrefabs[Random.Range(0, _obstacleSetPrefabs.Count)], transform.parent);
}
