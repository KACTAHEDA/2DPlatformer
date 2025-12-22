using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private EnemyPatrol _enemyPatrol;
    [SerializeField] private SpriteRotator _rotator;
    [SerializeField] private EnemyAnimator _animator;

    private void FixedUpdate()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (_enemyPatrol.IsTargetReached(transform.position))
        {
            _mover.Stop();
            _animator.Animate(false);
            _enemyPatrol.SelectNextPoint();
            return;
        }

        float direction = _enemyPatrol.GetDirection(transform.position);

        _mover.Move(direction);
        _rotator.Rotate(direction);
        _animator.Animate(_mover.IsMoveing);
    }
}
