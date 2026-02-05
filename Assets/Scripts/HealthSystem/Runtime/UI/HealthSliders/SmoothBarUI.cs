using System.Collections;
using UnityEngine;

public class SmoothBarUI : HealthBarUI
{
    [SerializeField] private float _smoothTime = 0.3f;

    private Coroutine _smoothCoroutine;

    protected override void OnHealthChanged()
    {
        if (_smoothCoroutine != null)
            StopCoroutine(_smoothCoroutine);

        _smoothCoroutine = StartCoroutine(SmoothChange());

    }

    private IEnumerator SmoothChange()
    {
        float startValue = Slider.value;
        float targetValue = GetHealthPercent();
        float passedTime = 0f;

        while (passedTime < _smoothTime)
        {
            passedTime += Time.deltaTime;
            float progress = passedTime / _smoothTime;

            Slider.value = Mathf.Lerp(startValue, targetValue, progress);
            yield return null;
        }

        Slider.value = targetValue;
    }
}
