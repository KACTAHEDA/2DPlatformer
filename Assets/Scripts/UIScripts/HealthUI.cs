using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Slider _slider;

    private Health _health;

    public void Init(Health health )
    {
        _health = health;
        _health.HealthChanged += DisplayHealth;
        DisplayHealth();
    }

    private void OnDisable()
    {
        _health.HealthChanged -= DisplayHealth;
    }

    private void DisplayHealth()
    {
        if (_health == null)
            return;

        _healthText.text = $"{_health.CurentHealth} / {_health.MaxHealth}";
        _slider.value = (float)_health.CurentHealth / _health.MaxHealth;
    }
}
