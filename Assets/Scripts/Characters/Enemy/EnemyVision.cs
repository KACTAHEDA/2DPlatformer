using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private float _viewDistance = 4f;
    [SerializeField] private LayerMask _playerLayer;

    private ITarget _curentTarget;

    public event Action<ITarget> PlayerDetected;
    public event Action PlayerLost;

    private void Update()
    {
        DetectTarget();
    }

    private void DetectTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _viewDistance, _playerLayer);

        if (hit != null && hit.TryGetComponent(out ITarget target))
        {
            if (_curentTarget == null)
            {
                _curentTarget = target;
                PlayerDetected?.Invoke(_curentTarget);
            }
        }
        else if (_curentTarget != null)
        {
            _curentTarget = null;
            PlayerLost?.Invoke();
        }
    }
}
