using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Patroller : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private List<Point> _points;

    private SpriteRenderer _spriteRenderer;
    private int _curenPointtIndex = 0;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        Transform targetPoint = _points[_curenPointtIndex].transform;
        int minPointsToMove = 2;
        float minDistanceToPoint = 0.1f;

        if(_points.Count < minPointsToMove)
            return;

        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        bool isTargetReached = transform.position.IsEnoughClose(targetPoint.position, minDistanceToPoint);

        if (isTargetReached == true)
        {
            int nextPointIndex = ++_curenPointtIndex % _points.Count;
            Flip(_points[nextPointIndex].transform.position);
            _curenPointtIndex = nextPointIndex;
        }
    }

    private void Flip(Vector3 targetPosition)
    {
        _spriteRenderer.flipX = targetPosition.x < transform.position.x;
    }
}
