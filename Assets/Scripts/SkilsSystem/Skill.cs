using System.Collections;
using UnityEngine;

public abstract class Skill : MonoBehaviour, ISkill
{
    [Header("Timings")]
    [SerializeField] private float _duration = 4f;
    [SerializeField] private float _cooldown = 6f;
    [SerializeField] private float _tickInterval = 0.5f;

    [Header("Timers")]
    [SerializeField] private DurationTimer _durationTimer;
    [SerializeField] private CooldownTimer _cooldownTimer;

    private Coroutine _tickCoroutine;

    public DurationTimer DurationTimer => _durationTimer;
    public CooldownTimer CooldownTimer => _cooldownTimer;

    public bool IsActive { get; private set; }

    protected virtual void OnEnable()
    {
        _durationTimer.Completed += OnDurationFinished;
    }

    protected virtual void OnDisable()
    {
        _durationTimer.Completed -= OnDurationFinished;
    }

    public void TryActivate()
    {
        if (IsActive || _cooldownTimer.IsReady == false)
            return;

        IsActive = true;
        OnActivated();
        _durationTimer.StartTimer(_duration);
        _tickCoroutine = StartCoroutine(TickCoroutine());
    }

    private IEnumerator TickCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_tickInterval);

        while (IsActive)
        {
            OnTick();
            yield return wait;
        }
    }

    private void OnDurationFinished()
    {
        IsActive = false;

        if (_tickCoroutine != null)
            StopCoroutine(_tickCoroutine);

        OnDeactivated();
        _cooldownTimer.StartTimer(_cooldown);
    }

    protected abstract void OnActivated();
    protected abstract void OnDeactivated();
    protected abstract void OnTick();
}
