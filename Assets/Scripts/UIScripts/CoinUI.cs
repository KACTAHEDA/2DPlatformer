using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private CoinColector _coinColector;

    private void Update()
    {
        DisplayCoinsCount();
    }

    private void DisplayCoinsCount()
    {
        _coinText.text = _coinColector.Coins.ToString();
    }
}
