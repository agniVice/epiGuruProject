using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _coinPositions;
    [SerializeField] private GameObject _coinPrefab;

    [Range(0, 15)][SerializeField] private int _minCount;
    [Range(0, 15)][SerializeField] private int _maxCount;

    private void Start()
    {
        int coinsCount = Random.Range(_minCount, _maxCount);

        for (int i = 0; i < coinsCount; i++)
        {
            var coin = Instantiate(_coinPrefab, transform.parent);
            int randomPos = Random.Range(0, _coinPositions.Count);
            coin.transform.position = _coinPositions[randomPos].position;
            _coinPositions.RemoveAt(randomPos);
        }
    }
}
