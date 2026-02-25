using UnityEngine;

public class VampirismAura : Skill
{
    [SerializeField] private float _radius = 4f;
    [SerializeField] private int _damagePerTick = 2;
    [SerializeField] private int _maxTargetsCount = 10;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Health _playerHealth;

    private Collider2D[] _buffer;

    private void Awake()
    {
        _buffer = new Collider2D[_maxTargetsCount];
    }

    protected override void OnActivated()
    {
        DurationProgress += OnDurationProgress;
    }

    protected override void OnDeactivated()
    {
        DurationProgress -= OnDurationProgress;
    }

    private void OnDurationProgress(float _)
    {
        IDamageble target = FindClosestEnemy();

        if (target == null)
            return;

        float damageOnFrame = _damagePerTick * Time.deltaTime;
        target.TakeDamage(damageOnFrame);
        _playerHealth.Heal(damageOnFrame);
    }

    private IDamageble FindClosestEnemy()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _buffer, _enemyLayer);
        float minDistance = float.MaxValue;
        IDamageble closest = null;

        for (int i = 0; i < count; i++)
        {
            if (_buffer[i].TryGetComponent(out IDamageble damageble) == false)
                continue;

            float distance = Vector3Extentions.SqrDistance(transform.position, _buffer[i].transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closest = damageble;
            }
        }

        return closest;
    }
}
