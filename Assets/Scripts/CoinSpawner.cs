using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Point> _spawnPoints;

    private void Awake()
    {
        SpawnCoins();  
    }

    private void SpawnCoins()
    {
        foreach (var point in _spawnPoints)
        {
            Instantiate(_coinPrefab, point.transform.position, Quaternion.identity);
        }
    }
}
