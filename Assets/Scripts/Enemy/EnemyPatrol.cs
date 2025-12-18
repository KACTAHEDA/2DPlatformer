using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Point> _points;

    private int _curenPointtIndex;
    private float _minDistanceToPoint = 0.2f;

    public bool IsMoveing { get; private set; }
    public Transform TargetPoint => _points[_curenPointtIndex].transform;
    public bool IsTargetReached => transform.position.IsEnoughClose(TargetPoint.position, _minDistanceToPoint);

    public void Patrol()
    {
        int minPointsToMove = 2;

        if (_points.Count < minPointsToMove)
        {
            IsMoveing = false;
            return;
        }



        if (IsTargetReached == true)
        {
            int nextPointIndex = ++_curenPointtIndex % _points.Count;
            _curenPointtIndex = nextPointIndex;
        }
    }
}
