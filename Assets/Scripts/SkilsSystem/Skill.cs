using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [Header("Timings")]
    [SerializeField] private float _duration = 4f;
    [SerializeField] private float _cooldown = 6f;

    [Header("Timers")]
    [SerializeField] private Timer _durationTimer;
    [SerializeField] private Timer _cooldownTimer;

    public event Action Activated;
    public event Action Deactivated;
    public event Action<float> DurationProgress;
    public event Action<float> CooldownProgress;

    public Timer DurationTimer => _durationTimer;
    public Timer CooldownTimer => _cooldownTimer;

    public bool IsReady => !_cooldownTimer.IsRuning;
    public float DurationElapsed => _durationTimer.ElapsedTime;

    private void OnEnable()
    {
        _durationTimer.ProgressChanged += OnDurationProgress;
        _durationTimer.Completed += OnDurationCompleted;
        _cooldownTimer.ProgressChanged += OnCooldownProgress;
    }

    private void OnDisable()
    {
        _durationTimer.ProgressChanged -= OnDurationProgress;
        _durationTimer.Completed -= OnDurationCompleted;
        _cooldownTimer.ProgressChanged -= OnCooldownProgress;
    }

    public void TryActivate()
    {
        if (IsReady == false)
            return;

        _durationTimer.StartTimer(_duration);
        _cooldownTimer.StartTimer(_cooldown);

        OnActivated();
        Activated?.Invoke();
    }

    private void OnDurationCompleted()
    {
        OnDeactivated();
        Deactivated?.Invoke();
    }

    private void OnDurationProgress(float progress) => DurationProgress?.Invoke(progress);

    private void OnCooldownProgress(float progress) => CooldownProgress?.Invoke(progress); 

    protected virtual void OnActivated() { }
    protected virtual void OnDeactivated() { }
}
