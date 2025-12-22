using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Mover _mover;
    [SerializeField] private SpriteRotator _rotator;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private CollisionHandler _collisionHandler;

    private void OnEnable()
    {
        _input.Jump += JumpPressed;
        _collisionHandler.OnCoin += CollectCoin;
    }

    private void OnDisable()
    {
        _input.Jump -= JumpPressed;
        _collisionHandler.OnCoin -= CollectCoin;
    }

    private void Update()
    {
        SetMovement();
    }

    private void CollectCoin(Coin coin)
    {
        coin.Collect();
        _wallet.AddCoin();
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
}
