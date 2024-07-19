using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public static GroundSpawner Instance { get; private set; }

    [Header("Common")]
    [SerializeField] private GameObject _groundPrefab;

    [Space]
    [Header("Ground Settings")]

    [SerializeField] private float _groundSize;

    [Range(0, 10)] [SerializeField] private int _startGroundCount = 5;
    [Range(2, 10)] [SerializeField] private float _startGroundSpeed = 5;
    [Range(2, 10)] [SerializeField] private int _groundsToChangeSpeed = 10;
    [Range(1, 5)] [SerializeField] private float _multiplierSpeed = 1.2f;

    private List<GameObject> _grounds = new List<GameObject>();

    private float _currentSpeed;
    private int _groundCount;
    
    private void Awake()
    {
        if (Instance != this && Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
    private void Start()
    {
        _currentSpeed = _startGroundSpeed;

        for (int i = 0; i < _startGroundCount; i++)
            SpawnGround(false, i <= 1);
    }
    public void SpawnGround(bool isCounterEnabled = true, bool destroyObstacles = false)
    {
        float zPos;

        if (_grounds.Count != 0)
            zPos = _groundSize + _grounds[_grounds.Count - 1].transform.position.z;
        else
            zPos = -_groundSize;

        var ground = Instantiate(_groundPrefab, new Vector3(0, 0, zPos), Quaternion.identity);
        ground.GetComponent<GroundMovement>().SetSpeed(_currentSpeed);
        _grounds.Add(ground);

        if (destroyObstacles) 
            Destroy(ground.GetComponentInChildren<ObstacleSpawner>().gameObject);

        _groundCount += 1*Convert.ToInt32(isCounterEnabled);

        CheckDifficult();
    }
    private void CheckDifficult()
    {
        if (_groundCount >= _groundsToChangeSpeed)
        {
            _groundCount = 0;
            _currentSpeed *= _multiplierSpeed;

            foreach (var ground in _grounds)
                ground.GetComponent<GroundMovement>().SetSpeed(_currentSpeed);
        }
    }
    public void DestroyLastGround()
    {
        Destroy(_grounds[0]);
        _grounds.Remove(_grounds[0]);
    }
}
