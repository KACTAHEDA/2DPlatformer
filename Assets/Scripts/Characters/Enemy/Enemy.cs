using UnityEngine;

public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private Mover _mover;
    [SerializeField] private EnemyPatrol _enemyPatrol;
    [SerializeField] private SpriteRotator _rotator;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private EnemyVision _vision;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Health _health;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private float _attackDistance = 1.1f;
    [SerializeField] private float _stopDistance = 1.2f;

    private ITarget _targetPlayer;

    public Transform TargetTransform => transform;

    private void OnEnable()
    {
        _vision.PlayerDetected += SetTarget;
        _vision.PlayerLost += ClearTarget;
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _vision.PlayerDetected -= SetTarget;
        _vision.PlayerLost -= ClearTarget;
        _health.Died -= Die;
    }

    private void FixedUpdate()
    {
        if (_targetPlayer != null)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    private void Update()
    {
        TryAttack();
        UpdateVisual();
    }

    private void Patrol()
    {
        if (_enemyPatrol.IsTargetReached(transform.position))
        {
            _mover.Stop();
            _animator.PlayMovement(false);
            _enemyPatrol.SelectNextPoint();
            return;
        }

        float direction = _enemyPatrol.GetDirection(transform.position);

        _mover.Move(direction);
    }

    private void Chase()
    {
        float deltaX = _targetPlayer.TargetTransform.position.x - transform.position.x;
        float distance = Mathf.Abs(deltaX);

        if (_targetPlayer == null || _targetPlayer.TargetTransform == null || distance <= _stopDistance)
        {
            _mover.Stop();
            return;
        }

        float direction = Mathf.Sign(deltaX);

        _mover.Move(direction);
    }

    private void UpdateVisual()
    {
        float direction = _mover.Direction;

        _rotator.Rotate(direction);
        _animator.PlayMovement(_mover.IsMoveing);
    }

    private void SetTarget(ITarget target)
    {
        _targetPlayer = target;
    }

    private void ClearTarget()
    {
        _targetPlayer = null;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void TryAttack()
    {
        if (_targetPlayer == null)
            return;

        if (_attacker.CanAttack == false)
            return;

        float distance = Mathf.Abs(_targetPlayer.TargetTransform.position.x - transform.position.x);

        if (distance > _attackDistance)
            return;

        _animator.PlayAttack();
        _attacker.TryAttack();

    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
