using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class HealthUIBase : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected virtual void OnEnable()
    {
        Health.HealthChanged += OnHealthChanged;        
    }

    protected virtual void OnDisable()
    {
        Health.HealthChanged -= OnHealthChanged;
    }

    protected abstract void OnHealthChanged();
}
