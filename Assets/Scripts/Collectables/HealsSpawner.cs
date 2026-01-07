using System.Collections.Generic;
using UnityEngine;

public class HealsSpawner : MonoBehaviour
{
    [SerializeField] private Heal _healPrefab;
    [SerializeField] private List<Point> _spawnPoints;
    [SerializeField] private int _healCount = 3;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (_spawnPoints.Count < _healCount)
            return;

        List<Point> freePoints = new List<Point>(_spawnPoints);

        int count = Mathf.Min(_healCount, freePoints.Count);

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, freePoints.Count);
            Point point = freePoints[index];
            freePoints.RemoveAt(index);

            Heal heal = Instantiate(_healPrefab, point.transform.position, Quaternion.identity);
            heal.Collected += DestroyHeal;
        }
    }

    private void DestroyHeal(Heal heal)
    {
        heal.Collected -= DestroyHeal;
        Destroy(heal.gameObject);
    }
}