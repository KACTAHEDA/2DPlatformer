using UnityEngine;

public class DamageButton : HealthButton
{
    [SerializeField] private int _damage = 15;

    protected override void OnButtonClick()
    {
        Health.TakeDamage(_damage);
    }
}
