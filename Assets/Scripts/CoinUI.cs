using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    private int _coins;

    private void OnEnable()
    {
        EventBus.CollectCoin += AddCoin; 
    }

    private void OnDisable()
    {
        EventBus.CollectCoin -= AddCoin;
    }

    private void AddCoin()
    {
        _coins++;
        _coinText.text = _coins.ToString();
    }
}
