using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private readonly int _speedHash = Animator.StringToHash("Speed");
    private readonly int _attackHash = Animator.StringToHash("Attack");
    private readonly int _isGroundedHash = Animator.StringToHash("IsGrounded");
    private readonly int _isMoveingHash = Animator.StringToHash("IsMoveing");

    [SerializeField] private Animator _animator;

    public void UpdateState(bool isGrounded, float moveInput, bool isMoveing)
    {
        _animator.SetBool(_isGroundedHash , isGrounded);
        _animator.SetFloat(_speedHash, moveInput);
        _animator.SetBool(_isMoveingHash, isMoveing);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(_attackHash);
    }
}
