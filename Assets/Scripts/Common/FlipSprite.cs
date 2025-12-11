using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Flip(float direction)
    {
        if (direction == 0)
            return;

        _spriteRenderer.flipX = direction < 0;
    }

    public void FlipTo(Vector3 target)
    {
        if (target.x > transform.position.x)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}
