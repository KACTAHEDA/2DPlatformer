using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
    [SerializeField] private SpriteRotator _rotator;
    [SerializeField] private CharacterAnimator _animator;

    public void UpdateVisual(bool isGrounded, float direction, bool IsMoveing)
    {
        _rotator.Rotate(direction);
        _animator.UpdateState(isGrounded, Mathf.Abs(direction), IsMoveing);
    }

    public void PlayAttack()
    {
        _animator.PlayAttack();
    }
}
