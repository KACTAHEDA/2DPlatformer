using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] CoinColector _coinColector;
    [SerializeField] CompleteLevel _completeLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin))
        {
            _coinColector.TryCollect(coin);
        }

        if(collision.TryGetComponent(out Door door))
        {
            _completeLevel.LevelPased();
        }
    }
}
