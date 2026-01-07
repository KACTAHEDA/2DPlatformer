using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;

    public int CurentHealth { get; private set; }

    public event Action HealthChanged;
    public event Action Died;

    private void Awake()
    {
        CurentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(damage <= 0)
        {
            return;
        }

        CurentHealth = Mathf.Max(CurentHealth - damage, 0);
        HealthChanged?.Invoke();

        if(CurentHealth == 0)
        {
            Died?.Invoke();
        }
    }

    public void Heal(int value)
    {
        if(value <= 0)
        {
            return;
        }

        CurentHealth = Mathf.Min(CurentHealth + value, _maxHealth);
        HealthChanged?.Invoke();
    }
}
