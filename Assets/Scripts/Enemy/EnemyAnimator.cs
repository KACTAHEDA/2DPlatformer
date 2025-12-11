using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private readonly int _stateHash = Animator.StringToHash("State");

    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyPatrol _patrol;

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        int state = _patrol.IsMoving ? 1 : 0;
        _animator.SetInteger(_stateHash, state);
    }
}
