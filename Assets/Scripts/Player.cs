using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 3;

    public int Health => _health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Enemy>() != null)
        {
            TakeDamage();
            EventBus.TakeDamage();
        }
    }

    private void TakeDamage()
    {
        if (_health > 0)
        {
            --_health;
        }
        else
        {
            EventBus.PlayerWalk(false);
            EventBus.Die();
            Destroy(gameObject);
        }
    }
}
