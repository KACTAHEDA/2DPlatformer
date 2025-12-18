using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private Door _finisher;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Mover _mover;
    [SerializeField] private SpriteRotator _rotator;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAnimator _animator;

    private void Update()
    {
        Play();      
    }

    private void OnEnable()
    {
        _collisionHandler.OnCoin += CollectCoin;
        _collisionHandler.OnDoor += FinishLevel;
    }

    private void OnDisable()
    {
        _collisionHandler.OnCoin -= CollectCoin;
        _collisionHandler.OnDoor -= FinishLevel;
    }

    private void CollectCoin(Coin coin)
    {
        coin.Collect();
        _wallet.AddCoin();
    }

    private void FinishLevel()
    {
        _finisher.LevelPased();
    }

    private void Play()
    {
        float direction = _input.MoveInput;

            _mover.Move(direction);


        if (_input.JumpPressed && _groundChecker.IsGrounded)
        {
            _mover.Jump();
        }

        _rotator.Rotate(direction);

        _animator.UpdateState(_groundChecker.IsGrounded, Mathf.Abs(direction));
    }
}
