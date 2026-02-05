using TMPro;
using UnityEngine;

public class HealthUIText : HealthUIBase
{
    [SerializeField] private TextMeshProUGUI _healthText;

    protected override void OnHealthChanged()
    {
        DisplayText();
    }

    private void Start()
    {
        DisplayText();
    }

    private void DisplayText()
    {
        _healthText.text = $"{Health.CurentHealth} / {Health.MaxHealth}";
    }
}
