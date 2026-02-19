using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Coroutine _timerCoroutine;

    public bool IsRuning { get; private set;}

    public event Action Started;
    public event Action<float> ProgressChanged;
    public event Action Completed;

    public void StartTimer(float duration)
    {
        if (_timerCoroutine != null)
            StopCoroutine(_timerCoroutine);

        _timerCoroutine = StartCoroutine(Run(duration));
    }

    private IEnumerator Run(float duration)
    {
        IsRuning = true;
        Started?.Invoke();

        float elapsed = 0f;

        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsed / duration);

            ProgressChanged?.Invoke(progress);

            yield return null;
        }

        IsRuning = false;
        ProgressChanged?.Invoke(1f);
        Completed?.Invoke();
    }
}
