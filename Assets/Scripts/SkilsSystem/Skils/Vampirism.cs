using UnityEngine;

public class Vampirism : Skill
{
    [SerializeField] private float _radius = 4f;
    [SerializeField] private int _damagePerTick = 2;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private GameObject _visualRadius;

    protected override void OnActivated()
    {
        _visualRadius.SetActive(true);
    }

    protected override void OnDeactivated()
    {
        _visualRadius.SetActive(false);
    }

    protected override void OnTick()
    {
        IDamageble target = FindClosestEnemy();

        if (target == null)
            return;

        target.TakeDamage(_damagePerTick);
        _playerHealth.Heal(_damagePerTick);
    }

    private IDamageble FindClosestEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyLayer);
        float minDistance = float.MaxValue;
        IDamageble closest = null;

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out IDamageble damageble) == false)
                continue;

            float distance = Vector3Extentions.SqrDistance(transform.position, hit.transform.position);

            if(distance < minDistance)
            {
                minDistance = distance;
                closest = damageble;
            }
        }

        return closest;
    }
}
