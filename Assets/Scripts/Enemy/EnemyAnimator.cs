using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private int _isMoveingHash = Animator.StringToHash("IsMoveing");

    [SerializeField] private Animator _animator;

    public void Animate(bool isWalk)
    {
        _animator.SetBool(_isMoveingHash , isWalk);
    }
}
