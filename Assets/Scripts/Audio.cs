using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _walkAudioSourse;

    [SerializeField] private AudioClip _jumpAudio;
    [SerializeField] private AudioClip _damageAudio;
    [SerializeField] private AudioClip _coinAudio;

    private bool _isWalkingNow = false;

    private void OnEnable()
    {
        EventBus.IsWalk += HandleWalk;
        EventBus.CollectCoin += PlayCoin;
        EventBus.Jump += PlayJump;
        EventBus.Damage += PlayDamage;
    }

    private void OnDisable()
    {
        EventBus.IsWalk -= HandleWalk;
        EventBus.CollectCoin -= PlayCoin;
        EventBus.Jump -= PlayJump;
        EventBus.Damage -= PlayDamage;
    }

    private void PlayJump()
    {
        _audioSource.PlayOneShot(_jumpAudio);
    }

    private void PlayCoin()
    {
        _audioSource.PlayOneShot(_coinAudio);
    }

    private void PlayDamage()
    {
        _audioSource.PlayOneShot(_damageAudio);
    }

    private void HandleWalk(bool isWalk)
    {
        if (_isWalkingNow == isWalk)
            return;

        _isWalkingNow = isWalk;

        if (isWalk)
            _walkAudioSourse.Play();
        else
            _walkAudioSourse.Stop();
    }
}

