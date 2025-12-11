using UnityEngine;

public class PlayerMover : Mover
{
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private FlipSprite _flipSprite;

    private PlayerInput _playerInput;

    protected override void Awake()
    {
        base.Awake();

        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move(_playerInput.MoveInput);
        _flipSprite.Flip(_playerInput.MoveInput);

        if(_playerInput.JumpPressed && _groundCheck.IsGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
