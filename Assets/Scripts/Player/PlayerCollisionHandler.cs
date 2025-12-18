using UnityEngine;
using System;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<Coin> OnCoin;
    public event Action OnDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin))
        {
            OnCoin?.Invoke(coin);
        }

        if(collision.TryGetComponent(out Door door))
        {
            OnDoor?.Invoke();
        }
    }
}
