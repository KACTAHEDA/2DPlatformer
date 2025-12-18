using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private EnemyPatrol _enemyPatrol;
    [SerializeField] private SpriteRotator _rotator;
    [SerializeField] private EnemyAnimator _animator;

    private void Update()
    {
        Transform target = _enemyPatrol.TargetPoint;
        float direction = Mathf.Sign(target.position.x - transform.position.x);

        _enemyPatrol.Patrol();
        _mover.MoveToPoint(target);
        _rotator.Rotate(direction);
        _animator.Animate(_enemyPatrol.IsMoveing);
    }
}
