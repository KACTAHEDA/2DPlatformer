using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Player>() != null)
        {
            EventBus.CoinCollected();
            Destroy(gameObject);
        }
    }
}
