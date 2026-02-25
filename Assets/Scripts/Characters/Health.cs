using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 50f;

    public float CurentHealth { get; private set; }
    public float MaxHealth => _maxHealth;

    public event Action HealthChanged;
    public event Action Died;

    private void Awake()
    {
        CurentHealth = _maxHealth;
    }

    public float TakeDamage(float damage)
    {
        if(damage <= 0f)
        {
            return 0f;
        }



        CurentHealth = Mathf.Max(CurentHealth - damage, 0);
        HealthChanged?.Invoke();

        if(CurentHealth == 0)
        {
            Died?.Invoke();
        }

        return damage;
    }

    public void Heal(float value)
    {
        if(value <= 0)
        {
            return;
        }

        CurentHealth = Mathf.Min(CurentHealth + value, _maxHealth);
        HealthChanged?.Invoke();
    }
}
