using UnityEngine;
using UnityEngine.UI;

public class SkillVisualUI : MonoBehaviour
{
    [SerializeField] private Skill _skill;

    [SerializeField] private Image _icon;
    [SerializeField] private Image _cooldownRadial;
    [SerializeField] private Image _durationBar;

    private void OnEnable()
    {
        _skill.CooldownTimer.Started += OnCooldownStarted;
        _skill.CooldownTimer.ProgressChanged += UpdateCooldown;
        _skill.CooldownTimer.Completed += OnCooldownFinished;

        _skill.DurationTimer.ProgressChanged += UpdateDuration;
        _skill.DurationTimer.Completed += OnDurationFinished;
    }

    private void OnDisable()
    {
        _skill.CooldownTimer.Started -= OnCooldownStarted;
        _skill.CooldownTimer.ProgressChanged -= UpdateCooldown;
        _skill.CooldownTimer.Completed -= OnCooldownFinished;

        _skill.DurationTimer.ProgressChanged -= UpdateDuration;
        _skill.DurationTimer.Completed -= OnDurationFinished;
    }

    private void UpdateCooldown(float progress)
    {
        if (_cooldownRadial != null)
            _cooldownRadial.fillAmount = 1f - progress;
    }

    private void UpdateDuration(float progress)
    {
        if (_durationBar == null)
        {
            return;
        }
        _durationBar.fillAmount = 1f - progress;
    }

    private void OnCooldownStarted()
    {
        DarkenIcon(true);
    }

    private void OnCooldownFinished()
    {
        DarkenIcon(false);

        if (_durationBar != null)
            _durationBar.fillAmount = 1f;
    }

    private void OnDurationFinished()
    {
        if (_durationBar != null)
            _durationBar.fillAmount = 0f;
    }

    private void DarkenIcon(bool value)
    {
        if (_icon == null)
            return;

        _icon.color = value
            ? new Color(0.4f, 0.4f, 0.4f, 1)
            : Color.white;
    }
}
