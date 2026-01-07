using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Point> _spawnPoints;

    private void Awake()
    {
        SpawnItems();  
    }

    private void SpawnItems()
    {
        foreach (var point in _spawnPoints)
        {
            var coin = Instantiate(_coinPrefab, point.transform.position, Quaternion.identity);
            coin.Collected += DestroyCoin;
        }
    }

    private void DestroyCoin(Coin coin)
    {
        coin.Collected -= DestroyCoin;
        Destroy(coin.gameObject);
    }
}
