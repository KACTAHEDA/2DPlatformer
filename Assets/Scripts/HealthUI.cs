using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _healthText.text = _player.Health.ToString();
    }
    private void OnEnable()
    {
        EventBus.Damage += DrawHealth;
    }

    private void OnDisable()
    {
        EventBus.Damage -= DrawHealth;
    }

    private void DrawHealth()
    {
        int health = _player.Health;

        _healthText.text = health.ToString();
    }
}
