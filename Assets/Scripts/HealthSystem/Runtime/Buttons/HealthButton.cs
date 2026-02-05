using UnityEngine;
using UnityEngine.UI;

public abstract class HealthButton : MonoBehaviour
{
    [SerializeField] protected Button Button;
    [SerializeField] protected Health Health;

    protected virtual void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }

    protected virtual void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();    
}
