using UnityEngine.UI;
using UnityEngine;

public class HealthBarUI : HealthUIBase
{
    [SerializeField] protected Slider Slider;

    protected override void OnHealthChanged()
    {
        Slider.value = GetHealthPercent();
    }

    protected float GetHealthPercent()
    {
        return (float)Health.CurentHealth / Health.MaxHealth;
    }
}
