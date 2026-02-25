using UnityEngine;

public class Player : MonoBehaviour, IDamageble, ITarget
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Mover _mover;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Health _health;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private CharacterVisual _visual;
    [SerializeField] private SkillsSystem _skillsSystem;

    public Transform TargetTransform => transform;

    private void OnEnable()
    {
        _input.Jump += JumpPressed;
        _input.Attack += Attack;
        _collisionHandler.OnCoin += CollectCoin;
        _collisionHandler.OnHeal += CollectHeal;
        _health.Died += Die;
        _input.SkillOnePressed += UseSkillOne;
    }

    private void OnDisable()
    {
        _input.Jump -= JumpPressed;
        _input.Attack -= Attack;
        _collisionHandler.OnCoin -= CollectCoin;
        _collisionHandler.OnHeal -= CollectHeal;
        _health.Died -= Die;
        _input.SkillOnePressed -= UseSkillOne;
    }

    private void Update()
    {
        SetMovement();
    }

    private void UseSkillOne()
    {
        _skillsSystem.UseSkillOne();
    }

    private void Attack()
    {
        if (_attacker.CanAttack == false)
            return;

        _attacker.TryAttack(out bool isAttack);

        if (isAttack)
            _visual.PlayAttack();
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
        bool isGrounded = _groundChecker.IsGrounded;
        bool isMoveing = _mover.IsMoveing;

        if (Mathf.Abs(direction) > minToStop)
        {
            _mover.Move(direction);
        }
        else
        {
            _mover.Stop();
        }

        _visual.UpdateVisual(isGrounded, direction, isMoveing);
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

    public float TakeDamage(float damage)
    {
        float applyedDamage = Mathf.Min(_health.CurentHealth, damage);
        _health.TakeDamage(applyedDamage);

        return applyedDamage;
    }
}
