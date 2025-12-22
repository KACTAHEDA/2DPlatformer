using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.ValueChanged += DisplayCoinsCount;
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= DisplayCoinsCount;
    }

    private void DisplayCoinsCount()
    {
        _coinText.text = _wallet.Coins.ToString();
    }
}
