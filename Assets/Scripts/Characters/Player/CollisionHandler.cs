using UnityEngine;
using System;

public class CollisionHandler : MonoBehaviour
{
    public event Action<Coin> OnCoin;
    public event Action OnDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            OnCoin?.Invoke(coin);
        }

        if (collision.TryGetComponent(out Finisher finisher))
        {
            OnDoor?.Invoke();
        }
    }
}
