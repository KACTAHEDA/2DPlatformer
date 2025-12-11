using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Point> _points;
    [SerializeField] private Mover _mover;
    [SerializeField] private FlipSprite _flip;

    private int _curenPointtIndex = 0;

    public bool IsMoving { get; private set; }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Transform targetPoint = _points[_curenPointtIndex].transform;
        int minPointsToMove = 2;
        float minDistanceToPoint = 0.1f;

        if (_points.Count < minPointsToMove)
        {
            IsMoving = false;
            return;
        }

        IsMoving = true;
        _mover.MoveToPoint(targetPoint);
        _flip.FlipTo(targetPoint.position);

        bool isTargetReached = transform.position.IsEnoughClose(targetPoint.position, minDistanceToPoint);

        if (isTargetReached == true)
        {
            int nextPointIndex = ++_curenPointtIndex % _points.Count;
            _curenPointtIndex = nextPointIndex;
        }
    }
}
