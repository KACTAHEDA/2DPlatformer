using UnityEngine;

public class Player : MonoBehaviour , IDamageble , ITarget
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Mover _mover;
    [SerializeField] private SpriteRotator _rotator;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Health _health;
    [SerializeField] private CollisionHandler _collisionHandler;

    public Transform TargetTransform => transform;

    private void OnEnable()
    {
        _input.Jump += JumpPressed;
        _input.Attack += Attack;
        _collisionHandler.OnCoin += CollectCoin;
        _collisionHandler.OnHeal += CollectHeal;
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _input.Jump -= JumpPressed;
        _input.Attack -= Attack;
        _collisionHandler.OnCoin -= CollectCoin;
        _collisionHandler.OnHeal -= CollectHeal;
        _health.Died -= Die;
    }

    private void Update()
    {
        SetMovement();
    }

    private void Attack()
    {
        if (_attacker.CanAttack == false)
            return;

        _animator.PlayAttack();
        _attacker.TryAttack();
    }

    private void CollectCoin(Coin coin)
    {
        coin.Collect();
        _wallet.AddCoin();
    }

    private void CollectHeal(Heal heal)
    {        
        heal.Collect();
        _health.Heal(heal.HealValue);
    }

    private void SetMovement()
    {
        float direction = _input.MoveInput;
        float minToStop = 0.01f;

        if (Mathf.Abs(direction) > minToStop)
        {
            _mover.Move(direction);
            _rotator.Rotate(direction);
        }
        else
        {
            _mover.Stop();
        }

        _animator.UpdateState(_groundChecker.IsGrounded, Mathf.Abs(direction));
    }

    private void JumpPressed()
    {
        if (_groundChecker.IsGrounded)
        {
            _mover.Jump();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
