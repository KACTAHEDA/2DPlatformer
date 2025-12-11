using UnityEngine;

public class CoinColector : MonoBehaviour
{
    public int Coins { get; private set; }

    public void TryCollect(Coin coin)
    {
        Coins++;
        coin.Collect();
    }
}
