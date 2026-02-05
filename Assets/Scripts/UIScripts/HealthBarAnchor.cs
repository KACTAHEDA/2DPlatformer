using UnityEngine;

public class HealthBarAnchor : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthUI _healthUIPrefab;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 1f, 0f);

    private HealthUI _healthUI;

    private void Start()
    {
        _healthUI = Instantiate(_healthUIPrefab, transform);
        _healthUI.transform.localPosition = _offset;

        _healthUI.Init(_health);
    }
}