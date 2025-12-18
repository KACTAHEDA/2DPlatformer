using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Wallet _wallet;

    private void Update()
    {
        DisplayCoinsCount();
    }

    private void DisplayCoinsCount()
    {
        _coinText.text = _wallet.Coins.ToString();
    }
}
