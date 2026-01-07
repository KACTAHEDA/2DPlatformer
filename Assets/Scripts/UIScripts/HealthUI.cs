using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Health _health;

    private void Start()
    {
        DisplayHealth();
    }

    private void OnEnable()
    {
        _health.HealthChanged += DisplayHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= DisplayHealth;
    }

    private void DisplayHealth()
    {
        _healthText.text = _health.CurentHealth.ToString();
    }
}
