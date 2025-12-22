using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _speedHash = Animator.StringToHash("Speed");
    private int _isGroundedHash = Animator.StringToHash("IsGrounded");

    public void UpdateState(bool isGrounded, float moveInput)
    {
        _animator.SetBool(_isGroundedHash , isGrounded);
        _animator.SetFloat(_speedHash, moveInput);
    }
}
