using UnityEngine;
using System;

public class CollisionHandler : MonoBehaviour
{
    public event Action<IDamageble> DamageableEntered;
    public event Action<IDamageble> DamageableExited;

    public event Action<Coin> OnCoin;
    public event Action<Heal> OnHeal;
    public event Action<Player> OnPlayer;
    public event Action OnDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IDamageble damageble))
        {
            DamageableEntered?.Invoke(damageble);
        }
  
        if (collision.TryGetComponent(out Coin coin))
        {
            OnCoin?.Invoke(coin);
        }

        if(collision.TryGetComponent(out Heal heal))
        {
            OnHeal?.Invoke(heal);
        }

        if (collision.TryGetComponent(out Finisher finisher))
        {
            OnDoor?.Invoke();
        }

        if(collision.TryGetComponent(out Player player))
        {
            OnPlayer?.Invoke(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageble damageble))
        {
            DamageableExited?.Invoke(damageble);
        }
    }
}
