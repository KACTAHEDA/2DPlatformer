using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private readonly int _isMoveingHash = Animator.StringToHash("IsMoveing");
    private readonly int _attackHash = Animator.StringToHash("Attack");

    [SerializeField] private Animator _animator;

    public void PlayMovement(bool isWalk)
    {
        _animator.SetBool(_isMoveingHash , isWalk);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(_attackHash);
    }
}
