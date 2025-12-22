using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Point> _points;
    [SerializeField] private float _minDistanceToPoint = 0.1f;

    private int _curenPointIndex;

    public Transform TargetPoint => _points[_curenPointIndex].transform;

    public float MinDistanceToPoint => _minDistanceToPoint;

    public void SelectNextPoint()
    {
        _curenPointIndex = ++_curenPointIndex % _points.Count;
    }

    public float GetDirection(Vector3 position)
    {
        float deltaX = TargetPoint.position.x - position.x;

        return Mathf.Sign(deltaX);
    }

    public bool IsTargetReached(Vector3 curentPosition)
    {
        float distance = Mathf.Abs(TargetPoint.position.x - curentPosition.x);
        return distance <= _minDistanceToPoint;
    }
}
