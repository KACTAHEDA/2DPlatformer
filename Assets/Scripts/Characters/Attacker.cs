using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _cooldown = 0.5f;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _damageableLayer;

    private float _lastAttackTime;
    private IDamageble _owner;

    public bool CanAttack => Time.time >= _lastAttackTime + _cooldown;

    private void Awake()
    {
        _owner = GetComponentInParent<IDamageble>();
    }

    public void TryAttack()
    {
        if (!CanAttack)
            return;

        _lastAttackTime = Time.time;

        Collider2D[] hits = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _damageableLayer);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<IDamageble>(out var damageble))
            {
                if(damageble == _owner)
                {
                    continue;
                }

                damageble.TakeDamage(_damage);
                break;
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
#endif
}
