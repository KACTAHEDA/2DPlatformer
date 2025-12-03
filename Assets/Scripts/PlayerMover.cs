using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _groundCheckRadius = 0.3f;
    [SerializeField] private GroundCheckPoint _groundCheckPoint;
    [SerializeField] private LayerMask _groundLayer;

    private string _horizontalInput = "Horizontal";
    private bool _isGrounded;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerState _playerState;

    private static readonly int StateHash = Animator.StringToHash("State");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheckPoint.transform.position, _groundCheckRadius, _groundLayer);

        Move();
        Jump();
        UpdateState();
    }

    private void Move()
    {
        float move = Input.GetAxisRaw(_horizontalInput);

        _rigidbody.velocity = new Vector2(move * _speed, _rigidbody.velocity.y);

        bool isWalk = Mathf.Abs(move) > 0.1f && _isGrounded;

        if (move != 0)
        {
            _spriteRenderer.flipX = move < 0;
        }

            EventBus.PlayerWalk(isWalk);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            EventBus.PlayerJump();
        }
    }

    private void UpdateState()
    {
        float minValueForMove = 0.1f;

        if (_isGrounded == false)
        {
            _playerState = PlayerState.Jump;
        }
        else if (Mathf.Abs(_rigidbody.velocity.x) >= minValueForMove)
        {
            _playerState = PlayerState.Move;            
        }
        else
        {
            _playerState = PlayerState.Idle;
        }

        _animator.SetInteger(StateHash, (int)_playerState);
    }
}
