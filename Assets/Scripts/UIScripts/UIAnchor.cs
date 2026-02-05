using UnityEngine;

public class UIAnchor : MonoBehaviour
{
    [SerializeField] private SpriteRotator _rotator;

    private void OnEnable()
    {
        _rotator.Flip += ResetRotation;
    }

    private void OnDisable()
    {
        _rotator.Flip -= ResetRotation;
    }

    private void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
        Debug.Log("+");
    }
}
