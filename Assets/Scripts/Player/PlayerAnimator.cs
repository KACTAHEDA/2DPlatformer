using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int _stateHash = Animator.StringToHash("State");

    [SerializeField] private Animator _animator;
    [SerializeField] private GroundCheck _groundCheck;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        float minToMove = 0.1f;
        int state;

        if (_groundCheck.IsGrounded == false)
            state = (int)PlayerState.Jump;
        else if (Mathf.Abs(_playerInput.MoveInput) > minToMove)
            state = (int)PlayerState.Move;
        else
            state = (int)PlayerState.Idle;

        _animator.SetInteger(_stateHash, state);
    }
}
