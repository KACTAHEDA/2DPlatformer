using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const float MinProgress = 0f;
    private const float MaxProgress = 1f;

    private Coroutine _timerCoroutine;

    public event Action Started;
    public event Action<float> ProgressChanged;
    public event Action Completed;

    public float Duration { get; private set; }
    public float ElapsedTime { get; private set; }
    public bool IsRuning { get; private set;}

    public void StartTimer(float duration)
    {
        if (duration <= 0f)
            return;

        StopTimer();

        Duration = duration;
        ElapsedTime = MinProgress;
        IsRuning = true;

        Started?.Invoke();
        ProgressChanged?.Invoke(MinProgress);
        
        _timerCoroutine = StartCoroutine(Run(duration));
    }

    public void StopTimer()
    {
        if (IsRuning == false)
            return;

        if (_timerCoroutine != null)
            StopCoroutine(_timerCoroutine);

        IsRuning = false;
        ElapsedTime = MinProgress;
    }

    private IEnumerator Run(float duration)
    {
        while(ElapsedTime < duration)
        {
            ElapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(ElapsedTime / duration);

            ProgressChanged?.Invoke(progress);

            yield return null;
        }

        ElapsedTime = duration;
        IsRuning = false;

        ProgressChanged?.Invoke(MaxProgress);
        Completed?.Invoke();
    }
}
