using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int _speedHash = Animator.StringToHash("Speed");
    private readonly int _attackHash = Animator.StringToHash("Attack");
    private readonly int _isGroundedHash = Animator.StringToHash("IsGrounded");
  
    [SerializeField] private Animator _animator;

    public void UpdateState(bool isGrounded, float moveInput)
    {
        _animator.SetBool(_isGroundedHash , isGrounded);
        _animator.SetFloat(_speedHash, moveInput);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(_attackHash);
    }
}
