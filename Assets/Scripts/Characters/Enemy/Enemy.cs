using UnityEngine;

public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private Mover _mover;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private EnemyPatrol _enemyPatrol;
    [SerializeField] private EnemyVision _vision;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Health _health;
    [SerializeField] private float _stopDistance = 1.2f;
    [SerializeField] private CharacterVisual _visual;

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
        bool isGrounded = _groundChecker.IsGrounded;
        bool isMoveing = _mover.IsMoveing;

        _visual.UpdateVisual(isGrounded, direction, isMoveing);
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
      
        _attacker.TryAttack(out bool isAttack);

        if(isAttack == true)
        {
            _visual.PlayAttack();
        }

    }

    public float TakeDamage(float damage)
    {
        float applyedDamage = Mathf.Min(_health.CurentHealth, damage);
        _health.TakeDamage(applyedDamage);

        return applyedDamage;
    }
}
